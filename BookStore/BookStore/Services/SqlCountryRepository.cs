using System.Collections.Generic;
using BookStore.Data;
using BookStore.Models;

namespace BookStore.Services
{
    public class SqlCountryRepository : IRepository<Country>
    {
        private BookStoreDbContext _context;

        public SqlCountryRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public Country Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Country> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public bool Create(Country item)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(Country item)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(Country item)
        {
            throw new System.NotImplementedException();
        }
    }
}