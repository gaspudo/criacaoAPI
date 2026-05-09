using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExoApi.Contexts;
using ExoApi.Models;

namespace ExoApi.Repositories
{
    public class ProjetoRepository
    {
        private readonly ExoContext _context;

        public ProjetoRepository (ExoContext contexto)
        {
            _context = contexto;
        }

        public IEnumerable<Projeto> Listar()
        {
            return _context.Projetos.ToList();
        }
    }
}