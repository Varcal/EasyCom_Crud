using System.Collections.Generic;
using System.Linq;
using Easy.Domain.Contracts.Repositories;
using Easy.Domain.Entities;
using Easy.Infra.Data.Contexts;

namespace Easy.Infra.Data.Repositories.Base
{
    public class HorarioTrabalhoRepository: RepositoryBase<HorarioTrabalho>, IHorarioTrabalhoRepository
    {
        public HorarioTrabalhoRepository(EfContext db) 
            : base(db)
        {
            Db = db;
        }

        public IEnumerable<HorarioTrabalho> SelecionarPorIds(IList<int> ids)
        {
            return Db.HorarioTrabalhos.Where(x => ids.Contains(x.Id)).ToList();
        }
    }
}
