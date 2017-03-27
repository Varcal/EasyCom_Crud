using Easy.Domain.Entities;
using Easy.Infra.Data.Mappings.Base;

namespace Easy.Infra.Data.Mappings.Entities
{
    public class DadoCadastroMap: BaseMap<Contato>
    {
        public DadoCadastroMap()
        {
            ToTable("DadosCadastro");

           
            Property(p => p.Skype)
                .HasColumnName("Skype")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();
            Property(p => p.Telefone)
               .HasColumnName("Telefone")
               .HasColumnType("varchar")
               .HasMaxLength(20)
               .IsRequired();
            Property(p => p.Linkedin)
                .HasColumnName("Linkedin")
                .HasColumnType("varchar")
                .HasMaxLength(150)
                .IsOptional();
           
        }
    }
}
