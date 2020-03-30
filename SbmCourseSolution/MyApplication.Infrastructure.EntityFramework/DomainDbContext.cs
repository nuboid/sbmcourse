using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using MyApplication.DomainModel;
using MyApplication.DomainModel.CustomerAggregate;
using MyApplication.DomainModel.DeliveryAggregate;
using MyApplication.DomainModel.PlannedDeliveryAggregate;
using MyApplication.DomainModel.PlannedRouteAggregate;

namespace MyApplication.Infrastructure.EntityFramework
{
    public class DomainDbContext : DbContext
    {
        //CustomerAggregate
        public DbSet<Customer> Customers { get; set; }
        public DbSet<DeliveryAddress> DeliveryAddresses { get; set; }
        //

        //DeliveryAggregate
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<DeliveryPart> DeliveryParts { get; set; }
        //

        //PlannedDeliveryAggregate
        public DbSet<PlannedDelivery> PlannedDeliveries { get; set; }
        //

        //PlannedRoutePart
        public DbSet<PlannedRoute> PlannedRoutes { get; set; }
        public DbSet<RoutePart> RouteParts { get; set; }
        //

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Set ValueObjects
            modelBuilder.Entity<DeliveryAddress>().OwnsOne(c => c.Address);

            //Set cascading delete
            modelBuilder.Entity<DeliveryAddress>()
                .HasOne(c => c.Customer)
                .WithMany(x=>x.DeliveryAddresses)
                .OnDelete(DeleteBehavior.Cascade);

        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=TestDatabase.db");
            optionsBuilder.UseLoggerFactory(LoggerFactory).EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }

        public static readonly LoggerFactory LoggerFactory =
          new LoggerFactory(new[] { new ConsoleLoggerProvider((_, __) => true, true) });

    }
}
