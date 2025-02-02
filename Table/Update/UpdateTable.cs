using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VTESTournamentBackend.Data;
using VTESTournamentBackend.Player.Update;

namespace VTESTournamentBackend.Table.Update
{
    [Route("api/Table")]
    [ApiController]
    public class UpdateTable : ControllerBase
    {
        private readonly DataContext _context;

        public UpdateTable(DataContext context)
        {
            _context = context;
        }

        [HttpPut]
        public async Task<ActionResult<List<Data.Player>>> Put(UpdateTableRequest updateTable)
        {
            var dbTable = await _context.Table.FindAsync(updateTable.Id);
            if (dbTable == null)
            {
                return BadRequest("Player not found");
            }

            dbTable.TournamentId = updateTable.TournamentId;
            dbTable.Round = updateTable.Round;
            dbTable.TableNumber = updateTable.TableNumber;

            await _context.SaveChangesAsync();

            return Ok(dbTable);
        }
    }
}
