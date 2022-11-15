using Microsoft.EntityFrameworkCore;

namespace ProEventos.Data
{
    public class DbContextConfig : DbContext
    {
        public DbContextConfig(DbContextOptions<DbContextConfig> options) : base(options) { }
    }
}
