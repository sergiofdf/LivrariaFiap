using Carter;
using LivrariaFiap.Application.Dtos;
using LivrariaFiap.Application.PedidosServices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace LivrariaFiap.Api.EndPoints
{
    public class PedidoEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/pedidos");
            group.MapPost("", CadastrarPedido);
            group.MapGet("{idCliente}/cliente", ListarPedidosCliente).WithName(nameof(ListarPedidosCliente));
            group.MapGet("{idPedido}", ConsultarPedido).WithName(nameof(ConsultarPedido));
            group.MapPut("{idPedido}", AlterarPedido).WithName(nameof(AlterarPedido));
            group.MapDelete("{idPedido}", DeletarPedido).WithName(nameof(DeletarPedido));
        }

        public async Task<Created> CadastrarPedido(
            PedidoDto dto,
            IPedidoService service)
        {

            await service.Cadastrar(dto);

            return TypedResults.Created();
        }

        public async Task<Ok<List<PedidoResponseDto>>> ListarPedidosCliente(
            int idCliente,
            IPedidoService service)
        {
            var pedidos = await service.ObterPedidosCliente(idCliente);

            return TypedResults.Ok(pedidos);
        }

        public async Task<Results<Ok<PedidoResponseDto>, NotFound<string>>> ConsultarPedido(
            int idPedido,
            IPedidoService service)
        {

            var pedido = await service.ObterPorId(idPedido);

            if (pedido is null) return TypedResults.NotFound("Pedido não encontrado!");

            return TypedResults.Ok(pedido);
        }

        public async Task<NoContent> AlterarPedido(
            [FromRoute] int idPedido,
            [FromBody] PedidoDto dto,
            IPedidoService service)
        {
            await service.Alterar(idPedido, dto);

            return TypedResults.NoContent();
        }

        public async Task<NoContent> DeletarPedido(
            [FromRoute] int idPedido,
            IPedidoService service)
        {
            await service.Deletar(idPedido);

            return TypedResults.NoContent();
        }
    }
}
