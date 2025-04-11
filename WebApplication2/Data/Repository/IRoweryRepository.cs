using System.Collections.Generic;
using WebApplication2.Models;

namespace WebApplication2.Data.Repository
{
    public interface IRoweryRepository
    {
        IEnumerable<Rowery> GetAll();
        Rowery GetById(int id);
        void Insert(Rowery rowery);
        void Update(Rowery rowery);
        void Delete(int id);
        void Save();
    }
}