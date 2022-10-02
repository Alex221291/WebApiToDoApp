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

        [Route("GetAllToDoes")]
        [HttpGet]
        public async Task<IEnumerable<ToDoViewModel?>> GetAllToDoes()
        {
            return await _toDoService.GetAllAsync();
        }

        [Route("GetCompletedToDoes")]
        [HttpGet]
        public async Task<IEnumerable<ToDoViewModel?>> GetCompletedToDoes()
        {
            return await _toDoService.GetCompletedToDoesAsync();
        }

        [Route("GetUncompletedToDoes")]
        [HttpGet]
        public async Task<IEnumerable<ToDoViewModel?>> GetUncompletedToDoes()
        {
            return await _toDoService.GetUncompletedToDoesAsync();
        }

        [Route("GetQuantityToDoes")]
        [HttpGet]
        public async Task<int> GetQuantityToDoes()
        {
            return await _toDoService.QuantityToDoes();
        }

        [Route("GetQuantityCompletedToDoes")]
        [HttpGet]
        public async Task<int> GetQuantityCompletedToDoes()
        {
            return await _toDoService.QuantityCompletedToDoes();
        }

        [Route("GetQuantityUncompletedToDoes")]
        [HttpGet]
        public async Task<int> GetQuantityUncompletedToDoes()
        {
            return await _toDoService.QuantityUncompletedToDoes();
        }

        [HttpPost]
        public async Task<ObjectResult> PostToDo(ToDoViewModel toDo)
        {
            var result = await _toDoService.CreateAsync(toDo);

            if (result != null)
                return Ok(toDo);
            return BadRequest(toDo);
        }

        [HttpPut]
        public async Task<ObjectResult> PutToDo(UpdateToDoViewModel updateToDo)
        {
            var result = await _toDoService.EditAsync(updateToDo);

            if (result != null)
                return Ok(result);
            return BadRequest(updateToDo);
        }

        [HttpDelete]
        public async Task<ObjectResult> DeleteToDo(int id)
        {
            var result = await _toDoService.DeleteAsync(id);

            if (result != null)
                return Ok(result);
            return NotFound(id);
        }
    }
}
