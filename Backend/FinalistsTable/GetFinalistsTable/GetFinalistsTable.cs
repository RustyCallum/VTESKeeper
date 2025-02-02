using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VTESTournamentBackend.Data;
using VTESTournamentBackend.TablePlayer.GetList;

namespace VTESTournamentBackend.FinalistsTable.GetFinalistsTable
{
    [Route("api/Tournament/{TournamentId}/Table/TopPlayers")]
    [ApiController]
    public class GetFinalistsTable : ControllerBase
    {
        private readonly DataContext _context;

        public GetFinalistsTable(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Data.TablePlayer>>> Get(int TournamentId)
        {
            var finalists = _context.TablePlayer.Where(x => x.Table.Round == 4).Select(x => new GetTablePlayerResponse
            {
                Id = x.Id,
                VP = x.VP,
                GW = x.GW,
                Seat = x.Seat,
                TableNumber = x.Table.TableNumber,
                PlayerId = x.PlayerId,
                TableId = x.TableId,
                FirstName = x.Player.FirstName,
                LastName = x.Player.LastName,
            }).OrderBy(x => x.Seat).ToList();

            return Ok(finalists);
        }
    }
}
