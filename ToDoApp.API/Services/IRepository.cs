using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.API.Models;

namespace ToDoApp.API.Services
{
    public interface IRepository
    {
        Task<ToDoItem> GetAsync(long id);
        Task AddAsync(ToDoItem model);
        Task<List<ToDoItem>> GetAllAsync();
    }
}
