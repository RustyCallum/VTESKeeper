using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using VTESTournamentBackend.Data;
using VTESTournamentBackend.TournamentPlayer;

namespace VTESTournamentBackend.TablePlayer.Create
{
    [Route("api/Tournament/{tournamentId}/Table/TablePlayer")]
    [ApiController]
    public class CreateTablePlayer : ControllerBase
    {
        int TableCount = 0;

        private readonly DataContext _context;

        public CreateTablePlayer(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> Post(int tournamentId, int? playerAmount)
        {
            int amountOfTables = CalculateTables(tournamentId, playerAmount);
            for(int j = 1; j <= 3; j++)
            {
                for (int i = 1; i <= amountOfTables; i++)
                {
                    var newTable = new Data.Table
                    {
                        TournamentId = tournamentId,
                        Round = j,
                        TableNumber = i
                    };
                    _context.Table.Add(newTable);
                    await _context.SaveChangesAsync();
                }
            }

            var players = _context.TournamentPlayer.Where(p => p.TournamentId == tournamentId).ToList();

            int tablesAmount = _context.Table.Count(p => p.TournamentId == tournamentId);

            List<Data.Table> tables = _context.Table.Where(p => p.TournamentId == tournamentId).ToList();

            var shuffledPlayer = players.OrderBy(x => Guid.NewGuid()).ToList();

            for (int i = 1; i <= 3; i++)
            {
                RollPlayers(players, tables, i);
            }
            await _context.SaveChangesAsync();
            return Ok();
        }

        internal void RollPlayers(List<Data.TournamentPlayer> players, List<Data.Table> tables, int roundNumber)
        {
            var shuffledPlayers = players.OrderBy(x => Guid.NewGuid()).ToList();

            var roundTable = tables.Where(p => p.Round ==  roundNumber).ToList();

            foreach (Data.TournamentPlayer player in shuffledPlayers)
            {
                TableCount++;
                
                if (TableCount == roundTable.Count)
                {
                    TableCount = 0;
                }

                int playersInTable = _context.TablePlayer.Count(p => p.TableId == roundTable[TableCount].Id);

                var newPlayer = new Data.TablePlayer
                {
                    VP = 0,
                    GW = 0,
                    Seat = _context.TablePlayer.Where(p => p.TableId == roundTable[TableCount].Id).Count() + 1,
                    TableId = roundTable[TableCount].Id,
                    PlayerId = player.PlayerId,
                };
                _context.TablePlayer.Add(newPlayer);
                _context.SaveChanges();
            }
        }

        internal void RollSubsequentPlayers(List<Data.TournamentPlayer> players, List<Data.Table> tables, int roundNumber)
        {
            // Pobieramy wyniki graczy z poprzednich rund
            var playersWithScores = players
                .Select(player => new
                {
                    Player = player,
                    TotalVP = _context.TablePlayer
                        .Where(tp => tp.PlayerId == player.PlayerId)
                        .Sum(tp => tp.VP),
                    TotalGW = _context.TablePlayer
                        .Where(tp => tp.PlayerId == player.PlayerId)
                        .Sum(tp => tp.GW)
                })
                .OrderByDescending(p => p.TotalGW)
                .ThenByDescending(p => p.TotalVP)
                .Select(p => p.Player)
                .ToList();

            var roundTables = tables.Where(p => p.Round == roundNumber).ToList();

            TableCount = 0;

            foreach (var player in playersWithScores)
            {
                int currentTablePlayers = _context.TablePlayer.Count(p => p.TableId == roundTables[TableCount].Id);

                if (currentTablePlayers == 5)
                {
                    TableCount++;
                }

                if (TableCount == roundTables.Count)
                {
                    TableCount = 0;
                }

                var newPlayer = new Data.TablePlayer
                {
                    VP = 0,
                    GW = 0,
                    Seat = currentTablePlayers + 1,
                    TableId = roundTables[TableCount].Id,
                    PlayerId = player.PlayerId,
                };

                _context.TablePlayer.Add(newPlayer);
            }

            _context.SaveChanges();
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
    }
}
