using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Repositories
{
    public class FilmeContext : DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> opts)
            : base(opts)
        {

        }

        public DbSet<Filme> Filmes { get; set; }


    }
}
