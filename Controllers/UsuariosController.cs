using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExoApi.Models;
using ExoApi.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ExoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : Controller
    {
        private readonly UsuarioRepository _repository;
        private IConfiguration _configuration;

        public UsuariosController (UsuarioRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
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
        public IActionResult BuscaPorId(int id)
        {
            
            Usuario user = _repository.BuscaPorId(id);
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
            Usuario userExistente = _repository.BuscaPorId(id);
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

        [HttpPost("login")]
        public IActionResult Login (Usuario user)
        {
            Usuario userBuscado = _repository.Login(user.Email!, user.Senha!);
            if (userBuscado == null)
            {
                return NotFound(new {mensagem = "Email ou senha inválidos"});
            }
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, userBuscado.Email!),
                new Claim(JwtRegisteredClaimNames.Jti, userBuscado.Id.ToString()),
            };

            var secretKey = _configuration["JwtSettings:SecretKey"];
            if (string.IsNullOrEmpty(secretKey)) throw new InvalidOperationException("Chave JWT não configurada corretamente");
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials (key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken (
                issuer: "exoapi.webapi",
                audience:"exoapi.webapi",
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: creds
            );
            return Ok(new {token = new JwtSecurityTokenHandler().WriteToken(token)});
        }
    }
}