using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace FlowerLotModel
{
    public partial class FlowerLotEntitiesModel : DbContext
    {
        public FlowerLotEntitiesModel()
            : base("name=FlowerLotEntitiesModel")
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.Customer)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Inventory>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.Inventory)
                .WillCascadeOnDelete();
        }
    }
}
