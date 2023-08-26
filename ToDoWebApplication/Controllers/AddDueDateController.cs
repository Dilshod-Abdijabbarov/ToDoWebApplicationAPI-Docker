using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDoWebApplication.Services.DTOs.AddDueDateDTOs;
using ToDoWebApplication.Services.IServices;

namespace ToDoWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddDueDateController : ControllerBase
    {
        private readonly IAddDueDateService addDueDateService;
        public AddDueDateController(IAddDueDateService addDueDateService)
        {
            this.addDueDateService = addDueDateService;
        }

        [HttpGet("{id}")]
        public async ValueTask<IActionResult> Get([FromRoute] int id) =>
           Ok(await addDueDateService.GetAsync(c => c.Id == id));

        [HttpGet("GetAll")]
        public async ValueTask<IActionResult> GetAll() =>
            Ok(await addDueDateService.GetAllAsync());

        [HttpPost]
        public async ValueTask<IActionResult> Create(
                     [FromBody] AddDueDateForCreationDTO dueDateForCreationDTO) =>
            Ok(await addDueDateService.CreateAsync(dueDateForCreationDTO));

        [HttpPut]
        public async ValueTask<IActionResult> Update([FromQuery] int id,
                     [FromBody] AddDueDateForCreationDTO dueDateForCreationDTO) =>
            Ok(await addDueDateService.UpdateAsync(id,dueDateForCreationDTO));

        [HttpDelete("{id}")]
        public async ValueTask<IActionResult> Delete([FromRoute] int id) =>
            Ok(await addDueDateService.DeleteAsync(id));
    }
}
