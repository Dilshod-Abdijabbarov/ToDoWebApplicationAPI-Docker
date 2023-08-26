using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ToDoWebApplication.Data.IRepositories;
using ToDoWebApplication.Domian.Entities;
using ToDoWebApplication.Services.DTOs.UserDTOs;
using ToDoWebApplication.Services.Exceptions;
using ToDoWebApplication.Services.IServices;

namespace ToDoWebApplication.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepositoryAsync userRepository;
        private readonly IMapper mapper;
        public UserService(IUserRepositoryAsync userRepository,IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async ValueTask<UserForViewDTO> CreateAsync(UserForCreationDTO userForCreationDTO)
        {
            var alreadyuser = await userRepository.GetAsync(c => c.FirstName == userForCreationDTO.FirstName);

            if (alreadyuser != null)
                throw new ToDoException(400, "User with such username already exist");

            var user = await userRepository.CreateAsync(mapper.Map<User>(userForCreationDTO));

            await userRepository.SaveChangesAsync();

            return mapper.Map<UserForViewDTO>(user);
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var isDelete = await userRepository.DeleteAsync(c => c.Id == id);

            if (!isDelete)
                throw new ToDoException(404, "User Not Delete");

            await userRepository.SaveChangesAsync();

            return isDelete;
        }

        public async ValueTask<IEnumerable<UserForViewDTO>> GetAllAsync(Expression<Func<User, bool>> expression = null)      
        {
            var users = await userRepository.GetAllAsync(expression: expression, isTracking: false, include: p => p
                .Include(x => x.Tasks).ThenInclude(c => c.Categories)
                .Include(x => x.Tasks).ThenInclude(f => f.AddFiles)
                .Include(x => x.Tasks).ThenInclude(d => d.AddDueDates)
                .Include(x => x.Tasks).ThenInclude(r => r.RepeatTimes)).ToListAsync();

            if (users == null)
                throw new ToDoException(404, "Users Not fount");

            return mapper.Map<IEnumerable<UserForViewDTO>>(users);
        }
   
        public async ValueTask<UserForViewDTO> GetAsync(Expression<Func<User, bool>> expression)
        {
            var user = await userRepository.GetAsync(expression,include: p => p
                .Include(x => x.Tasks).ThenInclude(c => c.Categories)
                .Include(x => x.Tasks).ThenInclude(f => f.AddFiles)
                .Include(x => x.Tasks).ThenInclude(d => d.AddDueDates)
                .Include(x => x.Tasks).ThenInclude(r => r.RepeatTimes));

            if (user == null)
                throw new ToDoException(404, "User Not fount");

            return mapper.Map<UserForViewDTO>(user);
        }

        public async ValueTask<UserForViewDTO> UpdateAsync(int id, UserForCreationDTO userForCreationDTO)
        {
            var userData = await userRepository.GetAsync(c => c.Id == id);

            if (userData == null)
                throw new ToDoException(404, "User Not Update");

            userData = userRepository.Update(mapper.Map(userForCreationDTO, userData));

            await userRepository.SaveChangesAsync();

            return mapper.Map<UserForViewDTO>(userData);
        }

        public async ValueTask<bool> ChangePasswordAsync(UserForPasswordChangeDTO userForChangePasswordDTO)
        {
            var user = await userRepository.GetAsync(x => x.Email.Equals(
                             userForChangePasswordDTO.Email) && x.Password.Equals(userForChangePasswordDTO.OldPassword));

            if (user == null)
                throw new ToDoException(400, "User Not Found");

            if (user.Password == userForChangePasswordDTO.NewPassword)
                throw new ToDoException(400, "Password in Incorrect");

            user.Password = userForChangePasswordDTO.NewPassword;

            userRepository.Update(user);

            await userRepository.SaveChangesAsync();

            return true;
        }
    }
}
