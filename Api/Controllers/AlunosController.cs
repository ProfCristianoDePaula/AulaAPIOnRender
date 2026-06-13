using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlunosController : ControllerBase
{
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

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        return Ok(new
        {
            Id = id,
            Nome = "Aluno Teste",
            Curso = "ASP.NET Core"
        });
    }

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
}

public record NovoAlunoRequest(
    string Nome,
    string Curso
);