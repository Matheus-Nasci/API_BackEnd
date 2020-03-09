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
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _UsuarioRepository;

        public UsuarioController()
        {
            _UsuarioRepository = new UsuarioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_UsuarioRepository.Listar());
        }

        [HttpPost]
        public IActionResult Post(Usuario novoUsuario)
        {
            _UsuarioRepository.Cadastrar(novoUsuario);

            return StatusCode(201);
        }
    }
}