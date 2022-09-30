using Microsoft.AspNetCore.Mvc;
using WebApiToDoApp.Services;
using WebApiToDoApp.ViewModels;

namespace WebApiToDoApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _toDoService;

        public ToDoController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        [HttpGet]
        public async Task<IEnumerable<ToDoViewModel?>> Get()
        {
            return await _toDoService.GetAllAsync();
        }

        [HttpPost]
        public async Task<ObjectResult> Post(ToDoViewModel toDo)
        {
            var result = await _toDoService.CreateAsync(toDo);

            if (result != null)
                return Ok(toDo);
            return BadRequest(toDo);
        }

        [HttpPut]
        public async Task<ObjectResult> Put(UpdateToDoViewModel updateToDo)
        {
            var result = await _toDoService.EditAsync(updateToDo);

            if (result != null)
                return Ok(result);
            return BadRequest(updateToDo);
        }

        [HttpDelete]
        public async Task<ObjectResult> Delete(int id)
        {
            var result = await _toDoService.DeleteAsync(id);

            if (result != null)
                return Ok(result);
            return NotFound(id);
        }
    }
}
