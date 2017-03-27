using Easy.Domain.Entities;
using Easy.Infra.Data.Mappings.Base;

namespace Easy.Infra.Data.Mappings.Entities
{
    public class HorarioTrabalhoMap: BaseMap<HorarioTrabalho>
    {
        public HorarioTrabalhoMap()
        {
            ToTable("HorarioTrabalho");

            Property(p => p.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}
