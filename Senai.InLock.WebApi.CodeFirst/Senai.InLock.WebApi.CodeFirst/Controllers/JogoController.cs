using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.CodeFirst.Domains;
using Senai.InLock.WebApi.CodeFirst.Interfaces;
using Senai.InLock.WebApi.CodeFirst.Repositories;

namespace Senai.InLock.WebApi.CodeFirst.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class JogoController : ControllerBase
    {
        private IJogosRepository _jogosRepository;

        public JogoController()
        {
            _jogosRepository = new JogosRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_jogosRepository.Listar());
        }

        [HttpPost]
        public IActionResult Post(Jogos novoEstudio)
        {
            _jogosRepository.Cadastrar(novoEstudio);

            return StatusCode(201);
        }
    }
}