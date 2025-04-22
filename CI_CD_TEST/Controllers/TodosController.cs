using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CI_CD_TEST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly TodoContext _context;

        public TodosController(TodoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Todo>> GetTodos()
        {
          var todos = _context.Todo.ToList();
            if (todos == null || !todos.Any())
            {
                return NotFound("No todos found.");
            }
            return Ok(todos);
        }

        [HttpPost]
        public ActionResult<Todo> CreateTodo([FromBody] Todo newTodo)
        {
           Todo todo = new()
           {
               Name = newTodo.Name,
               IsComplete = newTodo.IsComplete
           };
            _context.Todo.Add(todo);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetTodos), new { id = todo.Id }, todo);
        }            
    }
}
