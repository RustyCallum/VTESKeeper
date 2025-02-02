using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VTESTournamentBackend.Data;
using VTESTournamentBackend.TablePlayer.Update;
using System.IO;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace VTESTournamentBackend.TournamentPlayer.Update
{
    [Route("api/Tournament/{TournamentId}/TournamentPlayer")]
    [ApiController]
    public class UpdateTournamentPlayer : ControllerBase
    {
        private readonly DataContext _context;

        public UpdateTournamentPlayer(DataContext context)
        {
            _context = context;
        }

        [HttpPut]
        public async Task<ActionResult<List<Data.TournamentPlayer>>> Put([FromForm]UpdateTournamentPlayerRequest updateTournamentPlayer)
        {
            IFormFile deck = Request.Form.Files.FirstOrDefault(); 

            var dbTournamentPlayer = await _context.TournamentPlayer.FindAsync(updateTournamentPlayer.Id);
            if (dbTournamentPlayer == null)
            {
                return BadRequest("Player not found");
            }

            using var fileStream = deck.OpenReadStream();
            byte[] deckInBytes = new byte[deck.Length];
            fileStream.Read(deckInBytes, 0, (int)deck.Length);

            dbTournamentPlayer.Id = updateTournamentPlayer.Id;
            dbTournamentPlayer.Deck = deckInBytes;

            await _context.SaveChangesAsync();

            return Ok(dbTournamentPlayer);
        }
    }
}
