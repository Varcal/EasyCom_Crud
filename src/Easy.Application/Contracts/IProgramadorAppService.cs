using System.Collections.Generic;
using Easy.Application.ViewModels;

namespace Easy.Application.Contracts
{
    public interface IProgramadorAppService
    {
        void Registrar(ProgramadorVm model);
        void Alterar(ProgramadorVm model);
        void Excluir(int id);
        ProgramadorVm ObterParaEdicaoPorId(int id);
        ProgramadorVm ObterPorId(int id);
        IEnumerable<ProgramadorListVm> SelecionarTodos();
    }
}
