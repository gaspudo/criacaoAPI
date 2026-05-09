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
    }
}