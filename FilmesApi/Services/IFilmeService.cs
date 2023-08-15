using FilmesApi.Data.DTOs;
using FilmesApi.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace FilmesApi.Services
{
    public interface IFilmeService
    {
        void Adiciona(CreateFilmeDTO filmeDTO);        
        List<ReadFilmeDTO> Recupera(int take);
        ReadFilmeDTO RecuperaPorId(int id);
        UpdateFilmeDTO RecuperaUpdateParcial(int id);
        void Atualiza(int id, UpdateFilmeDTO filmeDTO);
        void Remove(int id);
    }
}
