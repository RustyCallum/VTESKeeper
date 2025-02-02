using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VTESTournamentBackend.Data;

namespace VTESTournamentBackend.Tournament.Delete
{
    [Route("api/Tournament")]
    [ApiController]
    public class DeleteTournament : ControllerBase
    {
        private readonly DataContext _context;

        public DeleteTournament(DataContext context)
        {
            _context = context;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Data.Tournament>> Delete(int id)
        {
            var tournament = _context.Tournament.Find(id);
            _context.Remove(tournament);
            _context.SaveChanges();

            return Ok(tournament);
        }
    }
}
