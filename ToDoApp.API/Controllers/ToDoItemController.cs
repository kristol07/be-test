using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.API.Models;
using ToDoApp.API.Services;

namespace ToDoApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemController : ControllerBase
    {
        private IRepository _repo;
        public ToDoItemController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItem>> GetAsync(long id)
        {
            var item = await _repo.GetAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpGet]
        public async Task<ActionResult<List<ToDoItem>>> GetAllAsync()
        {
            var items = await _repo.GetAllAsync();
            return Ok(items);
        }

        [HttpPost]
        public async Task<ActionResult<ToDoItem>> AddNewItemAsync(ToDoItem item)
        {
            if (string.IsNullOrEmpty(item.Id.ToString()))
            {
                return BadRequest(new Dictionary<string, string>() { { "message", "item id is required" } });
            }

            if(_repo.GetAsync(item.Id).Result != null)
            {
                return BadRequest(new Dictionary<string, string>() { { "message", "item id conflict" } });
            }

            await _repo.AddAsync(item);

            return Ok(item);
        }
    }
}

