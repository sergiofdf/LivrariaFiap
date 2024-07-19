using AutoMapper;
using LivrariaFiap.Application.Dtos;
using LivrariaFiap.Application.LivroServices;
using LivrariaFiap.Domain.Abstractions;
using LivrariaFiap.Domain.Entities;

namespace LivrariaFiap.Application.PedidosServices
{
    public class ItemPedidoService : IItemPedidoService
    {
        private readonly IItemPedidoRepository _repository;
        private readonly ILivroService _livroService;
        private readonly IMapper _mapper;
        public ItemPedidoService(IItemPedidoRepository repository, IMapper mapper, ILivroService livroService)
        {
            _repository = repository;
            _mapper = mapper;
            _livroService = livroService;
        }

        public async Task Alterar(int id, ItemPedidoDto dto)
        {
            var itemPedidoResponseDto = await ObterPorId(id) ?? throw new Exception("Item não existe");
            var livroResponseDto = await _livroService.ObterPorId(dto.LivroId) ?? throw new Exception("Livro do pedido não encontrado.");

            var entity = _mapper.Map<ItemPedido>(itemPedidoResponseDto);

            _mapper.Map(dto, entity);

            entity.Id = id;

            entity.PrecoTotalItem = entity.Quantidade * livroResponseDto.Preco;

            _repository.Alterar(entity);

        }

        public async Task Cadastrar(ItemPedidoDto dto)
        {
            var entity = _mapper.Map<ItemPedido>(dto);

            var livroResponseDto = await _livroService.ObterPorId(dto.LivroId) ?? throw new Exception("Livro do pedido não encontrado.");

            entity.PrecoTotalItem = entity.Quantidade * livroResponseDto.Preco;

            _repository.Cadastrar(entity);
        }

        public async Task Deletar(int id)
        {
            _repository.Deletar(id);
        }

        public async Task<ItemPedidoResponseDto>? ObterPorId(int id)
        {
            var itemPedido = _repository.ObterPorId(id);

            return _mapper.Map<ItemPedidoResponseDto>(itemPedido);
        }

        public async Task<List<ItemPedidoResponseDto>> ObterTodos()
        {
            var itensPedido = _repository.ObterTodos();

            var response = new List<ItemPedidoResponseDto>();

            foreach (var itemPedido in itensPedido)
            {
                var itemPedidoDto = _mapper.Map<ItemPedidoResponseDto>(itemPedido);

                response.Add(itemPedidoDto);
            }

            return response;

        }
    }
}
