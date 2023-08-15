using FilmesApi.Data.DTOs;
using FilmesApi.Models;

namespace FilmesApi.Repositories
{
    public interface IFilmeRepository
    {
        void Adiciona(Filme filme);
        void Atualiza(Filme filme);
        List<Filme> Recupera(int take);
        Filme RecuperaPorId(int id);
        void Remove(Filme filme);

    }
}
