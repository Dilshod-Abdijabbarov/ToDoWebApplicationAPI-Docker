using ToDoWebApplication.Data.IRepositories;
using ToDoWebApplication.Domian.Entities;

namespace ToDoWebApplication.Data.Repositories
{
    public class AddFileRepositoryAsync : GenericRepositoryAsync<AddFile>,IAddFileRepositoryAsync
    {
        private readonly DatabaseContext dbContext;
        public AddFileRepositoryAsync(DatabaseContext dbContext):base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
