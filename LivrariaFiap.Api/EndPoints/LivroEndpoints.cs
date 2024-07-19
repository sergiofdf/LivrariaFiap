using Carter;
using LivrariaFiap.Application.Dtos;
using LivrariaFiap.Application.LivroServices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace LivrariaFiap.Api.EndPoints
{
    public class LivroEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/livros");
            group.MapPost("", CadastrarLivro);
            group.MapGet("", ListarLivros);
            group.MapGet("{id}", ConsultarLivro).WithName(nameof(ConsultarLivro));
            group.MapPut("{id}", AlterarLivro).WithName(nameof(AlterarLivro));
            group.MapDelete("{id}", DeletarLivro).WithName(nameof(DeletarLivro));
        }

        public async Task<Created> CadastrarLivro(
            LivroDto livroDto,
            ILivroService service)
        {

            await service.Cadastrar(livroDto);

            return TypedResults.Created();
        }

        public async Task<Ok<List<LivroResponseDto>>> ListarLivros(
            ILivroService service)
        {
            var livros = await service.ObterTodos();

            return TypedResults.Ok(livros);
        }

        public async Task<Results<Ok<LivroResponseDto>, NotFound<string>>> ConsultarLivro(
            int id,
            ILivroService service)
        {

            var livro = await service.ObterPorId(id);

            if (livro is null) return TypedResults.NotFound("Livro não encontrado!");

            return TypedResults.Ok(livro);
        }

        public async Task<NoContent> AlterarLivro(
            [FromRoute] int id,
            [FromBody] LivroDto dto,
            ILivroService service)
        {
            await service.Alterar(id, dto);

            return TypedResults.NoContent();
        }

        public async Task<NoContent> DeletarLivro(
            [FromRoute] int id,
            ILivroService service)
        {
            await service.Deletar(id);

            return TypedResults.NoContent();
        }
    }
}
