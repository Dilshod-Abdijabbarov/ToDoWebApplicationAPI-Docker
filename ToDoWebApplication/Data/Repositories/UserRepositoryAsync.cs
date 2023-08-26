using ToDoWebApplication.Data.IRepositories;
using ToDoWebApplication.Domian.Entities;

namespace ToDoWebApplication.Data.Repositories
{
    public class UserRepositoryAsync : GenericRepositoryAsync<User>,IUserRepositoryAsync
    {
        private readonly DatabaseContext dbContext;
        public UserRepositoryAsync(DatabaseContext dbContext):base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
