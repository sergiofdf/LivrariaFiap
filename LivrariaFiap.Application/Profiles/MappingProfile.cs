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
            CreateMap<LivroDto, Livro>()
                .ForMember(dst => dst.ItemsPedido, opt => opt.MapFrom(opt => new Collection<ItemPedido>()));
            CreateMap<Livro, LivroResponseDto>().ReverseMap();

            CreateMap<EstoqueDto, Estoque>();
            CreateMap<Estoque, EstoqueResponseDto>()
                .ForMember(dst => dst.IdEstoque, opt => opt.MapFrom(src => src.Id));

            CreateMap<EstoqueResponseDto, Estoque>()
                .ForMember(dst => dst.Id, opt => opt.Ignore());

            CreateMap<PedidoDto, Pedido>();

            CreateMap<ItemPedidoResponseDto, ItemPedido>();

            CreateMap<EnderecoDto, Endereco>();
            CreateMap<TelefoneCreateDto, Telefone>();



            CreateMap<ClienteDto, Cliente>();
            CreateMap<Cliente, ClienteResponseDto>();
            //.ForMember(dst => dst.Pedidos, opt => opt.MapFrom(src => src.Pedidos.Select(src => new PedidoCliente()
            //{
            //    ItemsPedido = src.ItemsPedido,
            //    Status = src.Status,
            //    ValorPedido = src.ValorPedido
            //})));
        }
    }
}
