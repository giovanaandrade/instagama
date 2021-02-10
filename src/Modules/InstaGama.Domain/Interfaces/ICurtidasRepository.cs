using InstaGama.Domain.Entities;
using System.Threading.Tasks;

namespace InstaGama.Domain.Interfaces
{
    public interface ICurtidasRepository
    {
        Task<Curtidas> GetByIdAsync(int id);
    }
}
