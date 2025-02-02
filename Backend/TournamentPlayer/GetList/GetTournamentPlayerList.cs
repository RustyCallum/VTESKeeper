using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using VTESTournamentBackend.Data;
using VTESTournamentBackend.Player.GetByID;

namespace VTESTournamentBackend.TournamentPlayer.GetList
{
    [Route("api/Tournament/{tournamentId}/Player")]
    [ApiController]
    public class GetTournamentPlayerList : ControllerBase
    {
        List<GetTournamentPlayerResponse> returnablePlayerList = new List<GetTournamentPlayerResponse>();
        private readonly DataContext _context;

        public GetTournamentPlayerList(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get(int tournamentId)
        {
            var player = _context.TournamentPlayer.Where(p => p.TournamentId == tournamentId).Select(x => new GetTournamentPlayerResponse
            {
                Id = x.Id,
                Deck = x.Deck,
                FirstName = x.Player.FirstName,
                LastName = x.Player.LastName,
                City = x.Player.City,
                Vekn = x.Player.Vekn,
                Player = x.Player
            }).ToList();
            return Ok(player);
        }
    }
}
