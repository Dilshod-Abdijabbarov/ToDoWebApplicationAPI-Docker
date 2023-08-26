using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDoWebApplication.Services.DTOs.TaskBaseDTOs;
using ToDoWebApplication.Services.IServices;

namespace ToDoWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskBaseService taskBaseService;
        public TasksController(ITaskBaseService taskBaseService)
        {
            this.taskBaseService = taskBaseService;
        }

        [HttpGet("{id}")]
        public async ValueTask<IActionResult> Get([FromRoute] int id) =>
           Ok(await taskBaseService.GetAsync(c => c.Id == id));

        [HttpGet("GetAll")]
        public async ValueTask<IActionResult> GetAll() =>
            Ok(await taskBaseService.GetAllAsync());

        [HttpPost]
        public async ValueTask<IActionResult> Create(
                     [FromBody] TaskBaseForCreationDTO taskBaseForCreation)=>
            Ok(await taskBaseService.CreateAsync(taskBaseForCreation));

        [HttpPut]
        public async ValueTask <IActionResult> Update([FromQuery]int id,
                     [FromBody] TaskBaseForCreationDTO taskBaseForCreation)=>
            Ok(await taskBaseService.UpdateAsync(id, taskBaseForCreation));

        [HttpDelete("{id}")]
        public async ValueTask <IActionResult> Delete([FromRoute]int id)=>
            Ok(await taskBaseService.DeleteAsync(id));
    }
}
