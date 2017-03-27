namespace Easy.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DadoBancario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        Cpf = c.String(maxLength: 11, fixedLength: true, unicode: false),
                        NomeBanco = c.String(nullable: false, maxLength: 20, unicode: false),
                        Agencia = c.String(nullable: false, maxLength: 6, unicode: false),
                        TipoConta = c.Int(nullable: false),
                        NumeroConta = c.String(nullable: false, maxLength: 10, unicode: false),
                        DataCadastro = c.DateTime(nullable: false, precision: 2, storeType: "datetime2"),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DadosCadastro",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 150, unicode: false),
                        Skype = c.String(nullable: false, maxLength: 50, unicode: false),
                        Telefone = c.String(nullable: false, maxLength: 20, unicode: false),
                        Linkedin = c.String(maxLength: 150, unicode: false),
                        DataCadastro = c.DateTime(nullable: false, precision: 2, storeType: "datetime2"),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Disponibilidade",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        DataCadastro = c.DateTime(nullable: false, precision: 2, storeType: "datetime2"),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Programador",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 150, unicode: false),
                        GitHubLink = c.String(maxLength: 100, unicode: false),
                        DadosCadastroId = c.Int(nullable: false),
                        DadosBancarioId = c.Int(),
                        Cidade = c.String(nullable: false, maxLength: 100, unicode: false),
                        Estado = c.String(nullable: false, maxLength: 100, unicode: false),
                        Portifolio = c.String(maxLength: 100, unicode: false),
                        PretensaoSalarial = c.Int(nullable: false),
                        Outros = c.String(nullable: false, maxLength: 150, unicode: false),
                        DataCadastro = c.DateTime(nullable: false, precision: 2, storeType: "datetime2"),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DadoBancario", t => t.DadosBancarioId)
                .ForeignKey("dbo.DadosCadastro", t => t.DadosCadastroId)
                .Index(t => t.DadosCadastroId)
                .Index(t => t.DadosBancarioId);
            
            CreateTable(
                "dbo.Especialidade",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EspecialidadeTipoId = c.Int(nullable: false),
                        ProgramadorId = c.Int(nullable: false),
                        Nota = c.Int(nullable: false),
                        DataCadastro = c.DateTime(nullable: false, precision: 2, storeType: "datetime2"),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EspecialidadeTipo", t => t.EspecialidadeTipoId)
                .ForeignKey("dbo.Programador", t => t.ProgramadorId, cascadeDelete: true)
                .Index(t => t.EspecialidadeTipoId)
                .Index(t => t.ProgramadorId);
            
            CreateTable(
                "dbo.EspecialidadeTipo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descricao = c.String(maxLength: 50, unicode: false),
                        Obrigatoria = c.Boolean(nullable: false),
                        DataCadastro = c.DateTime(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HorarioTrabalho",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100, unicode: false),
                        DataCadastro = c.DateTime(nullable: false, precision: 2, storeType: "datetime2"),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProgramadorDisponibilidade",
                c => new
                    {
                        ProgramadorId = c.Int(nullable: false),
                        DisponibilidadeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProgramadorId, t.DisponibilidadeId })
                .ForeignKey("dbo.Programador", t => t.ProgramadorId, cascadeDelete: true)
                .ForeignKey("dbo.Disponibilidade", t => t.DisponibilidadeId, cascadeDelete: true)
                .Index(t => t.ProgramadorId)
                .Index(t => t.DisponibilidadeId);
            
            CreateTable(
                "dbo.ProgramadorHorarioTrabalho",
                c => new
                    {
                        ProgramadorId = c.Int(nullable: false),
                        HorarioTrabalhoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProgramadorId, t.HorarioTrabalhoId })
                .ForeignKey("dbo.Programador", t => t.ProgramadorId, cascadeDelete: true)
                .ForeignKey("dbo.HorarioTrabalho", t => t.HorarioTrabalhoId, cascadeDelete: true)
                .Index(t => t.ProgramadorId)
                .Index(t => t.HorarioTrabalhoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProgramadorHorarioTrabalho", "HorarioTrabalhoId", "dbo.HorarioTrabalho");
            DropForeignKey("dbo.ProgramadorHorarioTrabalho", "ProgramadorId", "dbo.Programador");
            DropForeignKey("dbo.Especialidade", "ProgramadorId", "dbo.Programador");
            DropForeignKey("dbo.Especialidade", "EspecialidadeTipoId", "dbo.EspecialidadeTipo");
            DropForeignKey("dbo.ProgramadorDisponibilidade", "DisponibilidadeId", "dbo.Disponibilidade");
            DropForeignKey("dbo.ProgramadorDisponibilidade", "ProgramadorId", "dbo.Programador");
            DropForeignKey("dbo.Programador", "DadosCadastroId", "dbo.DadosCadastro");
            DropForeignKey("dbo.Programador", "DadosBancarioId", "dbo.DadoBancario");
            DropIndex("dbo.ProgramadorHorarioTrabalho", new[] { "HorarioTrabalhoId" });
            DropIndex("dbo.ProgramadorHorarioTrabalho", new[] { "ProgramadorId" });
            DropIndex("dbo.ProgramadorDisponibilidade", new[] { "DisponibilidadeId" });
            DropIndex("dbo.ProgramadorDisponibilidade", new[] { "ProgramadorId" });
            DropIndex("dbo.Especialidade", new[] { "ProgramadorId" });
            DropIndex("dbo.Especialidade", new[] { "EspecialidadeTipoId" });
            DropIndex("dbo.Programador", new[] { "DadosBancarioId" });
            DropIndex("dbo.Programador", new[] { "DadosCadastroId" });
            DropTable("dbo.ProgramadorHorarioTrabalho");
            DropTable("dbo.ProgramadorDisponibilidade");
            DropTable("dbo.HorarioTrabalho");
            DropTable("dbo.EspecialidadeTipo");
            DropTable("dbo.Especialidade");
            DropTable("dbo.Programador");
            DropTable("dbo.Disponibilidade");
            DropTable("dbo.DadosCadastro");
            DropTable("dbo.DadoBancario");
        }
    }
}
