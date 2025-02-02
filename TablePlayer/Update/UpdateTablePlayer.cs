using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VTESTournamentBackend.Data;
using VTESTournamentBackend.Player.Update;

namespace VTESTournamentBackend.TablePlayer.Update
{
    [Route("api/Tournament/{TournamentId}/Table/{TableId}")]
    [ApiController]
    public class UpdateTablePlayer : ControllerBase
    {
        private readonly DataContext _context;

        public UpdateTablePlayer(DataContext context)
        {
            _context = context;
        }

        [HttpPut]
        public async Task<ActionResult<List<Data.Player>>> Put(UpdateTablePlayerRequest updateTablePlayer)
        {
            var dbTablePlayer = await _context.TablePlayer.FindAsync(updateTablePlayer.Id);

            if (dbTablePlayer == null)
            {
                return BadRequest("Player not found");
            }

            dbTablePlayer.VP = updateTablePlayer.VP;
            dbTablePlayer.GW = updateTablePlayer.GW;
            dbTablePlayer.Seat = updateTablePlayer.Seat;
            dbTablePlayer.PlayerId = updateTablePlayer.PlayerId;
            dbTablePlayer.TableId = updateTablePlayer.TableId;


            await _context.SaveChangesAsync();

            return Ok(dbTablePlayer);
        }
    }
}
