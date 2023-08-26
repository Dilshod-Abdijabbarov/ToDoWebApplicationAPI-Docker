using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ToDoWebApplication.Data.IRepositories;
using ToDoWebApplication.Domian.Entities;
using ToDoWebApplication.Services.DTOs.RepeatTimeDTOs;
using ToDoWebApplication.Services.Exceptions;
using ToDoWebApplication.Services.IServices;

namespace ToDoWebApplication.Services.Services
{
    public class RepeatTimeService : IRepeatTimeService
    {
        private readonly IRepeatTimeRepositoryAsync repeatTimeRepository;
        private readonly IMapper mapper;
        public RepeatTimeService(IRepeatTimeRepositoryAsync repeatTimeRepository, IMapper mapper)
        {
            this.repeatTimeRepository = repeatTimeRepository;
            this.mapper = mapper;

        }

        public IRepeatTimeRepositoryAsync RepeatTimeRepository => repeatTimeRepository;

        public async ValueTask<RepeatTimeForViewDTO> CreateAsync(RepeatTimeForCreationDTO repeatTimeForCreationDTO)
        {
            var repeatTime = await RepeatTimeRepository.CreateAsync(mapper.Map<RepeatTime>(repeatTimeForCreationDTO));

            if (repeatTime == null)
                throw new ToDoException(400, "Create Not RepeatTime");
            await RepeatTimeRepository.SaveChangesAsync();

            return mapper.Map<RepeatTimeForViewDTO>(repeatTime);
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var isDelete = await RepeatTimeRepository.DeleteAsync(c => c.Id == id);

            if (!isDelete)
                throw new ToDoException(404, "RepatTime Not Delete");

            await RepeatTimeRepository.SaveChangesAsync();

            return isDelete;
        }

        public async ValueTask<IEnumerable<RepeatTimeForViewDTO>> GetAllAsync(Expression<Func<RepeatTime, bool>> expression = null)
        {
            var repeatTime =await RepeatTimeRepository.GetAllAsync(expression: expression, isTracking: true).ToListAsync();

            if (repeatTime == null)
                throw new ToDoException(404, "RepatTime Not fount");

            return mapper.Map<IEnumerable<RepeatTimeForViewDTO>>(repeatTime);
        }

        public async ValueTask<RepeatTimeForViewDTO> GetAsync(Expression<Func<RepeatTime, bool>> expression)
        {
            var task = await RepeatTimeRepository.GetAsync(expression);

            if (task == null)
                throw new ToDoException(404, "RepeatTime Not fount");

            return mapper.Map<RepeatTimeForViewDTO>(task);
        }

        public async ValueTask<RepeatTimeForViewDTO> UpdateAsync(int id, RepeatTimeForCreationDTO repeatTimeForCreationDTO)
        {
            var repeatTime = await RepeatTimeRepository.GetAsync(c => c.Id == id);

            if (repeatTime == null)
                throw new ToDoException(404, "RepeatTime Not Update");

            repeatTime = RepeatTimeRepository.Update(mapper.Map(repeatTimeForCreationDTO, repeatTime));

            await RepeatTimeRepository.SaveChangesAsync();

            return mapper.Map<RepeatTimeForViewDTO>(repeatTime);
        }
    }
}
