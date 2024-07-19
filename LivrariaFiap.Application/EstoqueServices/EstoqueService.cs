using AutoMapper;
using LivrariaFiap.Application.Dtos;
using LivrariaFiap.Application.LivroServices;
using LivrariaFiap.Domain.Abstractions;
using LivrariaFiap.Domain.Entities;

namespace LivrariaFiap.Application.EstoqueServices
{
    public class EstoqueService : IEstoqueService
    {
        private readonly IEstoqueRepository _repository;
        private readonly ILivroService _livroService;
        private readonly IMapper _mapper;
        public EstoqueService(IEstoqueRepository repository, ILivroService livroService, IMapper mapper)
        {
            _repository = repository;
            _livroService = livroService;
            _mapper = mapper;
        }

        public async Task Alterar(int id, EstoqueDto dto)
        {
            var estoqueResponse = await ObterPorId(id) ?? throw new Exception("Estoque não existe");

            Estoque entity = _mapper.Map<Estoque>(estoqueResponse);

            _mapper.Map(dto, entity);

            entity.Id = id;

            _repository.Alterar(entity);

        }

        public async Task Cadastrar(EstoqueDto dto)
        {
            var entity = _mapper.Map<Estoque>(dto);

            _repository.Cadastrar(entity);
        }

        public async Task Deletar(int id)
        {
            _repository.Deletar(id);
        }

        public async Task<EstoqueResponseDto>? ObterPorId(int id)
        {
            var estoque = _repository.ObterPorId(id);
            var estoqueResponseDto = _mapper.Map<EstoqueResponseDto>(estoque);

            return estoqueResponseDto;
        }

        public async Task<List<EstoqueResponseDto>> ObterTodos()
        {
            var estoques = _repository.ObterTodos() ?? throw new Exception("Erro ao consultar estoques.");

            List<EstoqueResponseDto> response = [];

            foreach (var estoque in estoques)
            {
                var estoqueResponseDto = _mapper.Map<EstoqueResponseDto>(estoque);
                response.Add(estoqueResponseDto);
            }

            return response;
        }

    }
}
