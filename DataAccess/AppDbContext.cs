using Microsoft.EntityFrameworkCore;

namespace GrpcCRUD.DataAccess
{
    public class AppDbContext :  DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<Equipament> Equipaments  { get; set; }
    }
}