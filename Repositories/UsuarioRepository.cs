using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExoApi.Contexts;
using ExoApi.Models;

namespace ExoApi.Repositories
{
    public class UsuarioRepository
    {
        private readonly ExoContext _context;

        public UsuarioRepository (ExoContext contexto)
        {
            _context = contexto;
        }

        public IEnumerable<Usuario> Listar()
        {
            return _context.Usuarios.ToList();
        }

        public void Cadastrar (Usuario user)
        {
            _context.Usuarios.Add(user);
            _context.SaveChanges();
        }

        public Usuario BuscaPorId (int id)
        {
            return _context.Usuarios.Find(id)!;
        }

        public void Atualizar (int id, Usuario user)
        {
            Usuario? userBuscado = _context.Usuarios.Find(id);
            
            if (userBuscado != null)
            {
            
            userBuscado.Email = user.Email;
            userBuscado.Senha = user.Senha;
            _context.Usuarios.Update(userBuscado);
            }
            
            _context.SaveChanges();
        }

        public void Deletar (int id)
        {
            Usuario? userBuscado = _context.Usuarios.Find(id);

            if (userBuscado == null)
            {
                throw new Exception("Usuário não encontrado");
            }
                _context.Usuarios.Remove(userBuscado);
                _context.SaveChanges();
        }

        public Usuario Login (string email, string senha)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha) ?? throw new InvalidOperationException("Não foi possível realizar o login tente novamente.");
        }
    }
}