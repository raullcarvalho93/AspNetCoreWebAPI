using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly SmartContext _context;
        public AlunoController(SmartContext context)
        {
            _context = context;
        }

        // GET: api/Aluno
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Alunos);
        }

        // GET: api/Aluno/ById?id=x
        [HttpGet("ById/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _context.Alunos.Where(a => a.Id == id);
            if (aluno != null)
                return Ok(aluno);
            return BadRequest("Aluno não encontrado");  
        }

        // GET: api/Aluno/ByName?nome=xxx&sobrenome=xxx
        [HttpGet("ByName")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            var aluno = _context.Alunos.Where(a => a.Nome == nome && a.Sobrenome == sobrenome);
            if (aluno != null)
                return Ok(aluno);
            return BadRequest("Aluno não encontrado");
        }

        // POST: api/Aluno
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        // PUT: api/Aluno/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var alu = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (alu == null) return BadRequest("Aluno não encontrado");
            _context.Alunos.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        // PUT: api/Aluno/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var alu = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (alu == null) return BadRequest("Aluno não encontrado");
            _context.Alunos.Update(aluno) ;
            _context.SaveChanges();
            return Ok(aluno);
        }

        // PUT: api/Aluno/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("Aluno não encontrado");
            _context.Alunos.Remove(aluno);
            _context.SaveChanges();
            return Ok();
        }
    }
}
