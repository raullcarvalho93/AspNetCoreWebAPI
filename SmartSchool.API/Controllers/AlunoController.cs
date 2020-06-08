using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        public List<Aluno> Alunos = new List<Aluno>(){
            new Aluno(){
                Id = 1,
                Nome = "Marcos",
                Sobrenome = "Almeida",
                Telefone = "12312331",
            },
            new Aluno(){
                Id = 2,
                Nome = "Andre",
                Sobrenome = "Abreu",
                Telefone = "16778843",
            },
            new Aluno(){
                Id = 3,
                Nome = "Paula",
                Sobrenome = "Fernandes",
                Telefone = "12345643",
            }
        };

        // GET: api/Aluno
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }

        // GET: api/Aluno/ById?id=x
        [HttpGet("ById")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.Where(a => a.Id == id);
            if (aluno != null)
                return Ok(aluno);
            return BadRequest("Aluno não encontrado");  
        }

        // GET: api/Aluno/ByName?nome=xxx&sobrenome=xxx
        [HttpGet("ByName")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            var aluno = Alunos.Where(a => a.Nome == nome && a.Nome == sobrenome);
            if (aluno != null)
                return Ok(aluno);
            return BadRequest("Aluno não encontrado");
        }

        // POST: api/Aluno
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            return Ok(aluno);
        }

        // PUT: api/Aluno/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        // PUT: api/Aluno/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        // PUT: api/Aluno/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
