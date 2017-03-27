using Easy.Domain.Contracts.Repositories.Base;
using Easy.Domain.Entities;

namespace Easy.Domain.Contracts.Repositories
{
    public interface IProgramadorRepository: IRepositoryBase<Programador>
    {
        Programador ObterPorParaEdicaoId(int id);
    }
}
