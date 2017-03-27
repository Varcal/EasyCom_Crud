using Easy.Domain.Contracts.Repositories;
using Easy.Domain.Entities;
using Easy.Infra.Data.Contexts;
using Easy.Infra.Data.Repositories.Base;

namespace Easy.Infra.Data.Repositories
{
    public class EspecialidadeTipoRepository: RepositoryBase<EspecialidadeTipo>, IEspecialidadeTipoRepository
    {
        public EspecialidadeTipoRepository(EfContext db) 
            : base(db)
        {
            Db = db;
        }
    }
}
