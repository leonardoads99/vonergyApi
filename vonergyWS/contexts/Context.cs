using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using vonergyDom.domain;

namespace vonergyWS.context
{
    public class Context : DbContext
    {
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Equipamentos> Equipamentos { get; set; }
        public DbSet<Consumo> Consumos { get; set; }
        public DbSet<DispositivoIOT> DispositivoIOT { get; set; }

        public Context() : base("conexaoVonergy")
        {
            Database.SetInitializer<Context>(new DropCreateDatabaseIfModelChanges<Context>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(100));

            modelBuilder.Entity<Consumo>().Property(c => c.Potencia).HasPrecision(9, 8);

            base.OnModelCreating(modelBuilder);
        }
    }
}