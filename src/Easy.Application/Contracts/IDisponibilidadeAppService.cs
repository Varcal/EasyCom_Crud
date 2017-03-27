using System.Collections.Generic;
using Easy.Application.ViewModels;

namespace Easy.Application.Contracts
{
    public interface IDisponibilidadeAppService
    {
        IEnumerable<DisponibilidadeVm> SelecionarTodos();
    }
}
