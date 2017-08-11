using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using ToDoListApp.Abstractions;
using ToDoListApp.Models;
using Xamarin.Forms;

namespace ToDoListApp.Data
{
    class ToDoItemsRepository : IToDoItemRepository
    {
        public ToDoItemsRepository() 
        {
            _database = new SQLiteAsyncConnection(DependencyService.Get<IFileHelper>().GetLocalFilePath("ToDoDBSQLite"));
            _database.CreateTableAsync<ToDoItem>().Wait();
            _table = _database.Table<ToDoItem>();
        }

        public Task<int> DeleteItemAsync(ToDoItem item)
        {
            return _database.DeleteAsync(item);
        }

        public Task<List<ToDoItem>> GetAllAsync()
        {
            return _table.ToListAsync();
        }

        public Task<ToDoItem> GetItemAsync(int id)
        {
            return _table.Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<List<ToDoItem>> GetNotDoneItems()
        {
            return _database.QueryAsync<ToDoItem>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public Task<int> SaveItemAsync(ToDoItem item)
        {
            if (item.ID != 0)
            {
                return _database.UpdateAsync(item);
            }
            else
            {
                return _database.InsertAsync(item);
            }
        }

        private readonly SQLiteAsyncConnection _database;
        private readonly AsyncTableQuery<ToDoItem> _table;
    }
}
