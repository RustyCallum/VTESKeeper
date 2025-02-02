using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using VTESTournamentBackend.Data;
using VTESTournamentBackend.TablePlayer.GetBestTablePlayers;
using VTESTournamentBackend.TablePlayer.GetList;

namespace VTESTournamentBackend.FinalistsTable.GetBestTablePlayers
{
    [Route("api/Tournament/{TournamentId}/Table/TopPlayers")]
    [ApiController]
    public class CreateFinalistsTable : ControllerBase
    {
        private readonly DataContext _context;

        public CreateFinalistsTable(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<List<Data.TablePlayer>>> Post(int TournamentId)
        {
            List<GetBestTablePlayerListResponse> finalList = new List<GetBestTablePlayerListResponse>();

            var finalist = _context
                .TablePlayer
                .GroupBy(x => x.PlayerId)
                .Select(x => new
                {
                    PlayerId = x.Key,
                    VP = x.Sum(y => y.VP),
                    GW = x.Sum(y => y.GW)
                })
                .OrderByDescending(x => x.VP)
                .OrderByDescending(x => x.GW)
                .ToList()
                .Take(5)
                .ToList();

            var newTable = new Data.Table
            {
                TournamentId = TournamentId,
                Round = 4,
                TableNumber = 1
            };
            _context.Table.Add(newTable);
            await _context.SaveChangesAsync();

            for(int i = 1; i <= finalist.Count; i++)
            {
                var newPlayer = new Data.TablePlayer
                {
                    VP = 0,
                    GW = 0,
                    Seat = i,
                    TableId = newTable.Id,
                    PlayerId = finalist[i-1].PlayerId,
                };
                _context.TablePlayer.Add(newPlayer);
                await _context.SaveChangesAsync();

                var playerToReturn = new GetBestTablePlayerListResponse
                {
                    Id = newPlayer.Id,
                    VP = newPlayer.VP,
                    GW = newPlayer.GW,
                    Seat = newPlayer.Seat,
                    TableId = newTable.Id,
                    PlayerId = newPlayer.PlayerId,
                    FirstName = _context.Player.Where(x => x.Id == newPlayer.PlayerId).Select(x => x.FirstName).First().ToString(),
                    LastName = _context.Player.Where(x => x.Id == newPlayer.PlayerId).Select(x => x.LastName).First().ToString(),
                    Table = newPlayer.Table,
                };
                finalList.Add(playerToReturn);
            }

            await _context.SaveChangesAsync();
            return Ok(finalList);
        }
    }
}
