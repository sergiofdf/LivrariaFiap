using AutoMapper;
using Carter;
using LivrariaFiap.Application.ClienteServices;
using LivrariaFiap.Application.Dtos;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace LivrariaFiap.Api.EndPoints
{
    public class ClienteEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/clientes");
            group.MapPost("", CadastrarCliente);
            group.MapGet("", ListarClientes);
            group.MapGet("{id}", ConsultarCliente).WithName(nameof(ConsultarCliente));
            group.MapPut("{id}", AlterarCliente).WithName(nameof(AlterarCliente));
            group.MapDelete("{id}", DeletarCliente).WithName(nameof(DeletarCliente));
        }

        public async Task<Created> CadastrarCliente(
            ClienteDto dto,
            IClienteService service,
            IMapper mapper)
        {

            await service.Cadastrar(dto);

            return TypedResults.Created();
        }

        public async Task<Ok<List<ClienteResponseDto>>> ListarClientes(
            IClienteService service,
            IMapper mapper)
        {
            var clientes = await service.ObterTodos() ?? [];

            return TypedResults.Ok(clientes);
        }

        public async Task<Results<Ok<ClienteResponseDto>, NotFound<string>>> ConsultarCliente(
            int id,
            IClienteService service)
        {

            var cliente = await service.ObterPorId(id);

            if (cliente is null) return TypedResults.NotFound("Cliente não encontrado!");

            return TypedResults.Ok(cliente);
        }

        public async Task<NoContent> AlterarCliente(
            [FromRoute] int id,
            [FromBody] ClienteDto dto,
            IClienteService service)
        {
            await service.Alterar(id, dto);

            return TypedResults.NoContent();
        }

        public async Task<NoContent> DeletarCliente(
            [FromRoute] int id,
            IClienteService service)
        {
            await service.Deletar(id);

            return TypedResults.NoContent();
        }
    }
}
