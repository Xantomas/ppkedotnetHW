using Microsoft.EntityFrameworkCore;

namespace SensorYapi.Models
{
    public class SensorContext : DbContext
    {
        public SensorContext(DbContextOptions<SensorContext> options) : base(options)
        {
        }
        public DbSet<Sensor> Sensors { get; set; }
    }

}
