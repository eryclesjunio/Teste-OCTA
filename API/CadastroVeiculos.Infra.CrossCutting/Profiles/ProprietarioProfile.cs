using AutoMapper;
using CadastroVeiculos.Domain.DTO;
using CadastroVeiculos.Domain.Entities;

namespace CadastroVeiculos.Infra.CrossCutting.Profiles
{
    public class ProprietarioProfile : Profile
    {
        public ProprietarioProfile()
        {
            CreateMap<Proprietario, ProprietarioDTO>().ReverseMap();
        }
    }
}
