using System.Threading.Tasks;
using Kolokwium2.Models;
using Kolokwium2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Kolokwium2.Controllers
{
    [Route("api/musician")]
    [ApiController]
    public class MusicianContoller : ControllerBase
    {
        private readonly IDbService _dbService;

        public MusicianContoller(IDbService dbService)
        {
            _dbService = dbService;
        }
        [HttpDelete]
        public async Task<ActionResult> RemoveMusician(int id)
        {
            var result = await _dbService.DeleteMusician(id);
            switch (result)
            {
                case 0: return Ok();
                case 1: return NotFound("Musician not found");
                case 2: return BadRequest("Musicians has track on a album");
                case 3: return Problem("Server is busy");
                default: return Unauthorized();
            }
        }
    }
}