using ToDoWebApplication.Data.IRepositories;
using ToDoWebApplication.Domian.Entities;

namespace ToDoWebApplication.Data.Repositories
{
    public class TaskRepositoryAsync : GenericRepositoryAsync<TaskBase>, ITaskRepositoryAsync
    {
        private readonly DatabaseContext dbContext;
        public TaskRepositoryAsync(DatabaseContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
