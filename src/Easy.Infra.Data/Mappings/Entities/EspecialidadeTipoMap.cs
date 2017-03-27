using Easy.Domain.Entities;
using Easy.Infra.Data.Mappings.Base;

namespace Easy.Infra.Data.Mappings.Entities
{
    public class EspecialidadeTipoMap: BaseMap<EspecialidadeTipo>
    {
        public EspecialidadeTipoMap()
        {
            ToTable("EspecialidadeTipo");

            Property(p => p.Descricao)
                .HasColumnName("Descricao")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

        }
    }
}
