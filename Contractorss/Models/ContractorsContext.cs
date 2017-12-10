using Microsoft.EntityFrameworkCore;


namespace Contractorss.Models
{
    public class ContractorsContext : DbContext
    {
        public ContractorsContext()
        {
        }

        public ContractorsContext(DbContextOptions<ContractorsContext> options) : base(options) { }
        public virtual DbSet<BuildingMaterial> BuildingMaterials { get; set; }
        public virtual DbSet<Contractor> Contractors { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<License> Licenses { get; set; }
        public virtual DbSet<ListWork> ListWork { get; set; }
        public virtual DbSet<MainObject> MainObjects { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<TechnicalEquipment> TechnicalEquipments { get; set; }
        public virtual DbSet<TypesJob> TypesJobs { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; } 

    }
}
