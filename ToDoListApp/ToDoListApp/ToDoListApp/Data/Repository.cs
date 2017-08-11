using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListApp.Abstractions;
using ToDoListApp.Models;

namespace ToDoListApp
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        public Repository(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<T>().Wait();
            _table = _database.Table<T>();
        }

        public Task<List<T>> GetAllAsync()
        {
            return _table.ToListAsync();
        }

        public Task<int> DeleteItemAsync(T item)
        {
            return _database.DeleteAsync(item);            
        }   
                               
        protected readonly SQLiteAsyncConnection _database;
        protected readonly AsyncTableQuery<T> _table;
    }
}
