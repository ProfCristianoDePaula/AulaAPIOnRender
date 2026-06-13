using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlunosController : ControllerBase
{
    // GET: api/alunos
    [HttpGet]
    public IActionResult Get()
    {
        var alunos = new[]
        {
            new
            {
                Id = 1,
                Nome = "João Silva",
                Curso = "Desenvolvimento de Sistemas"
            },
            new
            {
                Id = 2,
                Nome = "Maria Souza",
                Curso = "Engenharia Elétrica"
            },
            new
            {
                Id = 3,
                Nome = "José Oliveira",
                Curso = "Mecânica de Usinagem"
            }
        };

        return Ok(alunos);
    }

    // GET: api/alunos/1
    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        return Ok(new
        {
            Id = id,
            Nome = "Aluno Teste",
            Curso = "ASP.NET Core 10"
        });
    }

    // POST: api/alunos
    [HttpPost]
    public IActionResult Create([FromBody] NovoAlunoRequest request)
    {
        return CreatedAtAction(
            nameof(GetById),
            new { id = 4 },
            new
            {
                Id = 4,
                request.Nome,
                request.Curso
            });
    }

    // PUT: api/alunos/1
    [HttpPut("{id:int}")]
    public IActionResult Update(
        int id,
        [FromBody] NovoAlunoRequest request)
    {
        return Ok(new
        {
            Id = id,
            request.Nome,
            request.Curso,
            Mensagem = "Aluno atualizado com sucesso."
        });
    }

    // DELETE: api/alunos/1
    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        return NoContent();
    }
}

public record NovoAlunoRequest(
    string Nome,
    string Curso
);