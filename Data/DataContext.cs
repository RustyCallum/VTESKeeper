using Microsoft.EntityFrameworkCore;

namespace VTESTournamentBackend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) { }

        public DbSet<Player> Player => Set<Player>();
        public DbSet<Tournament> Tournament => Set<Tournament>();
        public DbSet<Table> Table => Set<Table>();
        public DbSet<TournamentPlayer> TournamentPlayer => Set<TournamentPlayer>();
        public DbSet<TablePlayer> TablePlayer => Set<TablePlayer>();
    }
}
