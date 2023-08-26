using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ToDoWebApplication.Domian.Entities;
using ToDoWebApplication.Services.DTOs.TaskBaseDTOs;

namespace ToDoWebApplication.Services.IServices
{
    public interface ITaskBaseService
    {
        ValueTask<TaskBaseForViewDTO> CreateAsync(TaskBaseForCreationDTO taskBaseForCreationDTO);

        ValueTask<TaskBaseForViewDTO> UpdateAsync(int id, TaskBaseForCreationDTO taskBaseForCreationDTO);

        ValueTask<bool> DeleteAsync(int id);

        ValueTask<TaskBaseForViewDTO> GetAsync(Expression<Func<TaskBase, bool>> expression);

        ValueTask<IEnumerable<TaskBaseForViewDTO>> GetAllAsync(
            Expression<Func<TaskBase, bool>> expression = null);
    }
}
