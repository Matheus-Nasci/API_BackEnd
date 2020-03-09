using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domain;
using Senai.Peoples.WebApi.Repositories;

namespace Senai.Peoples.WebApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]

    public class PeopleController : ControllerBase
    {
        private PeopleRepository _peopleRepository;

        public PeopleController()
        {
            _peopleRepository = new PeopleRepository();
        }

        [HttpGet]
        public IEnumerable<PeopleDomain> Get()
        {
            return _peopleRepository.Listar();
        }

        [HttpPost]
        public IActionResult Post(PeopleDomain people)
        {
            _peopleRepository.Cadastrar(people);

            return StatusCode(201);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            PeopleDomain IdBuscado = _peopleRepository.BuscarPorId(id);

            if(IdBuscado == null)
            {
                return NotFound("ID especificado na URL não encontrado");
            }
            return Ok(IdBuscado);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarPorID(PeopleDomain peopleAtualizado)
        {
            PeopleDomain peopleBuscada = _peopleRepository.BuscarPorId(peopleAtualizado.IdFucionario);

            if(peopleBuscada == null)
            {
                return NotFound("ID que você deseja Atualizar é inexistente");
            }
            return Ok(peopleBuscada);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _peopleRepository.Delete(id);

            return Ok("Pessoa Deletada");
        }
    }
}