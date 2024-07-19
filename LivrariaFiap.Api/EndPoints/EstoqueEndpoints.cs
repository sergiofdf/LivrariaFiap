using Carter;
using LivrariaFiap.Application.Dtos;
using LivrariaFiap.Application.EstoqueServices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace LivrariaFiap.Api.EndPoints
{
    public class EstoqueEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/estoques");
            group.MapPost("", CadastrarEstoque);
            group.MapGet("", ListarEstoques);
            group.MapGet("{id}", ConsultarEstoque).WithName(nameof(ConsultarEstoque));
            group.MapPut("{id}", AlterarEstoque).WithName(nameof(AlterarEstoque));
            group.MapDelete("{id}", DeletarEstoque).WithName(nameof(DeletarEstoque));
        }

        public async Task<Created> CadastrarEstoque(
            EstoqueDto dto,
            IEstoqueService service)
        {

            await service.Cadastrar(dto);

            return TypedResults.Created();
        }

        public async Task<Ok<List<EstoqueResponseDto>>> ListarEstoques(
            IEstoqueService service)
        {
            var estoques = await service.ObterTodos();

            return TypedResults.Ok(estoques);
        }

        public async Task<Results<Ok<EstoqueResponseDto>, NotFound<string>>> ConsultarEstoque(
            int id,
            IEstoqueService service)
        {

            var estoque = await service.ObterPorId(id);

            if (estoque is null) return TypedResults.NotFound("Estoque não encontrado!");

            return TypedResults.Ok(estoque);
        }

        public async Task<NoContent> AlterarEstoque(
            [FromRoute] int id,
            [FromBody] EstoqueDto dto,
            IEstoqueService service)
        {
            await service.Alterar(id, dto);

            return TypedResults.NoContent();
        }

        public async Task<NoContent> DeletarEstoque(
            [FromRoute] int id,
            IEstoqueService service)
        {
            await service.Deletar(id);

            return TypedResults.NoContent();
        }
    }
}
