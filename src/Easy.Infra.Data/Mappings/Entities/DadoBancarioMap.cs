using Easy.Domain.Entities;
using Easy.Infra.Data.Mappings.Base;

namespace Easy.Infra.Data.Mappings.Entities
{
    public class DadoBancarioMap: BaseMap<DadoBancario>
    {
        public DadoBancarioMap()
        {
            ToTable("DadoBancario");

            
            Property(p => p.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();
            Property(p => p.TipoConta)
                .HasColumnName("TipoConta")
                .HasColumnType("int")
                .IsRequired();
            Property(p => p.NomeBanco)
                .HasColumnName("NomeBanco")
                .HasMaxLength(20)
                .IsRequired();
            Property(p => p.Agencia)
                .HasColumnName("Agencia")
                .HasMaxLength(6)
                .IsRequired();
            Property(p => p.NumeroConta)
                .HasColumnName("NumeroConta")
                .HasMaxLength(10)
                .IsRequired();

        }
    }
}
