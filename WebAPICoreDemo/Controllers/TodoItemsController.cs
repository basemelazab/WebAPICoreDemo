using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebAPICoreDemo.Models;

namespace WebAPICoreDemo.Controllers
{
    [Route("api/TodoItems")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        List<TodoItems> todoItems= new List<TodoItems>();
        public TodoItemsController()
        {
            todoItems.Add(new TodoItems
            {
                Id = 1,
                Name = "Item1",
                IsCompleted = false,
            });
            todoItems.Add(new TodoItems
            {
                Id = 2,
                Name = "Item2",
                IsCompleted = true,
            });
        }
        [HttpGet]
        public List<TodoItems> Get()
        {
            return todoItems;
        }
        [HttpGet("{id}")]
        public TodoItems GetById(int id)
        {
            return todoItems.FirstOrDefault(x => x.Id == id);
        }
        [HttpPost]
        public ActionResult Create([FromBody] TodoItems todo)
        {
            todoItems.Add(todo);
            return CreatedAtAction("GetById", new {id=todo.Id}, todoItems);
        }
        [HttpPut]
        public ActionResult Update(int id, [FromBody] TodoItems todo)
        {
            foreach (var item in todoItems)
            {
                if(item.Id == id)
                {
                    item.Name = todo.Name;
                }
            }
            return Ok();
        }
    }
}
