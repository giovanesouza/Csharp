using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecodeAPI.Models;

namespace RecodeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {

        private readonly CursoDbContext _context;
        public CursoController(CursoDbContext context)
        {
            _context = context;
        }

        // GET: api/Cursos - LISTA TODOS OS CURSOS
        [HttpGet]
        public IEnumerable<Curso> GetCursos()
        {
            return _context.Cursos;
        }


        // GET: api/Cursos/id - LISTA CURSO POR ID
        [HttpGet("{id}")]
        public IActionResult GetCursoPorId(int id)
        {
            Curso curso = _context.Cursos.SingleOrDefault(modelo => modelo.CursoId == id);
            if (curso == null)
            {
                return NotFound();
            }
            return new ObjectResult(curso);
        }


        // CRIA UM NOVO CURSO
        [HttpPost]
        public IActionResult CriarCurso(Curso item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Cursos.Add(item);
            _context.SaveChanges();
            return new ObjectResult(item);

        }


        // ATUALIZA UM CURSO EXISTENTE
        [HttpPut("{id}")]
        public IActionResult AtualizaCurso(int id, Curso item)
        {
            if (id != item.CursoId)
            {
                return BadRequest();
            }
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();



            return new NoContentResult();
        }


        // APAGA UM CURSO POR ID
        [HttpDelete("{id}")]
        public IActionResult DeletaCurso(int id)
        {
            var curso = _context.Cursos.SingleOrDefault(m => m.CursoId == id);


            if (curso == null)
            {
                return BadRequest();
            }


            _context.Cursos.Remove(curso);
            _context.SaveChanges();
            return Ok(curso);
        }


    }
}
