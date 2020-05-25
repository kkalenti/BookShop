using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BookStore.Models;

namespace BookStore.Services
{
    public class MockCountryRepository : IRepository<Country>
    {
        public IEnumerable<Country> Get(Expression<Func<Country, bool>> filter = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Country> GetAll()
        {
            return new List<Country>()
            {
                new Country(){ Id = 1, Name = "Country 1" },
                new Country(){ Id = 2, Name = "Country 2" },
                new Country(){ Id = 3, Name = "Country 3" },
                new Country(){ Id = 4, Name = "Country 4" },
                new Country(){ Id = 5, Name = "Country 5" }
            };
        }

        public bool Create(Country item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Country item)
        {
            throw new NotImplementedException();
        }

        public bool Update(Country item)
        {
            throw new NotImplementedException();
        }
    }
}
