using System.Data.Entity.ModelConfiguration;
using Easy.Domain.ValueObjects;

namespace Easy.Infra.Data.Mappings.ObjectValues
{
    public class CpfMap: ComplexTypeConfiguration<Cpf>
    {
        public CpfMap()
        {
            Property(p => p.Numero)
                .HasColumnName("Cpf")
                .HasColumnType("char")
                .HasMaxLength(11)
                .IsOptional();
        }
    }
}
