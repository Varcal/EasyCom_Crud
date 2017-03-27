using Easy.Domain.Entities;

namespace Easy.Infra.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Contexts.EfContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Contexts.EfContext context)
        {
            if (!context.EspecialidadesTipos.Any())
            {
                var ionic = new EspecialidadeTipo("Ionic", true);
                context.EspecialidadesTipos.Add(ionic);

                var android = new EspecialidadeTipo("Android", true);
                context.EspecialidadesTipos.Add(android);

                var ios = new EspecialidadeTipo("IOS", true);
                context.EspecialidadesTipos.Add(ios);

                var html = new EspecialidadeTipo("HTML", false);
                context.EspecialidadesTipos.Add(html);

                var css = new EspecialidadeTipo("CSS", false);
                context.EspecialidadesTipos.Add(css);

                var bootstrap = new EspecialidadeTipo("Bootstap", true);
                context.EspecialidadesTipos.Add(bootstrap);

                var jquery = new EspecialidadeTipo("JQuey", true);
                context.EspecialidadesTipos.Add(jquery);

                var angularJs = new EspecialidadeTipo("AngularJS", true);
                context.EspecialidadesTipos.Add(angularJs);

                var java = new EspecialidadeTipo("Java", false);
                context.EspecialidadesTipos.Add(java);

                var mvc = new EspecialidadeTipo("Asp.Net MVC", true);
                context.EspecialidadesTipos.Add(mvc);

                var c = new EspecialidadeTipo("C", false);
                context.EspecialidadesTipos.Add(c);

                var cpp = new EspecialidadeTipo("C++", false);
                context.EspecialidadesTipos.Add(cpp);

                var cake = new EspecialidadeTipo("Cake", false);
                context.EspecialidadesTipos.Add(cake);

                var django = new EspecialidadeTipo("Django", false);
                context.EspecialidadesTipos.Add(django);

                var magento = new EspecialidadeTipo("Magento", false);
                context.EspecialidadesTipos.Add(magento);

                var php = new EspecialidadeTipo("Php", true);
                context.EspecialidadesTipos.Add(php);

                var wp = new EspecialidadeTipo("Wordpress", true);
                context.EspecialidadesTipos.Add(wp);

                var phyton = new EspecialidadeTipo("Phyton", false);
                context.EspecialidadesTipos.Add(phyton);

                var ruby = new EspecialidadeTipo("Ruby", false);
                context.EspecialidadesTipos.Add(ruby);

                var sql = new EspecialidadeTipo("MS SQL Server", false);
                context.EspecialidadesTipos.Add(sql);

                var mysql = new EspecialidadeTipo("My SQL Server", false);
                context.EspecialidadesTipos.Add(mysql);

                var salesForce = new EspecialidadeTipo("Salesforce", false);
                context.EspecialidadesTipos.Add(salesForce);

                var photoshop = new EspecialidadeTipo("Photoshop", false);
                context.EspecialidadesTipos.Add(photoshop);

                var illustrator = new EspecialidadeTipo("Illustrator", false);
                context.EspecialidadesTipos.Add(illustrator);

                var seo = new EspecialidadeTipo("SEO", false);
                context.EspecialidadesTipos.Add(seo);

                context.SaveChanges();
            }

            if (!context.Disponibilidades.Any())
            {
                var ate4HorasDia = new Disponibilidade("Até 4 horas por dia");
                context.Disponibilidades.Add(ate4HorasDia);

                var ate4a6HorasDia = new Disponibilidade("De 4 á 6 horas por dia");
                context.Disponibilidades.Add(ate4a6HorasDia);

                var de6a8HorasDia = new Disponibilidade("De 6 á 8 horas por dia");
                context.Disponibilidades.Add(de6a8HorasDia);

                var acima8Horas = new Disponibilidade("Acima de 8 horas por dia");
                context.Disponibilidades.Add(acima8Horas);

                var finaisDeSemana = new Disponibilidade("Apenas finais de semana");
                context.Disponibilidades.Add(finaisDeSemana);

                context.SaveChanges();
            }

            if (!context.HorarioTrabalhos.Any())
            {
                var manha = new HorarioTrabalho("Manhã (de 08:00 ás 12:00)");
                context.HorarioTrabalhos.Add(manha);

                var tarde = new HorarioTrabalho("Tarde (de 13:00 ás 18:00)");
                context.HorarioTrabalhos.Add(tarde);

                var noite = new HorarioTrabalho("Noite (de 19:00 as 22:00)");
                context.HorarioTrabalhos.Add(noite);

                var madrugada = new HorarioTrabalho("Madrugada (de 22:00 em diante)");
                context.HorarioTrabalhos.Add(madrugada);

                var comercial = new HorarioTrabalho("Comercial (de 08:00 as 18:00)");
                context.HorarioTrabalhos.Add(comercial);

                context.SaveChanges();
            }
        }
    }
}
