using AutoMapper;
using LivrariaFiap.Application.Dtos;
using LivrariaFiap.Domain.Abstractions;
using LivrariaFiap.Domain.Entities;

namespace LivrariaFiap.Application.LivroServices
{
    public class LivroService : ILivroService
    {
        private readonly ILivroRepository _repository;
        private readonly IMapper _mapper;
        public LivroService(ILivroRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Alterar(int id, LivroDto dto)
        {
            var livroResponseDto = await ObterPorId(id) ?? throw new Exception("Livro não existe");

            var entity = _mapper.Map<Livro>(livroResponseDto);

            _mapper.Map(dto, entity);

            entity.Id = id;

            _repository.Alterar(entity);

        }

        public async Task Cadastrar(LivroDto dto)
        {
            var entity = _mapper.Map<Livro>(dto);

            _repository.Cadastrar(entity);
        }

        public async Task Deletar(int id)
        {
            _repository.Deletar(id);
        }

        public async Task<LivroResponseDto>? ObterPorId(int id)
        {
            var livro = _repository.ObterPorId(id);

            return _mapper.Map<LivroResponseDto>(livro);
        }

        public async Task<List<LivroResponseDto>> ObterTodos()
        {
            var livros = _repository.ObterTodos();

            var response = new List<LivroResponseDto>();

            foreach (var livro in livros)
            {
                var livroDto = _mapper.Map<LivroResponseDto>(livro);

                response.Add(livroDto);
            }

            return response;

        }
    }
}
