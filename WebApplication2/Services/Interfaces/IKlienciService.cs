
using WebApplication2.Models;

namespace WebApplication2.Services.Interfaces
{
    public interface IKlienciService
    {
        Task<IEnumerable<Klienci>> GetAllAsync();
        Task<Klienci?> GetByIdAsync(int id);
        Task CreateAsync(Klienci klienci);
        Task  UpdateAsync(Klienci klienci);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}