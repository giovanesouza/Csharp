using Microsoft.EntityFrameworkCore;

namespace RecodeAPI.Models
{
    public class CursoDbContext : DbContext
    {
        public CursoDbContext(DbContextOptions<CursoDbContext> options)
          : base(options)
        { }

        // RELACIONADO À TABELA DO BD
        public DbSet<Curso> Cursos { get; set; }

    }
}
