using System.Collections.Generic;
using System.Linq;
using Easy.Application.Contracts;
using Easy.Application.ViewModels;
using Easy.Domain.Contracts.Repositories;

namespace Easy.Application.Services
{
    public class EspecialidadeTipoAppService : IEspecialidadeTipoAppService
    {
        private readonly IEspecialidadeTipoRepository _especialidadeTipoRepository;

        public EspecialidadeTipoAppService(IEspecialidadeTipoRepository especialidadeTipoRepository)
        {
            _especialidadeTipoRepository = especialidadeTipoRepository;
        }

        public IEnumerable<EspecialidadeVm> SelecionarTodos()
        {
            return _especialidadeTipoRepository.GetAll().Select(e => new EspecialidadeVm(e));
        }
    }
}
