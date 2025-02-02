using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VTESTournamentBackend.Data;

namespace VTESTournamentBackend.Tournament.GetList
{
    [Route("api/Tournament")]
    [ApiController]
    public class GetTournamentList : ControllerBase
    {
        private readonly DataContext _context;

        public GetTournamentList(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Data.Tournament>>> Get()
        {
            return Ok(await _context.Tournament.ToListAsync());
        }
    }
}
