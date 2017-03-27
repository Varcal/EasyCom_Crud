using System.Collections.Generic;
using Easy.Domain.Contracts.Repositories.Base;
using Easy.Domain.Entities;

namespace Easy.Domain.Contracts.Repositories
{
    public interface IHorarioTrabalhoRepository: IRepositoryBase<HorarioTrabalho>
    {
        IEnumerable<HorarioTrabalho> SelecionarPorIds(IList<int> ids);
    }
}
