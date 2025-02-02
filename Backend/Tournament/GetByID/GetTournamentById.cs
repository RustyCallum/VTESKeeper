using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VTESTournamentBackend.Data;

namespace VTESTournamentBackend.Tournament.GetByID
{
    [Route("api/Tournament")]
    [ApiController]
    public class GetTournamentById : ControllerBase
    {
        private readonly DataContext _context;

        public GetTournamentById(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Data.Tournament>> GetTournament(int id)
        {
            return Ok(await _context.Tournament.FindAsync(id));
        }
    }
}
