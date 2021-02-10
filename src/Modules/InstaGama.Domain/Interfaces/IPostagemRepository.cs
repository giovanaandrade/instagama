using InstaGama.Domain.Entities;
using System.Threading.Tasks;

namespace InstaGama.Domain.Interfaces
{
    public interface IPostagemRepository
    {
        Task<Postagem> GetByIdAsync(int id);
    }
}
