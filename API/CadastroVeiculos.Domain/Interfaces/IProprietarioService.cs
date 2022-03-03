using CadastroVeiculos.Domain.DTO;
using System.Collections.Generic;

namespace CadastroVeiculos.Domain.Interfaces
{
    public interface IProprietarioService
    {
        ProprietarioDTO Adicionar(ProprietarioDTO proprietarioDto);
        ProprietarioDTO Editar(ProprietarioDTO proprietarioDto);
        ProprietarioDTO Obter(string cpfCnpj);
        List<ProprietarioDTO> Obter();
        void Deletar(string cpfCnpj);
    }
}
