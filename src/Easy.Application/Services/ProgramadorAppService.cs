using System.Collections.Generic;
using System.Linq;
using Easy.Application.Contracts;
using Easy.Application.Services.Base;
using Easy.Application.ViewModels;
using Easy.Domain.Contracts.Repositories;
using Easy.Domain.Entities;
using Easy.Domain.Enums;
using Easy.Infra.Data.UoW;

namespace Easy.Application.Services
{
    public class ProgramadorAppService :ApplicationService, IProgramadorAppService
    {

        private readonly IProgramadorRepository _programadorRepository;
        private readonly IDisponibilidadeRepository _disponibilidadeRepository;
        private readonly IHorarioTrabalhoRepository _horarioTrabalhoRepository;

        public ProgramadorAppService(IUnitOfWork uow, IProgramadorRepository programadorRepository, IDisponibilidadeRepository disponibilidadeRepository, IHorarioTrabalhoRepository horarioTrabalhoRepository) 
            : base(uow)
        {
            _programadorRepository = programadorRepository;
            _disponibilidadeRepository = disponibilidadeRepository;
            _horarioTrabalhoRepository = horarioTrabalhoRepository;
        }


        public void Registrar(ProgramadorVm model)
        {
            var dadosCadastro = new Contato(model.DadosCadastro.Email,  model.DadosCadastro.Skype, model.DadosCadastro.Telefone, model.DadosCadastro.Linkedin);
            var dadosBancario = model.DadosBancarios != null ? new DadoBancario(model.DadosBancarios.Nome, model.DadosBancarios.Cpf, model.DadosBancarios.Banco, model.DadosBancarios.Agencia, (TipoConta)model.DadosBancarios.ContaTipo, model.DadosBancarios.NumeroConta) : null;
            var especialidades = model.Especialidades.Select(e => new Especialidade(e.EspecialidadeTipoId, e.Nota)).ToList();
            var disponibilidades = _disponibilidadeRepository.SelecionarPorIds(model.Disponibilidades.Select(x => x.Id).ToList()).ToList();
            var horarios = _horarioTrabalhoRepository.SelecionarPorIds(model.Horarios.Select(x => x.Id).ToList()).ToList();

            var programador = new Programador(model.Nome, model.LinkCrud, dadosCadastro, especialidades, disponibilidades, horarios, model.Cidade, model.Estado, model.Portifolio, model.PretensaoSalarial, model.Outros, dadosBancario);

            _programadorRepository.Add(programador);

            Save();
        }


        public void Alterar(ProgramadorVm model)
        { 
            var contato = new Contato(model.DadosCadastro.Email, model.DadosCadastro.Skype, model.DadosCadastro.Telefone, model.DadosCadastro.Linkedin);
            var dadosBancario = model.DadosBancarios != null ? new DadoBancario(model.DadosBancarios.Nome, model.DadosBancarios.Cpf, model.DadosBancarios.Banco, model.DadosBancarios.Agencia, (TipoConta)model.DadosBancarios.ContaTipo, model.DadosBancarios.NumeroConta) : null;
            var especialidades = model.Especialidades.Select(e => new Especialidade(e.Id, e.EspecialidadeTipoId, e.Nota)).ToList();
            var disponibilidades = _disponibilidadeRepository.SelecionarPorIds(model.Disponibilidades.Select(x => x.Id).ToList()).ToList();
            var horarios = _horarioTrabalhoRepository.SelecionarPorIds(model.Horarios.Select(x => x.Id).ToList()).ToList();
            
            var programador = _programadorRepository.ObterPorParaEdicaoId(model.Id);
            programador.Alterar(model.Nome, model.LinkCrud, contato, dadosBancario, disponibilidades, horarios, especialidades, model.Cidade, model.Estado, model.Portifolio, model.PretensaoSalarial, model.Outros);
            _programadorRepository.Update(programador);
            Save();
        }

        public void Excluir(int id)
        {
            var programador = _programadorRepository.GetById(id);
            _programadorRepository.Remove(programador);
            Save();
        }

        public ProgramadorVm ObterPorId(int id)
        {
            var programador = _programadorRepository.GetById(id);

            return new ProgramadorVm(programador);
        }

        public IEnumerable<ProgramadorListVm> SelecionarTodos()
        {
            var programadores = _programadorRepository.GetAll();

            return programadores.Select(p => new ProgramadorListVm(p)).ToList();
        }

        public ProgramadorVm ObterParaEdicaoPorId(int id)
        {
            var programador = _programadorRepository.ObterPorParaEdicaoId(id);

            return new ProgramadorVm(programador);
        }
    }
}
