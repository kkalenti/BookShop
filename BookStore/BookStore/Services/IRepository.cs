using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace BookStore.Services
{
    
    public interface IRepository<T>
    {
        /// <summary>
        /// Retrieves one item from repository
        /// </summary>
        /// <param name="id">Element id</param>
        /// <returns>Element that matches the id</returns>
        T Get(int id);

        /// <summary>
        /// Retrieves all items from repository 
        /// </summary>
        /// <returns>Repository elements list</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Add <see cref="item"/> to repository
        /// </summary>
        /// <param name="item">New item</param>
        /// <returns></returns>
        bool Add(T item);

        /// <summary>
        /// Delete <see cref="item"/> from repository
        /// </summary>
        /// <param name="item">Deleted item</param>
        /// <returns></returns>
        bool Delete(T item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool Edit(T item);
    }
}