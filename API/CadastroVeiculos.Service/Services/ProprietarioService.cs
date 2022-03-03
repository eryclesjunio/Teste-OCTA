using AutoMapper;
using CadastroVeiculos.Domain.DTO;
using CadastroVeiculos.Domain.Entities;
using CadastroVeiculos.Domain.Interfaces;
using CadastroVeiculos.Service.Validators;
using System;
using System.Collections.Generic;

namespace CadastroVeiculos.Service.Services
{
    public class ProprietarioService : IProprietarioService
    {
        private readonly IBaseService<Proprietario> _baseService;
        private readonly IMapper _autoMapper;

        public ProprietarioService(IBaseService<Proprietario> baseService, IMapper autoMapper)
        {
            _baseService = baseService;
            _autoMapper = autoMapper;
        }

        public ProprietarioDTO Adicionar(ProprietarioDTO proprietarioDto)
        {
            var entidade = _baseService.ObterPorCondicao(x => x.CpfCnpj == proprietarioDto.CpfCnpj);

            if (entidade != null)
            {
                throw new Exception($"Proprietario com o CPF/CNPJ {proprietarioDto.CpfCnpj} já existe no banco!");
            }

            var entidadeMapeada = _autoMapper.Map<Proprietario>(proprietarioDto);

            entidadeMapeada.Id = Guid.NewGuid();
            entidadeMapeada.DataCriacao = DateTime.Now;

            _baseService.Add<ProprietarioValidator>(entidadeMapeada);

            return proprietarioDto;
        }


        public ProprietarioDTO Editar(ProprietarioDTO proprietarioDto)
        {
            var entidade = _baseService.ObterPorCondicao(x => x.CpfCnpj == proprietarioDto.CpfCnpj);

            if (entidade == null)
            {
                throw new Exception($"O proprietario com CPF/CNPJ {proprietarioDto.CpfCnpj} não foi encontrado no banco!");
            }

            var entidadeMapeada = _autoMapper.Map<Proprietario>(proprietarioDto);

            entidadeMapeada.Id = entidade.Id;

            _baseService.Update<ProprietarioValidator>(entidadeMapeada);

            return proprietarioDto;
        }

        public ProprietarioDTO Obter(string cpfCnpj)
        {
            var entidade = _baseService.ObterPorCondicao(x => x.CpfCnpj == cpfCnpj);

            if(entidade == null)
            {
                throw new Exception($"O proprietario com CPF/CNPJ {cpfCnpj} não foi encontrado no banco!");
            }

            return _autoMapper.Map<ProprietarioDTO>(entidade);
        }

        public List<ProprietarioDTO> Obter()
        {
            var entidadesMapeadas = new List<ProprietarioDTO>();

            var entidades = _baseService.Get();

            foreach (var entidade in entidades)
            {
                var entidadeMapeada = _autoMapper.Map<ProprietarioDTO>(entidade);

                entidadesMapeadas.Add(entidadeMapeada);
            }
            
            return entidadesMapeadas;
        }

        public void Deletar(string cpfCnpj)
        {
            var entidade = _baseService.ObterPorCondicao(x => x.CpfCnpj == cpfCnpj);

            if (entidade == null)
            {
                throw new Exception($"O proprietario com CPF/CNPJ {cpfCnpj} não foi encontrado no banco!");
            }

            _baseService.Delete(entidade);
        }
    }
}
