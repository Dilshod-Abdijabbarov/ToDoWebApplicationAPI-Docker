using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ToDoWebApplication.Domian.Entities;
using ToDoWebApplication.Services.DTOs.UserDTOs;

namespace ToDoWebApplication.Services.IServices
{
    public interface IUserService
    {
        ValueTask<UserForViewDTO> CreateAsync(UserForCreationDTO userForCreationDTO);

        ValueTask<UserForViewDTO> UpdateAsync(int id, UserForCreationDTO userForCreationDTO);

        ValueTask<bool> DeleteAsync(int id);

        ValueTask<UserForViewDTO> GetAsync(Expression<Func<User, bool>> expression);

        ValueTask<IEnumerable<UserForViewDTO>> GetAllAsync(            
            Expression<Func<User, bool>> expression = null);

        ValueTask<bool> ChangePasswordAsync(UserForPasswordChangeDTO userForChangePasswordDTO);
    }
}
