using AutoMapper;
using LivrariaFiap.Api.Models;
using LivrariaFiap.Application.Dtos;
using LivrariaFiap.Domain.Entities;
using System.Collections.ObjectModel;

namespace LivrariaFiap.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EnderecoModel, Endereco>();
            CreateMap<TelefoneCreateModel, Telefone>();
            CreateMap<LivroDto, Livro>()
                .ForMember(dst => dst.ItemsPedido, opt => opt.MapFrom(opt => new Collection<ItemPedido>()));
            CreateMap<ItemPedidoResponseModel, ItemPedido>();
            CreateMap<Livro, LivroResponseDto>().ReverseMap();
            //CreateMap<Cliente, ClienteResponseModel>()
            //    .ForMember(dst => dst.Pedidos, src => src.MapFrom(p => p.Pedidos.Select(p => new PedidoCliente()
            //    {
            //        ItemsPedido = p.ItemsPedido,
            //        Status = p.Status,
            //        ValorPedido = p.ValorPedido
            //    })));
        }
    }
}
