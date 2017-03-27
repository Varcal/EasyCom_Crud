using System.Data.Entity;
using System.Linq;
using Easy.Domain.Contracts.Repositories;
using Easy.Domain.Entities;
using Easy.Infra.Data.Contexts;
using Easy.Infra.Data.Repositories.Base;

namespace Easy.Infra.Data.Repositories
{
    public class ProgramadorRepository:RepositoryBase<Programador>, IProgramadorRepository
    {
        public ProgramadorRepository(EfContext db) 
            : base(db)
        {
            Db = db;
        }

        public Programador ObterPorParaEdicaoId(int id)
        {
            return Db.Programadores
                .Include(p => p.DadosCadastro)
                .Include(p => p.DadosBancario)
                .Include(p => p.Disponibilidades)
                .Include(p => p.HorariosTrabalhos)
                .Include(p => p.Especialidades.Select(e=>e.EspecialidadeTipo))
                .FirstOrDefault(p => p.Id == id);
        }
    }
}
