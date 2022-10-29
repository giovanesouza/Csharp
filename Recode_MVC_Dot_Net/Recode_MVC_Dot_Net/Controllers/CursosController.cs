using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Recode_MVC_Dot_Net.Models;
using System;

namespace Recode_MVC_Dot_Net.Controllers
{
    public class CursosController : Controller
    {

        // * INÍCIO BLOCO
        // SEM ESSE BLOCO FICA INVIÁVEL A CRIAÇÃO DE VIEWS
        // HÁ IMPORTAÇÃO DO MODELS

        // CRIA OBJETO DO TIPO CONTEXTO
        private readonly CursoDBContext _context;

        // CONSTRUTOR
        public CursosController(CursoDBContext context)
        {
            _context = context;
        }

        // * FIM BLOCO

        public IActionResult Index()
        {

            // _context = banco de dados offline.
            // Faz um select e lista todos os cadastros

            return View(_context.Curso.ToList());
        }



        // GET: Cursos/Create => ROTA PARA INSERÇÃO / APENAS VIEW
        public IActionResult Create()
        {
            return View();
        }


        // INSERE OS DADOS NO BANCO
        [HttpPost]
        public IActionResult Create([Bind("CursoId,Descricao,CargaHoraria")] Curso curso)
        {
            // Verifica se o modelo é válido. Caso verdadeiro, adiciona o objeto "curso",
            // faz as mudanças com os dados inseridos e redireciona para a view especificada nos parênteses.
            if (ModelState.IsValid)
            {
                _context.Add(curso);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(curso);
        }




        // GET: Cursos/Edit/5
        // Recebe o id como parâmetro.
        // Chama a página e passa objeto para mostrar os dados
        public IActionResult Edit(int? id)

        {
            if (id == null || _context.Curso == null)
            {
                return NotFound();
            }
            var curso = _context.Curso.Find(id);
            if (curso == null)
            {
                return NotFound();
            }
            return View(curso);
        }


        // Atualiza os dados

        [HttpPost]
        public IActionResult Edit(int id, [Bind("CursoId,Descricao,CargaHoraria")] Curso curso)
        {
            if (id != curso.CursoId)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(curso);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CursoExists(curso.CursoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(curso);
        }

        // REFERENTE AO CÓDIGO DE ATUALIZAÇÃO ACIMA HTTPPOST
        private bool CursoExists(int cursoId)
        {
            throw new NotImplementedException();
        }




        // VIEW COM OS DADOS DO CADASTROS PARA CONFIRMAR A EXCLUSÃO
        public IActionResult Delete(int? id)
        {
            if (id == null || _context.Curso == null)
            {
                return NotFound();
            }


            var curso = _context.Curso.FirstOrDefault(m => m.CursoId == id);
            if (curso == null)
            {
                return NotFound();
            }


            return View(curso);
        }


        // EXCLUI O CADASTRO
        [HttpPost, ActionName("Delete")]

        public IActionResult DeleteConfirmed(int id)
        {
            if (_context.Curso == null)
            {
                return Problem("Entity set 'CursoDBContext.Curso'  is null.");
            }
            var curso = _context.Curso.Find(id);
            if (curso != null)
            {
                _context.Curso.Remove(curso);
            }

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        // MOSTRA DETALHES DO CADASTRO
        public IActionResult Details(int? id)
        {
            if (id == null || _context.Curso == null)
            {
                return NotFound();
            }



            var curso = _context.Curso.FirstOrDefault(m => m.CursoId == id);
            if (curso == null)
            {
                return NotFound();
            }



            return View(curso);
        }










    }
}
