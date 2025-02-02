using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VTESTournamentBackend.Data;

namespace VTESTournamentBackend.Player.Create
{
    [Route("api/Player")]
    [ApiController]
    public class CreatePlayer : ControllerBase
    {
        private readonly DataContext _context;

        public CreatePlayer(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Data.Player>> Post(CreatePlayerRequest player)
        {
            var newPlayer = new Data.Player
            {
                FirstName = player.FirstName,
                LastName = player.LastName,
                City = player.City,
                Vekn = player.Vekn,
                //CreatedDateTime = DateTime.Now
            };
            _context.Player.Add(newPlayer);
            await _context.SaveChangesAsync();
            return Ok(newPlayer);
        }
    }
}
