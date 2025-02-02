using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VTESTournamentBackend.Data;

namespace VTESTournamentBackend.Player.GetByID
{
    [Route("api/Player/")]
    [ApiController]
    public class GetPlayerById : ControllerBase
    {
        private readonly DataContext _context;

        public GetPlayerById(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Data.Player>> GetPlayer(int id)
        {
            return Ok(await _context.Player.FindAsync(id));
        }
    }
}
