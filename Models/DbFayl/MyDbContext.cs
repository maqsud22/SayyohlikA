using Microsoft.EntityFrameworkCore;


namespace SayyohlikA.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public DbSet<Davlat> Davlatlar { get; set; }
        public DbSet<Shahar> Shaharlar { get; set; }
        public DbSet<Xaridor> Xaridorlar { get; set; }
        public DbSet<Tarjimon> Tarjimonlar { get; set; }
        public DbSet<Yangiliklar> Yangiliklar { get; set; }
        public DbSet<RequestLog> RequestLogs { get; set; }

    }
}
