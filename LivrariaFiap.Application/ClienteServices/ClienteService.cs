using AutoMapper;
using LivrariaFiap.Application.Dtos;
using LivrariaFiap.Domain.Abstractions;
using LivrariaFiap.Domain.Entities;

namespace LivrariaFiap.Application.ClienteServices
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repository;
        private readonly IMapper _mapper;
        public ClienteService(IClienteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Alterar(int id, ClienteDto dto)
        {
            var clienteResponseDto = await ObterPorId(id) ?? throw new Exception("Cliente não existe");

            var entity = _mapper.Map<Cliente>(clienteResponseDto);

            _mapper.Map(dto, entity);

            entity.Id = id;

            _repository.Alterar(entity);

        }

        public async Task Cadastrar(ClienteDto dto)
        {
            var entity = _mapper.Map<Cliente>(dto);

            _repository.Cadastrar(entity);
        }

        public async Task Deletar(int id)
        {
            _repository.Deletar(id);
        }

        public async Task<ClienteResponseDto>? ObterPorId(int id)
        {
            var cliente = _repository.ObterPorId(id);

            return _mapper.Map<ClienteResponseDto>(cliente);
        }

        public async Task<List<ClienteResponseDto>> ObterTodos()
        {
            var clientes = _repository.ObterTodos();

            var response = new List<ClienteResponseDto>();

            foreach (var cliente in clientes)
            {
                var clienteDto = _mapper.Map<ClienteResponseDto>(cliente);

                response.Add(clienteDto);
            }

            return response;
        }
    }
}
