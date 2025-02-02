using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VTESTournamentBackend.Data;

namespace VTESTournamentBackend.TournamentPlayer.GetByID
{
    [Route("api/Tournament/{TournamentId}/Player")]
    [ApiController]
    public class GetTournamentPlayerById : ControllerBase
    {
        private readonly DataContext _context;

        public GetTournamentPlayerById(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{PlayerId}")]
        public async Task<ActionResult<Data.TournamentPlayer>> GetTournamentPlayer(int PlayerId)
        {
            var Player = _context.TournamentPlayer.Where(p => p.PlayerId == PlayerId).Select(x => new GetTournamentPlayerResponse
            {
                Id = x.Id,
                Deck = x.Deck,
                FirstName = x.Player.FirstName, 
                LastName = x.Player.LastName,
                City = x.Player.City,
                Vekn = x.Player.Vekn,
                Player = x.Player,
            });

            return Ok(Player);
        }
    }
}
