using AutoMapper;
using LivrariaFiap.Application.Dtos;
using LivrariaFiap.Application.PedidosServices;
using LivrariaFiap.Domain.Abstractions;
using LivrariaFiap.Domain.Entities;

namespace LivrariaFiap.Application.LivroServices
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _repository;
        private readonly IMapper _mapper;
        public PedidoService(IPedidoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Alterar(int id, PedidoDto dto)
        {
            var pedidoResponseDto = await ObterPorId(id) ?? throw new Exception("Pedido não existe");

            var entity = _mapper.Map<Pedido>(pedidoResponseDto);

            _mapper.Map(dto, entity);

            entity.Id = id;

            _repository.Alterar(entity);

        }

        public async Task Cadastrar(PedidoDto dto)
        {
            var entity = _mapper.Map<Pedido>(dto);

            _repository.Cadastrar(entity);
        }

        public async Task Deletar(int id)
        {
            _repository.Deletar(id);
        }

        public async Task<PedidoResponseDto>? ObterPorId(int id)
        {
            var pedido = _repository.ObterPorId(id);

            return _mapper.Map<PedidoResponseDto>(pedido);
        }

        public async Task<List<PedidoResponseDto>> ObterTodos()
        {
            var pedidos = _repository.ObterTodos();

            var response = new List<PedidoResponseDto>();

            foreach (var pedido in pedidos)
            {
                var pedidoDto = _mapper.Map<PedidoResponseDto>(pedido);

                response.Add(pedidoDto);
            }

            return response;

        }
    }
}
