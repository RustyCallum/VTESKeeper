using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VTESTournamentBackend.Data;

namespace VTESTournamentBackend.Table.GetList
{
    [Route("api/Tournament/{tournamentId}/Table")]
    [ApiController]
    public class GetTableList : ControllerBase
    {
        private readonly DataContext _context;

        public GetTableList(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Data.Table>>> Get(int tournamentId)
        {
            return Ok(await _context.Table.Where(x => x.TournamentId == tournamentId).ToListAsync());
        }
    }
}
