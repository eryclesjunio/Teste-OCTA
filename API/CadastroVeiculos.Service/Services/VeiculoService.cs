using AutoMapper;
using CadastroVeiculos.Domain.DTO;
using CadastroVeiculos.Domain.Entities;
using CadastroVeiculos.Domain.Interfaces;
using CadastroVeiculos.Service.Validators;
using System;
using System.Collections.Generic;

namespace CadastroVeiculos.Service.Services
{
    public class VeiculoService : IVeiculoService
    {
        private readonly IBaseService<Veiculo> _baseService;
        private readonly IMapper _autoMapper;

        public VeiculoService(IBaseService<Veiculo> baseService, IMapper autoMapper)
        {
            _baseService = baseService;
            _autoMapper = autoMapper;
        }

        public VeiculoDTO Adicionar(VeiculoDTO veiculoDto)
        {
            var entidade = _baseService.ObterPorCondicao(x => x.Placa == veiculoDto.Placa);

            if (entidade != null)
            {
                throw new Exception($"Veiculo com a placa {veiculoDto.Placa} já existe no banco!");
            }

            var entidadeMapeada = _autoMapper.Map<Veiculo>(veiculoDto);

            entidadeMapeada.Id = Guid.NewGuid();
            entidadeMapeada.DataCriacao = DateTime.Now;

            _baseService.Add<VeiculoValidator>(entidadeMapeada);

            return veiculoDto;
        }

        public VeiculoDTO Editar(VeiculoDTO veiculoDto)
        {
            var entidade = _baseService.ObterPorCondicao(x => x.Placa == veiculoDto.Placa);

            if (entidade == null)
            {
                throw new Exception($"Veiculo com a placa {veiculoDto.Placa} não foi encontrado no banco!");
            }

            var entidadeMapeada = _autoMapper.Map<Veiculo>(veiculoDto);

            entidadeMapeada.Id = entidade.Id;

            _baseService.Update<VeiculoValidator>(entidadeMapeada);

            return veiculoDto;
        }

        public VeiculoDTO Obter(string placa)
        {
            var entidade = _baseService.ObterPorCondicao(x => x.Placa == placa);

            if(entidade == null)
            {
                throw new Exception($"O veiculo com a planca {placa} não foi encontrado no banco!");
            }

            return _autoMapper.Map<VeiculoDTO>(entidade);
        }

        public List<VeiculoDTO> Obter()
        {
            var entidadesMapeadas = new List<VeiculoDTO>();

            var entidades = _baseService.Get();

            foreach (var entidade in entidades)
            {
                var entidadeMapeada = _autoMapper.Map<VeiculoDTO>(entidade);

                entidadesMapeadas.Add(entidadeMapeada);
            }

            return entidadesMapeadas;
        }

        public void Deletar(string placa)
        {
            var entidade = _baseService.ObterPorCondicao(x => x.Placa == placa);

            if (entidade == null)
            {
                throw new Exception($"O veiculo com a planca {placa} não foi encontrado no banco!");
            }

            _baseService.Delete(entidade);
        }
    }
}
