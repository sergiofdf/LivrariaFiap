using Carter;
using LivrariaFiap.Application.Dtos;
using LivrariaFiap.Application.PedidosServices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace LivrariaFiap.Api.EndPoints
{
    public class ItemPedidoEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/item-pedido");
            group.MapPost("", CadastrarItemPedido);
            //group.MapGet("", ListarLivros);
            group.MapGet("{id}", ConsultarItemPedido).WithName(nameof(ConsultarItemPedido));
            group.MapPut("{id}", AlterarItemPedido).WithName(nameof(AlterarItemPedido));
            group.MapDelete("{id}", DeletarItemPedido).WithName(nameof(DeletarItemPedido));
        }

        public async Task<Created> CadastrarItemPedido(
            ItemPedidoDto dto,
            IItemPedidoService service)
        {

            await service.Cadastrar(dto);

            return TypedResults.Created();
        }

        //public async Task<Ok<List<LivroResponseDto>>> ListarLivros(
        //    ILivroService service)
        //{
        //    var livros = await service.ObterTodos();

        //    return TypedResults.Ok(livros);
        //}

        public async Task<Results<Ok<ItemPedidoResponseDto>, NotFound<string>>> ConsultarItemPedido(
            int id,
            IItemPedidoService service)
        {

            var itemPedido = await service.ObterPorId(id);

            if (itemPedido is null) return TypedResults.NotFound("Item do pedido não encontrado!");

            return TypedResults.Ok(itemPedido);
        }

        public async Task<NoContent> AlterarItemPedido(
            [FromRoute] int id,
            [FromBody] ItemPedidoDto dto,
            IItemPedidoService service)
        {
            await service.Alterar(id, dto);

            return TypedResults.NoContent();
        }

        public async Task<NoContent> DeletarItemPedido(
            [FromRoute] int id,
            IItemPedidoService service)
        {
            await service.Deletar(id);

            return TypedResults.NoContent();
        }
    }
}
