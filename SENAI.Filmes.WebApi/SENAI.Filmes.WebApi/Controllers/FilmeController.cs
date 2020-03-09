using Microsoft.AspNetCore.Mvc;
using senai.Filmes.WebApi.Domains;
using senai.Filmes.WebApi.Interfaces;
using senai.Filmes.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Filmes.WebApi.Controllers  
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class FilmeController : ControllerBase
    {
        public FilmeController()
        {
            _filmeRepository = new FilmeRepository();
        }

        private IFilmeRepository _filmeRepository { get; set; }

        [HttpGet]
        public IEnumerable<FilmeDomain> Get()
        {
            return _filmeRepository.Listar();
        }

        [HttpPost] //Post no banco de dados é CREATE
        public IActionResult Post(FilmeDomain novoFilme)
        {
            _filmeRepository.Cadastrar(novoFilme);

            return StatusCode(201);
        }

        [HttpPost("{id}")]
        public IActionResult GetById(int id)
        {
            FilmeDomain FilmeBuscado = _filmeRepository.BuscarPorID(id);

            if (FilmeBuscado == null)
            {
                return NotFound("Nenhum Filme encontrado com esse ID");
            }
            return Ok(FilmeBuscado);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _filmeRepository.Deletar(id);

            return Ok("Gênero deletado"); //200 - OK
        }

        //FilmeAtualizado pega a informação colocada no PostMan
        [HttpPut]
        public IActionResult AtualizarIdCorpo(FilmeDomain FilmeAtualizado)
        {
            FilmeDomain FilmeBuscado = _filmeRepository.BuscarPorID(FilmeAtualizado.IdFilme);

            if (FilmeBuscado == null)
            {
                try
                {                   
                    _filmeRepository.AtualizarIdCorpo(FilmeAtualizado);

                    return NoContent();
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }
            }
            return NotFound
                (
                    new
                    {
                        mensagem = "Gênero não encontrado",
                    }
                );
        
        }
    }
}
