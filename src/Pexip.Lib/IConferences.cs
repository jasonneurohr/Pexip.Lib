using System.Threading.Tasks;

namespace Pexip.Lib
{
    public interface IConferences
    {
        Task<int> GetTotal();
    }
}
