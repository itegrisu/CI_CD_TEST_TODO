using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CI_CD_TEST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private static List<Todo> _todos = new List<Todo>
        {
            new Todo { Id = 1, Name = "Sample Todo 1", IsComplete = false },
            new Todo { Id = 2, Name = "Sample Todo 2", IsComplete = true }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Todo>> GetTodos()
        {
            if (!_todos.Any())
            {
                return NotFound("No todos found.");
            }
            return Ok(_todos);
        }

        [HttpPost]
        public ActionResult<Todo> CreateTodo([FromBody] Todo newTodo)
        {
            Todo todo = new()
            {
                Id = _todos.Any() ? _todos.Max(t => t.Id) + 1 : 1,
                Name = newTodo.Name,
                IsComplete = newTodo.IsComplete
            };
            _todos.Add(todo);
            return CreatedAtAction(nameof(GetTodos), new { id = todo.Id }, todo);
        }

        [HttpPut]
        public ActionResult<Todo> UpdateTodo([FromBody] Todo updatedTodo)
        {
            var updatedEntity = _todos.FirstOrDefault(x => x.Id == updatedTodo.Id);
            if (updatedEntity == null)
            {
                return NotFound($"Todo with ID {updatedTodo.Id} not found.");
            }

            updatedEntity.Name = updatedTodo.Name;
            updatedEntity.IsComplete = updatedTodo.IsComplete;

            return Ok(updatedEntity);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTodo(int id)
        {
            var todo = _todos.FirstOrDefault(t => t.Id == id);
            if (todo == null)
            {
                return NotFound($"Todo with ID {id} not found.");
            }

            _todos.Remove(todo);
            return NoContent();
        }


    }
}
