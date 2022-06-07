using System.IO;
using System.Threading.Tasks;
using Kolokwium2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Kolokwium2.Controllers
{
    [Route("api/album")]
    [ApiController]
    public class AlbumContoller : ControllerBase
    {
        private readonly IDbService _dbService;

        public AlbumContoller(IDbService dbService)
        {
            _dbService = dbService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAlbum(int id)
        {
            try
            {
                var album = await _dbService.GetAlbum(id);
                return Ok(album);
            }
            catch (SqlException)
            {
                return Unauthorized("server is busy");
            }
            catch (FileNotFoundException)
            {
                return NotFound("doctor not found");
            }
        }
    }
}