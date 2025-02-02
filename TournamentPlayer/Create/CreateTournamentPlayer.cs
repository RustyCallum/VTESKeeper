using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VTESTournamentBackend.Data;
using VTESTournamentBackend.TournamentPlayer.Create;
 
namespace VTESTournamentBackend.TournamentPlayer.Create
{
    [Route("api/Tournament/{tournamentId}/Player/{playerId}")]
    [ApiController]
    public class CreateTournamentPlayer : ControllerBase
    {
        private readonly DataContext _context;

        public CreateTournamentPlayer(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Data.TournamentPlayer>> Post(CreateTournamentPlayerRequest tournamentPlayer, int tournamentId, int playerId)
        {
            var newTournamentPlayer = new Data.TournamentPlayer
            {
                Deck = tournamentPlayer.Deck,
                TournamentId = tournamentId,
                PlayerId = playerId
                //CreatedDateTime = DateTime.Now
            };
            _context.TournamentPlayer.Add(newTournamentPlayer);
            await _context.SaveChangesAsync();
            return Ok(newTournamentPlayer);
        }
    }
}
