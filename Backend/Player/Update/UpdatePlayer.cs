using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VTESTournamentBackend.Data;

namespace VTESTournamentBackend.Player.Update
{
    [Route("api/Player")]
    [ApiController]
    public class UpdatePlayer : ControllerBase
    {
        private readonly DataContext _context;

        public UpdatePlayer(DataContext context)
        {
            _context = context;
        }

        [HttpPut]
        public async Task<ActionResult<List<Data.Player>>> Put(UpdatePlayerRequest updatePlayer)
        {
            var dbPlayer = await _context.Player.FindAsync(updatePlayer.Id);
            if (dbPlayer == null)
            {
                return BadRequest("Player not found");
            }

            dbPlayer.FirstName= updatePlayer.FirstName;
            dbPlayer.LastName= updatePlayer.LastName;
            dbPlayer.Vekn = updatePlayer.Vekn;

            await _context.SaveChangesAsync();

            return Ok(dbPlayer);
        }
    }
}
