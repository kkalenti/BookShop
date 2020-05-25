using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BookStore.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Services
{
    public class SqlCommentRepository: IRepository<Comment>
    {
        private BookStoreDbContext _context;

        public SqlCommentRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Comment> Get(Expression<Func<Comment, bool>> filter, string includeProperties = "")
        {
            var query = _context.Comments.Where(filter);

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public IEnumerable<Comment> GetAll()
        {
            return _context.Comments;
        }

        public bool Create(Comment item)
        {
            try
            {
                _context.Add(item);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Comment item)
        {
            try
            {
                var comment = Get(model => model.Id == item.Id).FirstOrDefault();
                if (comment != null)
                {
                    _context.Remove(comment);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(Comment item)
        {
            //TODO: 
            try
            {
                var comment = Get(model => model.Id == item.Id).FirstOrDefault();
                if (comment != null)
                {
                    comment.Text = item.Text;
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}