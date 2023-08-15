using FilmesApi.Data.DTOs;
using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FilmesApi.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {

        private readonly FilmeContext _context;

        public FilmeRepository(FilmeContext context)
        {
            _context = context;
        }

        public void Adiciona(Filme filme)
        {
            _context.Add(filme);
            _context.SaveChanges();
        }

        public List<Filme> Recupera(int take)
        {
            return _context.Filmes.Take(take).ToList();
        }

        public Filme? RecuperaPorId(int id)
        {
            return _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        }

        public void Atualiza(Filme filme)
        {
            _context.Filmes.Update(filme);
            _context.SaveChanges();
        }
        public void Remove(Filme filme)
        {
            _context.Remove(filme);
            _context.SaveChanges();
        }
    }
}
