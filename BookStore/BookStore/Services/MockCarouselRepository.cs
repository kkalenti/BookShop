using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                //Title = "Discount books",
                //Description = "Discount books get them all",
                ImageUrl = "Carousel1.jpg"
            });
            _carousels.Add(new Carousel()
            {
                Id = 1,
                //Title = "New books",
                //Description = "All brand new books",
                ImageUrl = "Carousel2.jpg"
            });
            _carousels.Add(new Carousel()
            {
                Id =2,
                //Title = "Subscriptions",
                //Description = "Discount on monthly subscriptions",
                ImageUrl = "Carousel3.jpg"
            });
        }

        public IEnumerable<Carousel> Get(Expression<Func<Carousel, bool>> filter = null, string includeProperties = "")
        {
            //return _carousels.FirstOrDefault(x => x.Id == id);
            return null;
        }

        public IEnumerable<Carousel> GetAll()
        {
            return _carousels.ToList();
        }

        public bool Create(Carousel item)
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

        public bool Update(Carousel item)
        {
            throw new System.NotImplementedException();
        }
    }
}