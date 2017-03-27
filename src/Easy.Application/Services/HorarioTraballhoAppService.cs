using System.Collections.Generic;
using System.Linq;
using Easy.Application.Contracts;
using Easy.Application.ViewModels;
using Easy.Domain.Contracts.Repositories;

namespace Easy.Application.Services
{
    public class HorarioTraballhoAppService: IHorarioTrabalhoAppService
    {
        private IHorarioTrabalhoRepository _horarioTrabalhoRepository;

        public HorarioTraballhoAppService(IHorarioTrabalhoRepository horarioTrabalhoRepository)
        {
            _horarioTrabalhoRepository = horarioTrabalhoRepository;
        }

        public IEnumerable<HorarioTrabalhoVm> SelecionarTodos()
        {
            return _horarioTrabalhoRepository.GetAll().Select(h => new HorarioTrabalhoVm(h)).ToList();
        }
    }
}
