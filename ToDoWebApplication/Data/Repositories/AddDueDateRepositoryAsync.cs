using ToDoWebApplication.Data.IRepositories;
using ToDoWebApplication.Domian.Entities;

namespace ToDoWebApplication.Data.Repositories
{
    public class AddDueDateRepositoryAsync : GenericRepositoryAsync<AddDueDate>,IAddDueDateRepositoryAsync
    {
        private readonly DatabaseContext dbContext;
        public AddDueDateRepositoryAsync(DatabaseContext dbContext):base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
