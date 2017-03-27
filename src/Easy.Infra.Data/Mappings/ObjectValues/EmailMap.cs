using System.Data.Entity.ModelConfiguration;
using Easy.Domain.ValueObjects;

namespace Easy.Infra.Data.Mappings.ObjectValues
{
    public class EmailMap: ComplexTypeConfiguration<Email>
    {
        public EmailMap()
        {
            Property(p => p.Endereco)
                .HasColumnName("Email")
                .HasColumnType("varchar")
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
