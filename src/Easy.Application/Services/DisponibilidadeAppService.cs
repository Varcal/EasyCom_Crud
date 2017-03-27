using System.Collections.Generic;
using System.Linq;
using Easy.Application.Contracts;
using Easy.Application.ViewModels;
using Easy.Domain.Contracts.Repositories;

namespace Easy.Application.Services
{
    public class DisponibilidadeAppService: IDisponibilidadeAppService
    {
        private readonly IDisponibilidadeRepository _disponibilidadeRepository;

        public DisponibilidadeAppService(IDisponibilidadeRepository disponibilidadeRepository)
        {
            _disponibilidadeRepository = disponibilidadeRepository;
        }

        public IEnumerable<DisponibilidadeVm> SelecionarTodos()
        {
            return _disponibilidadeRepository.GetAll().Select(d=>new DisponibilidadeVm(d)).ToList();
        }
    }
}
