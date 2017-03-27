using Easy.Domain.Entities;
using Easy.Infra.Data.Mappings.Base;

namespace Easy.Infra.Data.Mappings.Entities
{
    public class EspecialidadeMap : BaseMap<Especialidade>
    {
        public EspecialidadeMap()
        {
            ToTable("Especialidade");

            HasRequired(p => p.EspecialidadeTipo)
                .WithMany()
                .HasForeignKey(fk => fk.EspecialidadeTipoId);

            Property(p => p.EspecialidadeTipoId)
                .HasColumnName("EspecialidadeTipoId")
                .HasColumnType("int")
                .IsRequired();
            Property(p => p.ProgramadorId)
                .HasColumnName("ProgramadorId")
                .HasColumnType("int")
                .IsRequired();
            Property(p => p.Nota)
                .HasColumnName("Nota")
                .HasColumnType("int")
                .IsRequired();
        }
    }
}
