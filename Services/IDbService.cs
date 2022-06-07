using System.Threading.Tasks;
using Kolokwium2.Models.DTO;

namespace Kolokwium2.Services
{
    public interface IDbService
    {
        public Task<SomeAlbum> GetAlbum(int id);
        public Task<int> DeleteMusician(int id);

    }
}