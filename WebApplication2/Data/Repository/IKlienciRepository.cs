using System.Collections.Generic;
using WebApplication2.Models;

namespace WebApplication2.Data.Repository
{
    public interface IKlienciRepository
    {
        IEnumerable<Klienci> GetAll();
        Klienci GetById(int id);
        void Insert(Klienci klienci);
        void Update(Klienci klienci);
        void Delete(int id);
        void Save();
    }
}
