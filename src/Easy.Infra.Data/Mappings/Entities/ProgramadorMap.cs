using Easy.Domain.Entities;
using Easy.Infra.Data.Mappings.Base;

namespace Easy.Infra.Data.Mappings.Entities
{
    public class ProgramadorMap: BaseMap<Programador>
    {
        public ProgramadorMap()
        {
            ToTable("Programador");

            HasMany(x => x.Especialidades)
                .WithRequired()
                .HasForeignKey(fk => fk.ProgramadorId)
                .WillCascadeOnDelete(true);

            HasMany(x => x.Disponibilidades)
                .WithMany(p => p.Programadores)
                .Map(map =>
                {
                    map.ToTable("ProgramadorDisponibilidade");
                    map.MapLeftKey("ProgramadorId");
                    map.MapRightKey("DisponibilidadeId");
                });

            HasMany(x => x.HorariosTrabalhos)
                .WithMany(p => p.Programadores)
                .Map(map =>
                {
                    map.ToTable("ProgramadorHorarioTrabalho");
                    map.MapLeftKey("ProgramadorId");
                    map.MapRightKey("HorarioTrabalhoId");
                });

            HasRequired(p => p.DadosCadastro)
                .WithMany()
                .HasForeignKey(fk => fk.DadosCadastroId);

            HasOptional(p => p.DadosBancario)
                .WithMany()
                .HasForeignKey(fk => fk.DadosBancarioId);

            Property(p => p.Nome)
               .HasColumnName("Nome")
               .HasColumnType("varchar")
               .HasMaxLength(150)
               .IsRequired();
            Property(p => p.Cidade)
               .HasColumnName("Cidade")
               .HasColumnType("varchar")
               .HasMaxLength(100)
               .IsRequired();
            Property(p => p.Estado)
                .HasColumnName("Estado")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();
            Property(p => p.Portifolio)
                .HasColumnName("Portifolio")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsOptional();
            Property(p => p.PretensaoSalarial)
                .HasColumnName("PretensaoSalarial")
                .HasColumnType("int")
                .IsRequired();
            Property(p => p.Outros)
                .HasColumnName("Outros")
                .HasColumnType("varchar")
                .HasMaxLength(150)
                .IsRequired();
            Property(p => p.GitHubLink)
                .HasColumnName("GitHubLink")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsOptional();
        }
    }
}
