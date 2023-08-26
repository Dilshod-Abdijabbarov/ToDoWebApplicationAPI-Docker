using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ToDoWebApplication.Data.IRepositories;
using ToDoWebApplication.Domian.Entities;
using ToDoWebApplication.Services.DTOs.TaskBaseDTOs;
using ToDoWebApplication.Services.Exceptions;
using ToDoWebApplication.Services.IServices;

namespace ToDoWebApplication.Services.Services
{
    public class TaskBaseService : ITaskBaseService
    {
        private readonly ITaskRepositoryAsync taskRepository;
        private readonly IMapper mapper;
        public TaskBaseService(ITaskRepositoryAsync taskRepository, IMapper mapper)
        {
            this.taskRepository = taskRepository;
            this.mapper = mapper;
        }
        public async ValueTask<TaskBaseForViewDTO> CreateAsync(TaskBaseForCreationDTO taskBaseForCreationDTO)
        {
            var alreadytask = await taskRepository.GetAsync(c => c.TaskName == taskBaseForCreationDTO.TaskName);

            if (alreadytask != null)
                throw new ToDoException(400, "Task with such taskname already exist");

            var task = await taskRepository.CreateAsync(mapper.Map<TaskBase>(taskBaseForCreationDTO));

            await taskRepository.SaveChangesAsync();

            return mapper.Map<TaskBaseForViewDTO>(task);
        }

        public async ValueTask<bool> DeleteAsync(int id)
        {
            var isDelete = await taskRepository.DeleteAsync(c => c.Id == id);

            if (!isDelete)
                throw new ToDoException(404, "Task Not Delete");

            await taskRepository.SaveChangesAsync();

            return isDelete;
        }

        public async ValueTask<IEnumerable<TaskBaseForViewDTO>> GetAllAsync(Expression<Func<TaskBase, bool>> expression = null)
        {
            var tasks = await taskRepository.GetAllAsync(expression: expression, isTracking: false,
                 include: p => p.Include(c => c.Categories)
                                .Include(f => f.AddFiles)
                                .Include(d => d.AddDueDates)
                                .Include(r => r.RepeatTimes)).ToListAsync();

            if (tasks == null)
                throw new ToDoException(404, "Tasks Not fount");

            return mapper.Map<IEnumerable<TaskBaseForViewDTO>>(tasks);
        }

        public async ValueTask<TaskBaseForViewDTO> GetAsync(Expression<Func<TaskBase, bool>> expression)
        {
            var task = await taskRepository.GetAsync(expression);

            if (task == null)
                throw new ToDoException(404, "Task Not fount");

            return mapper.Map<TaskBaseForViewDTO>(task);
        }

        public async ValueTask<TaskBaseForViewDTO> UpdateAsync(int id, TaskBaseForCreationDTO taskBaseForCreationDTO)
        {
            var taskData = await taskRepository.GetAsync(c => c.Id == id);

            if (taskData == null)
                throw new ToDoException(404, "Task Not Update");

            taskData = taskRepository.Update(mapper.Map(taskBaseForCreationDTO, taskData));

            await taskRepository.SaveChangesAsync();

            return mapper.Map<TaskBaseForViewDTO>(taskData);
        }
    }
}
