using CadastroVeiculos.Domain.DTO;
using System.Collections.Generic;

namespace CadastroVeiculos.Domain.Interfaces
{
    public interface IVeiculoService
    {
        VeiculoDTO Adicionar(VeiculoDTO veiculoDto);
        VeiculoDTO Editar(VeiculoDTO veiculoDto);
        VeiculoDTO Obter(string placa);
        List<VeiculoDTO> Obter();
        void Deletar(string placa);
    }
}
