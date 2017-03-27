using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Easy.Domain.Entities;
using Easy.Infra.Data.Mappings.Entities;
using Easy.Infra.Data.Mappings.ObjectValues;

namespace Easy.Infra.Data.Contexts
{
    public class EfContext : DbContext
    {
        public EfContext()
            : base("Name=DefaultConnection")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;

            Database.Initialize(false);
        }


        public DbSet<Programador> Programadores { get; set; }
        public DbSet<DadoBancario> DadosBancarios { get; set; }
        public DbSet<Contato> DadosCadastros { get; set; }
        public DbSet<EspecialidadeTipo> EspecialidadesTipos { get; set; }
        public DbSet<Especialidade> Especialidades { get; set; }
        public DbSet<Disponibilidade> Disponibilidades { get; set; }
        public DbSet<HorarioTrabalho> HorarioTrabalhos { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>().Configure(x => x.HasColumnType("varchar").HasMaxLength(50));

            #region Complex Types Map
            modelBuilder.Configurations.Add(new CpfMap());
            modelBuilder.Configurations.Add(new EmailMap());
            #endregion

            #region Entities Map

            modelBuilder.Configurations.Add(new ProgramadorMap());
            modelBuilder.Configurations.Add(new DadoBancarioMap());
            modelBuilder.Configurations.Add(new DadoCadastroMap());
            modelBuilder.Configurations.Add(new EspecialidadeMap());
            modelBuilder.Configurations.Add(new DisponibilidadeMap());
            modelBuilder.Configurations.Add(new HorarioTrabalhoMap());

            #endregion
        }
    }
}
