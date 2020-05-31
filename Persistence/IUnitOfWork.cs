using System.Threading.Tasks;

namespace kartzmax.Persistence
{
    public interface IUnitOfWork
    {
         Task CompleteAsync();
    }
}