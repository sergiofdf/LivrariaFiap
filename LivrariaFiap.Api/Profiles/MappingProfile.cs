using AutoMapper;
using LivrariaFiap.Api.Models;
using LivrariaFiap.Domain.Entities;

namespace LivrariaFiap.Api.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EnderecoModel, Endereco>();
            CreateMap<TelefoneCreateModel, Telefone>();
        }
    }
}
