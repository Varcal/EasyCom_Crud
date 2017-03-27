using System.Collections.Generic;
using Easy.Domain.Contracts.Repositories.Base;
using Easy.Domain.Entities;

namespace Easy.Domain.Contracts.Repositories
{
    public interface IDisponibilidadeRepository: IRepositoryBase<Disponibilidade>
    {
        IEnumerable<Disponibilidade> SelecionarPorIds(IList<int> ids);
    }
}
