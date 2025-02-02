using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VTESTournamentBackend.Data;

namespace VTESTournamentBackend.Player.Delete
{
    [Route("api/Player/")]
    [ApiController]
    public class DeletePlayer : ControllerBase
    {
        private readonly DataContext _context;

        public DeletePlayer(DataContext context)
        {
            _context = context;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Data.Player>> Delete(int id)
        {
            var player =  _context.Player.Find(id);
            _context.Remove(_context.Player.Find(id));
            _context.SaveChanges();

            return Ok(player);
        }
    }
}
