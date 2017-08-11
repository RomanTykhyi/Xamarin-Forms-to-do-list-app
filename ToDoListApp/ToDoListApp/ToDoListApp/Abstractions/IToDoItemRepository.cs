using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListApp.Models;

namespace ToDoListApp.Abstractions
{
    public interface IToDoItemRepository
    {
        Task<List<ToDoItem>> GetAllAsync();
        Task<int> DeleteItemAsync(ToDoItem item);
        Task<List<ToDoItem>> GetNotDoneItems();
        Task<ToDoItem> GetItemAsync(int id);
        Task<int> SaveItemAsync(ToDoItem item);
    }
}
