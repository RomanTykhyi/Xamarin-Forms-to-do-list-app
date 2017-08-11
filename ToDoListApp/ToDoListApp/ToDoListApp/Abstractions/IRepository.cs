using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListApp.Abstractions
{
    public interface IRepository<TEntity> where TEntity: class
    {
        Task<List<TEntity>> GetAllAsync();
        Task<int> DeleteItemAsync(TEntity item);
    }
}
