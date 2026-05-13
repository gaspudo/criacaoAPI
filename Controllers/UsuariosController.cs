using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExoApi.Models;
using ExoApi.Repositories;
using ExoApi.Contexts;

namespace ExoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : Controller
    {
        private readonly UsuarioRepository _repository;

        public UsuariosController (UsuarioRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_repository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar (Usuario usuario)
        {
            _repository.Cadastrar(usuario);
            return StatusCode(201);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            
            Usuario user = _repository.BuscarPorId(id);
            if (user == null)
            {
                return NotFound();
                //poderia ser --> return StatusCode(404)  ;
            }
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar (int id, Usuario user)
        {
            Usuario userExistente = _repository.BuscarPorId(id);
            if (userExistente == null)
            {
                return NotFound();
            } 
            _repository.Atualizar(id, user);
            return StatusCode(204);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar (int id)
        {
            try
            {
                _repository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}