using Microsoft.EntityFrameworkCore;

namespace PontosDeInteresse
{
    public class PoisDb : DbContext
    {
        public PoisDb(DbContextOptions<PoisDb> options) : base(options) {}
        public DbSet<PoisModel> PoisModel => Set<PoisModel>();
    }
}
