using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ToDoWebApplication.Domian.Entities;
using ToDoWebApplication.Services.DTOs.CategoryDTOs;

namespace ToDoWebApplication.Services.IServices
{
    public interface ICategoryService
    {
        ValueTask<CategoryForViewDTO> CreateAsync(CategoryForCreationDTO categoryForCreationDTO);

        ValueTask<CategoryForViewDTO> UpdateAsync(int id, CategoryForCreationDTO categoryForCreationDTO);

        ValueTask<bool> DeleteAsync(int id);

        ValueTask<CategoryForViewDTO> GetAsync(Expression<Func<Category, bool>> expression);

        ValueTask<IEnumerable<CategoryForViewDTO>> GetAllAsync(
            Expression<Func<Category, bool>> expression = null);
    }
}
