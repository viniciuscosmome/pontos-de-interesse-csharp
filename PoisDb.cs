using Microsoft.EntityFrameworkCore;

namespace PontosDeInteresse
{
    public class PoisDb(DbContextOptions<PoisDb> options) : DbContext(options)
    {
        public DbSet<PoisModel> PoisModel => Set<PoisModel>();
    }
}
