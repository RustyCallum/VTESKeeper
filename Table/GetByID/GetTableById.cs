using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VTESTournamentBackend.Data;

namespace VTESTournamentBackend.Table.GetByID
{
    [Route("api/Tournament/{tournamentId}/Table/")]
    [ApiController]
    public class GetTableById : ControllerBase
    {
        private readonly DataContext _context;

        public GetTableById(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Data.Table>> GetTable(int id)
        {
            return Ok(await _context.Table.FindAsync(id));
        }
    }
}
