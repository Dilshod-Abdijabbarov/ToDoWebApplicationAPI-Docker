using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ToDoWebApplication.Domian.Entities;
using ToDoWebApplication.Services.DTOs.RepeatTimeDTOs;

namespace ToDoWebApplication.Services.IServices
{
    public interface IRepeatTimeService
    {
        ValueTask<RepeatTimeForViewDTO> CreateAsync(RepeatTimeForCreationDTO repeatTimeForCreationDTO);

        ValueTask<RepeatTimeForViewDTO> UpdateAsync(int id, RepeatTimeForCreationDTO repeatTimeForCreationDTO);

        ValueTask<bool> DeleteAsync(int id);

        ValueTask<RepeatTimeForViewDTO> GetAsync(Expression<Func<RepeatTime, bool>> expression);

        ValueTask<IEnumerable<RepeatTimeForViewDTO>> GetAllAsync(
            Expression<Func<RepeatTime, bool>> expression = null);
    }
}
