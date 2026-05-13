using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExoApi.Repositories;
using ExoApi.Models;
using System.Net.Http.Headers;

namespace ExoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjetosController : ControllerBase
    {
        private readonly ProjetoRepository _repository;

        public ProjetosController (ProjetoRepository repo)
        {
            _repository = repo;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_repository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar (Projeto proj)
        {
            _repository.Cadastrar(proj);
            return StatusCode(201);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId (int id)
        {
            Projeto proj = _repository.BuscarPorId(id);
            if (proj == null)
            {
                return NotFound();
                //poderia ser tambem -> return StatusCode(404)  ;
            }
            return Ok(proj);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar (int id, Projeto proj)
        {
            Projeto projetoExistente = _repository.BuscarPorId(id);
            if (projetoExistente == null)
            {
                return NotFound();
            }
            _repository.Atualizar(id, proj);
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