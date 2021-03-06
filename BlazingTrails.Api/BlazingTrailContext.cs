using BlazingTrails.Api.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazingTrails.Api
{
    public class BlazingTrailContext : DbContext
    {
        public BlazingTrailContext(DbContextOptions<BlazingTrailContext> options) : base(options)
        {

        }

        public DbSet<Trail> Trails => Set<Trail>();
        public DbSet<Waypoint> Waypoints => Set<Waypoint>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new TrailConfig());
            modelBuilder.ApplyConfiguration(new WaypointConfig());
        }
    }
}
