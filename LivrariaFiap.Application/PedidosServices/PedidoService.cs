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
        private readonly ILivroRepository _livroRepository;
        private readonly IMapper _mapper;
        public PedidoService(IPedidoRepository repository, IMapper mapper, ILivroRepository livroRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _livroRepository = livroRepository;
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

            foreach (var item in entity.ItemsPedido)
            {
                var livro = _livroRepository.ObterPorId(item.LivroId) ?? throw new Exception("Item do pedido não encontrado.");
                item.PrecoTotalItem = item.Quantidade * livro.Preco;
                entity.ValorPedido += item.PrecoTotalItem;
            }

            _repository.Cadastrar(entity);
        }

        public async Task Deletar(int id)
        {
            _repository.Deletar(id);
        }

        public async Task<PedidoResponseDto>? ObterPorId(int id)
        {
            var pedido = _repository.ObterPorIdComItens(id);

            return _mapper.Map<PedidoResponseDto>(pedido);
        }

        public async Task<List<PedidoResponseDto>> ObterPedidosCliente(int idCliente)
        {
            var pedidos = _repository.ObterPedidosCliente(idCliente);

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
