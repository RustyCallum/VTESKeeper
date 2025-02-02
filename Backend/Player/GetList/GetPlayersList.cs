using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VTESTournamentBackend.Data;

namespace VTESTournamentBackend.Player.Get
{
    [Route("api/Player")]
    [ApiController]
    public class GetPlayersList : ControllerBase
    {
        private readonly DataContext _context;

        public GetPlayersList(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Data.Player>>> Get()
        {
            return Ok(await _context.Player.ToListAsync());
        }
    }
}
