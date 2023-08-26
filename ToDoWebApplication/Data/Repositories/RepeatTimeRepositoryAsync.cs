using ToDoWebApplication.Data.IRepositories;
using ToDoWebApplication.Domian.Entities;

namespace ToDoWebApplication.Data.Repositories
{
    public class RepeatTimeRepositoryAsync : GenericRepositoryAsync<RepeatTime>,IRepeatTimeRepositoryAsync
    {
        private readonly DatabaseContext dbContext;
        public RepeatTimeRepositoryAsync(DatabaseContext dbContext):base(dbContext)
        {

            this.dbContext = dbContext;

        }
    }
}
