using AutoMapper;
using Carter;
using LivrariaFiap.Application.Dtos;
using LivrariaFiap.Domain.Abstractions;
using LivrariaFiap.Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;

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
            //group.MapPut("{id}", UpdateProduct).WithName(nameof(UpdateProduct));
        }

        public async Task<Created> CadastrarCliente(
            ClienteModel requestBody,
            IClienteService service,
            IMapper mapper)
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

            return TypedResults.Created();
        }

        public async Task<Ok<IList<Cliente>>> ListarClientes(
            IClienteService service,
            IMapper mapper)
        {
            var clientes = await service.ObterTodos() ?? new List<Cliente>();

            return TypedResults.Ok(clientes);
        }

        public async Task<Results<Ok<Cliente>, NotFound<string>>> ConsultarCliente(
            int id,
            IClienteService service)
        {

            var cliente = await service.ObterPorId(id);

            if (cliente is null) return TypedResults.NotFound("Cliente não encontrado!");

            return TypedResults.Ok(cliente);
        }
    }
}
