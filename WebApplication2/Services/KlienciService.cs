using WebApplication2.Models;
using WebApplication2.Data.Repository;
using WebApplication2.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication2.Services
{
    public class KlienciService : IKlienciService
    {
        private readonly IKlienciRepository _repo;

        public KlienciService(IKlienciRepository repo) => _repo = repo;

        public Task<IEnumerable<Klienci>> GetAllAsync() =>
            Task.FromResult(_repo.GetAll());

        public Task<Klienci?> GetByIdAsync(int id) =>
            Task.FromResult(_repo.GetById(id));

        public Task CreateAsync(Klienci klienci)
        {
            _repo.Insert(klienci);
            _repo.Save();
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Klienci klienci)
        {
            _repo.Update(klienci);
            _repo.Save();
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var existing = await GetByIdAsync(id);
            if (await ExistsAsync(id))
            {
                _repo.Delete(id); 
                _repo.Save();
            }
        }

        public Task<bool> ExistsAsync(int id) =>
            Task.FromResult(_repo.GetById(id) != null);
    }
}