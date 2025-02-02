using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VTESTournamentBackend.Data;

namespace VTESTournamentBackend.Table.Delete
{
    [Route("api/Table")]
    [ApiController]
    public class DeleteTable : ControllerBase
    {
        private readonly DataContext _context;

        public DeleteTable(DataContext context)
        {
            _context = context;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Data.Table>> Delete(int id)
        {
            var table = _context.Table.Find(id);
            _context.Remove(table);
            _context.SaveChanges();

            return Ok(table);
        }
    }
}
