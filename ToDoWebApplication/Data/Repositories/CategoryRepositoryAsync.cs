using ToDoWebApplication.Data.IRepositories;
using ToDoWebApplication.Domian.Entities;

namespace ToDoWebApplication.Data.Repositories
{
    public class CategoryRepositoryAsync : GenericRepositoryAsync<Category>,ICategoryRepositoryAsync
    {
        private readonly DatabaseContext dbContext;
        public CategoryRepositoryAsync(DatabaseContext dbContext) :base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
