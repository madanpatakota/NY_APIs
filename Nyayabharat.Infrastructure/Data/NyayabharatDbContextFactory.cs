using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Nyayabharat.Infrastructure.Data
{
    public class NyayabharatDbContextFactory
        : IDesignTimeDbContextFactory<NyayabharatDbContext>
    {
        public NyayabharatDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<NyayabharatDbContext>();

            optionsBuilder.UseSqlServer(
                "Server=DESKTOP-1VJDAUH\\SQLEXPRESS01;Database=NyayabharatDB;Trusted_Connection=True;TrustServerCertificate=True;");

            return new NyayabharatDbContext(optionsBuilder.Options);
        }
    }
}