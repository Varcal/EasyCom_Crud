using System.Collections.Generic;
using Easy.Application.ViewModels;

namespace Easy.Application.Contracts
{
    public interface IHorarioTrabalhoAppService
    {
        IEnumerable<HorarioTrabalhoVm> SelecionarTodos();
    }
}
