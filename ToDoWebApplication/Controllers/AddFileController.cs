using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDoWebApplication.Services.DTOs.AddFileDTOs;
using ToDoWebApplication.Services.IServices;

namespace ToDoWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddFileController : ControllerBase
    {
        private readonly IAddFileService addFileService;
        public AddFileController(IAddFileService addFileService)
        {
            this.addFileService = addFileService;
        }

        [HttpGet("{id}")]
        public async ValueTask<IActionResult> Get([FromRoute] int id) =>
           Ok(await addFileService.GetAsync(c => c.Id == id));

        [HttpGet("GetAll")]
        public async ValueTask<IActionResult> GetAll() =>
            Ok(await addFileService.GetAllAsync());

        [HttpPost]
        public async ValueTask<IActionResult> Create(
                     [FromBody] AddFileForCreationDTOs fileForCreationDTO) =>
            Ok(await addFileService.CreateAsync(fileForCreationDTO));

        [HttpPut]
        public async ValueTask<IActionResult> Update([FromQuery] int id,
                     [FromBody] AddFileForCreationDTOs fileForCreationDTO) =>
            Ok(await addFileService.UpdateAsync(id, fileForCreationDTO));

        [HttpDelete("{id}")]
        public async ValueTask<IActionResult> Delete([FromRoute] int id) =>
            Ok(await addFileService.DeleteAsync(id));
    }
}
