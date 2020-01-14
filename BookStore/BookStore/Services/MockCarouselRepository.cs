using System;
using System.Collections.Generic;
using System.Linq;
using BookStore.Models;

namespace BookStore.Services
{
    public class MockCarouselRepository : IRepository<Carousel>
    {
        private readonly List<Carousel> _carousels = new List<Carousel>();

        public MockCarouselRepository()
        {
            _carousels.Add(new Carousel()
            {
                Id = 0,
                Title = "Discount books",
                Description = "Discount books get them all",
                ImageUrl = ""
            });
            _carousels.Add(new Carousel()
            {
                Id = 1,
                Title = "New books",
                Description = "All brand new books",
                ImageUrl = ""
            });
            _carousels.Add(new Carousel()
            {
                Id =2,
                Title = "Subscriptions",
                Description = "Discount on monthly subscriptions",
                ImageUrl = ""
            });
        }

        public Carousel Get(int id)
        {
            return _carousels.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Carousel> GetAll()
        {
            return _carousels.ToList();
        }

        public bool Add(Carousel item)
        {
            try
            {
                var carousel = item;
                carousel.Id = _carousels.Max(x => x.Id) + 1;
                _carousels.Add(carousel);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Carousel item)
        {
            throw new System.NotImplementedException();
        }

        public bool Edit(Carousel item)
        {
            throw new System.NotImplementedException();
        }
    }
}