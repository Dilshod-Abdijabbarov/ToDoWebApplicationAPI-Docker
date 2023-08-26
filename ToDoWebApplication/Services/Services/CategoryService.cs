using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ToDoWebApplication.Data.IRepositories;
using ToDoWebApplication.Domian.Entities;
using ToDoWebApplication.Services.DTOs.CategoryDTOs;
using ToDoWebApplication.Services.Exceptions;
using ToDoWebApplication.Services.IServices;

namespace ToDoWebApplication.Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepositoryAsync categoryRepositoryAsync;
        private readonly IMapper mapper;
        public CategoryService(ICategoryRepositoryAsync categoryRepositoryAsync,IMapper mapper)
        {
            this.categoryRepositoryAsync = categoryRepositoryAsync;
            this.mapper = mapper;
        }
        public async ValueTask<CategoryForViewDTO> CreateAsync(CategoryForCreationDTO categoryForCreationDTO)
        {
            var category = await categoryRepositoryAsync.CreateAsync(mapper.Map<Category>(categoryForCreationDTO));

            if (category == null)
                throw new ToDoException(400, "Create Not Category");

            await categoryRepositoryAsync.SaveChangesAsync();

            return mapper.Map<CategoryForViewDTO>(category);
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var isDelete = await categoryRepositoryAsync.DeleteAsync(c => c.Id == id);

            if (!isDelete)
                throw new ToDoException(404, "Category Not Delete");

            await categoryRepositoryAsync.SaveChangesAsync();

            return isDelete;
        }

        public async ValueTask<IEnumerable<CategoryForViewDTO>> GetAllAsync(Expression<Func<Category, bool>> expression = null)
        {
            var categories = await categoryRepositoryAsync.GetAllAsync(expression: expression, isTracking: true).ToListAsync();

            if (categories == null)
                throw new ToDoException(404, "Category Not fount");

            return mapper.Map<IEnumerable<CategoryForViewDTO>>(categories);
        }

        public async ValueTask<CategoryForViewDTO> GetAsync(Expression<Func<Category, bool>> expression)
        {
            var category = await categoryRepositoryAsync.GetAsync(expression);

            if (category == null)
                throw new ToDoException(404, "Category Not fount");

            return mapper.Map<CategoryForViewDTO>(category);
        }

        public async ValueTask<CategoryForViewDTO> UpdateAsync(int id, CategoryForCreationDTO categoryForCreationDTO)
        {
            var category = await categoryRepositoryAsync.GetAsync(c => c.Id == id);

            if (category == null)
                throw new ToDoException(404, "Category Not Update");

            category = categoryRepositoryAsync.Update(mapper.Map(categoryForCreationDTO, category));

            await categoryRepositoryAsync.SaveChangesAsync();

            return mapper.Map<CategoryForViewDTO>(category);
        }
    }
}
