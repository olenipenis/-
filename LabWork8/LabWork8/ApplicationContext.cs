namespace LabWork8
{
    using Microsoft.EntityFrameworkCore;

    public class ApplicationContext : DbContext
    {
        public DbSet<Viewer> Viewers => Set<Viewer>();
        public DbSet<Ticket> Tickets => Set<Ticket>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //....
            optionsBuilder.UseSqlServer(
                "Initial Catalog:mssql;server:localhost;User Id:ispp55;Password:5502;TrustServerCertificate=True;"
                );
        }
    }
}
