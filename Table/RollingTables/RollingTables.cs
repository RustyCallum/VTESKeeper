using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VTESTournamentBackend.Data;
using VTESTournamentBackend.Player.Create;

namespace VTESTournamentBackend.Table.RollingTables
{
    [Route("api/Tournament/{tournamentId}/Table")]
    [ApiController]
    public class RollingTables : ControllerBase
    {
        private readonly DataContext _context;

        public RollingTables(DataContext context)
        {
            _context = context;
        }

        internal int CalculateTables(int tournamentId, int? playerCount)
        {
            int playerAmount = 0;

            if (playerCount == null)
            {
                playerAmount = _context.TournamentPlayer.Count(p => p.TournamentId == tournamentId);
            }

            else
            {
                playerAmount = (int)playerCount;
            }

            int oddTableAmount = playerAmount / 5;
            int evenTableAmount = 0;

            int mod = playerAmount % 5;

            int tableAmount = 0;

            if (oddTableAmount == 0)
            {
                if (playerAmount != 4)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                if (mod == 1 && oddTableAmount == 1 || mod == 2 && oddTableAmount == 1)
                {
                    return 1;
                }
                else if (mod == 1 && oddTableAmount >= 3)
                {
                    oddTableAmount -= 3;
                    evenTableAmount += 4;
                    tableAmount = oddTableAmount + evenTableAmount;
                    return tableAmount;
                }
                else if (mod == 2 && oddTableAmount >= 2)
                {
                    oddTableAmount -= 2;
                    evenTableAmount += 3;
                    tableAmount = oddTableAmount + evenTableAmount;
                    return tableAmount;
                }
                else if (mod == 3 && oddTableAmount >= 1)
                {
                    oddTableAmount -= 1;
                    evenTableAmount += 2;
                    tableAmount = oddTableAmount + evenTableAmount;
                    return tableAmount;
                }
                else if (mod == 4)
                {
                    evenTableAmount += 1;
                    tableAmount = oddTableAmount + evenTableAmount;
                    return tableAmount;
                }
                else
                {
                    return oddTableAmount;
                }
            }
        }

        [HttpPost]
        public async Task<ActionResult<Data.Table>> Post(int tournamentId, int? playerAmount)
        {
            int amountOfTables = CalculateTables(tournamentId, playerAmount);

            for(int i = 0; i < amountOfTables; i++)
            {
                var newTable = new Data.Table
                {
                    TournamentId = tournamentId,
                    Round = 1,
                    TableNumber = i
                };
                _context.Table.Add(newTable);
            }
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
