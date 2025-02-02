using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VTESTournamentBackend.Data;
using VTESTournamentBackend.Player.Create;

namespace VTESTournamentBackend.Tournament.Create
{
    [Route("api/Tournament")]
    [ApiController]
    public class CreateTournament : ControllerBase
    {
        private readonly DataContext _context;

        public CreateTournament(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Data.Tournament>> Post(CreateTournamentRequest tournament)
        {
            var newTournament = new Data.Tournament
            {
                Name = tournament.Name,
                City = tournament.City,
                Date = tournament.Date,
                //CreatedDateTime = DateTime.Now
            };
            _context.Tournament.Add(newTournament);
            await _context.SaveChangesAsync();
            return Ok(newTournament);
        }
    }
}
