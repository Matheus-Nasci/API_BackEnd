using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.DataBaseFirst.Domains;
using Senai.InLock.WebApi.DataBaseFirst.Interfaces;
using Senai.InLock.WebApi.DataBaseFirst.Repositories;

namespace Senai.InLock.WebApi.DataBaseFirst.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class EstudiosController : ControllerBase
    {
        private IEstudiosRepository _estudiosRepository;

        public EstudiosController()
        {
            _estudiosRepository = new EstudioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_estudiosRepository.Listar());
        }

        [HttpPost]
        public IActionResult Post(Estudio novoEstudio)
        {
            _estudiosRepository.Cadastrar(novoEstudio);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Estudio estudioAtualizado)
        {
            Estudio estudio = _estudiosRepository.BuscarPorId(id);

            if(id == null)
            {
                try
                {
                    _estudiosRepository.Atualizar(id, estudioAtualizado);
                }
                catch (Exception erro)
                {
                    return BadRequest(erro);
                }

                return NotFound("Id Especificado não encontrada");
            }

            return StatusCode(404);
        }
    }
}