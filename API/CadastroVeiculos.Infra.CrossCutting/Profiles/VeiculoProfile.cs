using AutoMapper;
using CadastroVeiculos.Domain.DTO;
using CadastroVeiculos.Domain.Entities;

namespace CadastroVeiculos.Infra.CrossCutting.Profiles
{
    public class VeiculoProfile : Profile
    {
        public VeiculoProfile()
        {
            CreateMap<Veiculo, VeiculoDTO>().ReverseMap();
        }
    }
}
