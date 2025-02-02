using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VTESTournamentBackend.Data;

namespace VTESTournamentBackend.TablePlayer.GetByID
{
    [Route("api/Tournament/{TournamentId}/Table/{TableId}/")]
    [ApiController]
    public class GetTablePlayerById : ControllerBase
    {
        private readonly DataContext _context;

        public GetTablePlayerById(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Data.TablePlayer>> GetTablePlayer(int id)
        {
            return Ok(await _context.TablePlayer.FindAsync(id));
        }
    }
}
