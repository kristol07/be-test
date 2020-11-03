using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.API.Models;

namespace ToDoApp.API.Services
{
    public class MemoryRepository : IRepository
    {
        private readonly Dictionary<long, ToDoItem> _dic = new Dictionary<long, ToDoItem>();

        public async Task AddAsync(ToDoItem model)
        {
            _dic[model.Id] = model;
        }

        public async Task<List<ToDoItem>> GetAllAsync()
        {
            return _dic.Values.ToList();
        }

        public async Task<ToDoItem> GetAsync(long id)
        {
            if(_dic.ContainsKey(id))
            {
                return _dic[id];
            }
            else
            {
                return null;
            }
        }
    }
}
