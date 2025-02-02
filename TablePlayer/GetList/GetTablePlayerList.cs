using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VTESTournamentBackend.Data;
using VTESTournamentBackend.TournamentPlayer;

namespace VTESTournamentBackend.TablePlayer.GetList
{
    [Route("api/Tournament/{TournamentId}/Table/TablePlayer")]
    [ApiController]
    public class GetTablePlayerList : ControllerBase
    {
        private readonly DataContext _context;

        public GetTablePlayerList(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Data.TablePlayer>>> Get(int TournamentId)
        {
            var player = _context.TablePlayer.Select(x => new GetTablePlayerResponse
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
            }).ToList();
            return Ok(player);
        }
    }
}
