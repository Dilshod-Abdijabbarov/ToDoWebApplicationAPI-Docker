using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ToDoWebApplication.Domian.Entities;
using ToDoWebApplication.Services.DTOs.AddDueDateDTOs;

namespace ToDoWebApplication.Services.IServices
{
    public interface IAddDueDateService
    {
        ValueTask<AddDueDateForViewDTOs> CreateAsync(AddDueDateForCreationDTO addDueDateForCreationDTO);

        ValueTask<AddDueDateForViewDTOs> UpdateAsync(int id, AddDueDateForCreationDTO addDueDateForCreationDTO);

        ValueTask<bool> DeleteAsync(int id);

        ValueTask<AddDueDateForViewDTOs> GetAsync(Expression<Func<AddDueDate, bool>> expression);

        ValueTask<IEnumerable<AddDueDateForViewDTOs>> GetAllAsync(
            Expression<Func<AddDueDate, bool>> expression = null);
    }
}
