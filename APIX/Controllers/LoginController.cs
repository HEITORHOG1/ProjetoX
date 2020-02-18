using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIX.Dal;
using APIX.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIX.Controllers
{
    [Produces("application/json")]
    [Route("api/Login")]
    public class LoginController : Controller
    {
        private readonly IMetodosLogin _Dal;

        public LoginController(IMetodosLogin dal)
        {
            _Dal = dal;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _Dal.Get();
            return Ok(result);
        }

        [HttpPost, Route("InserirLogin")]
        public IActionResult Create([FromBody] LoginDto dto)
        {
            if (dto == null)
                return BadRequest();

            var status = _Dal.Post(dto);

            if (status != 1)
                return StatusCode(500, "Erro ao incluir a selecao");

            return Ok();
        }

        [HttpGet("PesquisarPorId/{id}")]
        public IActionResult Get(int id)
        {
            var selecao = _Dal.ObterPorId(id);

            if (selecao == null)
                return NotFound();

            return Ok(selecao);
        }

        [HttpPut, Route("AlterarLogin")]
        public IActionResult Put([FromBody] LoginDto dto)
        {
            if (dto == null)
                return BadRequest();

            var status = _Dal.Put(dto);

            if (status != 1)
                return StatusCode(500, "Erro ao atualizar a selecao");

            return NoContent();
        }

        [HttpDelete("DeletarLogin/{id}")]
        public IActionResult Delete(int id)
        {
            var status = _Dal.Delete(id);

            if (status != 1)
                return StatusCode(500, "Erro ao excluir a selecao");

            return NoContent();
        }

        [HttpGet("ValidarLogin/{email}/{senha}")]
        public IActionResult ValidarLogin(string email, string senha)
        {
            var dto = _Dal.ValidarLogin(email, senha);

            if (dto == null)
                return NotFound();

            return Ok(dto);
        }
    }
}
