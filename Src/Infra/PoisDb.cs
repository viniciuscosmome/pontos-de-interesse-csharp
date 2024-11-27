using Microsoft.EntityFrameworkCore;

namespace PontosDeInteresse.Src.infra
{
    public class PoisDb(DbContextOptions<PoisDb> options) : DbContext(options)
    {
        public DbSet<PoisModel> PoisModel => Set<PoisModel>();
    }
}
