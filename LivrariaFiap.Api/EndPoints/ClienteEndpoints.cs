using AutoMapper;
using Carter;
using LivrariaFiap.Api.Models;
using LivrariaFiap.Domain.Abstractions;
using LivrariaFiap.Domain.Entities;

namespace LivrariaFiap.Api.EndPoints
{
    public class ClienteEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/clientes");
            group.MapPost("", CadastraCliente);
            //group.MapPut("{id}", UpdateProduct).WithName(nameof(UpdateProduct));
        }

        public static async Task<IResult> CadastraCliente(
            ClienteModel requestBody,
            IClienteService service,
            IMapper mapper
            )
        {

            Endereco mappedEnd = mapper.Map<Endereco>(requestBody.Endereco);
            Telefone mappedTel = mapper.Map<Telefone>(requestBody.Telefone);

            var entity = new Cliente
            {
                Nome = requestBody.Nome,
                Email = requestBody.Email,
                Endereco = mappedEnd,
                Telefone = mappedTel
            };

            await service.Cadastrar(entity);

            return Results.Ok();
        }
    }
}
