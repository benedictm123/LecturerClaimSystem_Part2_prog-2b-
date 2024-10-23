using Microsoft.EntityFrameworkCore;

namespace ClaimSystem.Models
{
    public class ClaimSystemDBContext : DbContext
    {
        public DbSet<Claim> claims {  get; set; }

        public ClaimSystemDBContext(DbContextOptions<ClaimSystemDBContext> options)
            :base(options) { 
        }
        
    }
}
