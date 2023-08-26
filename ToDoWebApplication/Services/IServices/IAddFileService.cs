using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ToDoWebApplication.Domian.Entities;
using ToDoWebApplication.Services.DTOs.AddFileDTOs;

namespace ToDoWebApplication.Services.IServices
{
    public interface IAddFileService
    {
        ValueTask<AddFileForViewDTOs> CreateAsync(AddFileForCreationDTOs addFileForCreationDTO);

        ValueTask<AddFileForViewDTOs> UpdateAsync(int id, AddFileForCreationDTOs addFileForCreationDTO);

        ValueTask<bool> DeleteAsync(int id);

        ValueTask<AddFileForViewDTOs> GetAsync(Expression<Func<AddFile, bool>> expression);

        ValueTask<IEnumerable<AddFileForViewDTOs>> GetAllAsync(
            Expression<Func<AddFile, bool>> expression = null);
    }
}
