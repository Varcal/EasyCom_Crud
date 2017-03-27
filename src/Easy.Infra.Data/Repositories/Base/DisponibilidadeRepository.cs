using System.Collections.Generic;
using System.Linq;
using Easy.Domain.Contracts.Repositories;
using Easy.Domain.Entities;
using Easy.Infra.Data.Contexts;

namespace Easy.Infra.Data.Repositories.Base
{
    public class DisponibilidadeRepository: RepositoryBase<Disponibilidade>, IDisponibilidadeRepository
    {
        public DisponibilidadeRepository(EfContext db) 
            : base(db)
        {
            Db = db;
        }

        public IEnumerable<Disponibilidade> SelecionarPorIds(IList<int> ids)
        {

            return Db.Disponibilidades.Where(x => ids.Contains(x.Id)).ToList();
        }
    }
}
