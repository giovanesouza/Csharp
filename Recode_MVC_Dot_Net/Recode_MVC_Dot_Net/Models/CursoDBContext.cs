// IMPORT
using Microsoft.EntityFrameworkCore;

// PACOTE
namespace Recode_MVC_Dot_Net.Models
{

    // CLASSE DE CONTEXTO
    public class CursoDBContext : DbContext
    {
        public CursoDBContext(DbContextOptions<CursoDBContext> options)
          : base(options)
        { }


        public DbSet<Curso> Curso { get; set; }
    }
}