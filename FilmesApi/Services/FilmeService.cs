using AutoMapper;
using FilmesApi.Data.DTOs;
using FilmesApi.Models;
using FilmesApi.Repositories;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Services
{
    public class FilmeService : IFilmeService
    {
        private readonly IFilmeRepository _repository;
        private readonly IMapper _mapper;

        public FilmeService(IFilmeRepository repository, 
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Adiciona(CreateFilmeDTO filmeDTO)
        {
            Filme filme = _mapper.Map<Filme>(filmeDTO);
            _repository.Adiciona(filme);
        }

        public List<ReadFilmeDTO> Recupera(int take)
        {
            List<Filme> filme = _repository.Recupera(take);

            return _mapper.Map<List<ReadFilmeDTO>>(filme);
        }

        public UpdateFilmeDTO? RecuperaUpdateParcial(int id)
        {
            Filme filme = _repository.RecuperaPorId(id);

            return _mapper.Map<UpdateFilmeDTO>(filme);
        }

        public ReadFilmeDTO? RecuperaPorId(int id)
        {
            Filme filme = _repository.RecuperaPorId(id);

            return _mapper.Map<ReadFilmeDTO>(filme);
        }

        public void Atualiza(int id, UpdateFilmeDTO filmeDTO)
        {
            var filme = _repository.RecuperaPorId(id);

            var filmeAtt = _mapper.Map(filmeDTO, filme);

            _repository.Atualiza(filmeAtt);
        }
        public void Remove(int id)
        {
            var filme = _repository.RecuperaPorId(id);

            _repository.Remove(filme);
        }


    }
}
