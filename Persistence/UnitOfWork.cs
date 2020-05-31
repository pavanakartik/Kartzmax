using System.Threading.Tasks;

namespace kartzmax.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly KartzMaxDbContext context;

        public UnitOfWork(KartzMaxDbContext context)
        {
            this.context = context;
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }

    }
}