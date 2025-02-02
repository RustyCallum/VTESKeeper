using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VTESTournamentBackend.Data;

namespace VTESTournamentBackend.TournamentPlayer.TournamentPlayerDeckDownload
{
    [Route("api/Tournament/{TournamentId}/Player/Deck")]
    [ApiController]
    public class GetTournamentPlayerDeck : ControllerBase
    {
        private readonly DataContext _context;

        public GetTournamentPlayerDeck(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{TournamentPlayerId}")]
        public async Task<ActionResult<Data.TournamentPlayer>> GetDeck(int TournamentPlayerId)
        {
            var PlayerDeck = _context.TournamentPlayer.Where(p => p.Id == TournamentPlayerId).Select(x => x.Deck).FirstOrDefault();
            var PlayerFirstName = _context.TournamentPlayer.Where(p => p.Id == TournamentPlayerId).Select(x => x.Player.FirstName);
            var PlayerLastName = _context.TournamentPlayer.Where(p => p.Id == TournamentPlayerId).Select(x => x.Player.LastName);

            using (var fs = new FileStream($"Deck - {PlayerFirstName} {PlayerLastName}", FileMode.Create, FileAccess.Write))
            {
                fs.Write(PlayerDeck, 0, PlayerDeck.Length);
                var deck = new StreamContent(fs);
                deck.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("text/plain");
                deck.Headers.ContentLength = 10000;
                return File(PlayerDeck, "text/plain", $"przyklad.txt");
            }
        }
    }
}
