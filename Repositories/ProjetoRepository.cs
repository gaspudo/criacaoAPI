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

        public void Cadastrar (Projeto proj)
        {
            _context.Projetos.Add(proj);
            _context.SaveChanges();
        }

        public Projeto BuscarPorId (int id)
        {
            return _context.Projetos.Find(id)!;
        }

        public void Atualizar (int id, Projeto proj)
        {
            Projeto? projBuscado = _context.Projetos.Find(id);
            
            if (projBuscado != null)
            {
            
            projBuscado.Nome = proj.Nome;
            projBuscado.Area = proj.Area;
            projBuscado.Status = proj.Status;
            _context.Projetos.Update(projBuscado);
            }
            
            _context.SaveChanges();
        }

        public void Deletar (int id)
        {
            Projeto? projBuscado = _context.Projetos.Find(id);

            if (projBuscado == null)
            {
                throw new Exception("Projeto não encontrado");
            }
                _context.Projetos.Remove(projBuscado);
                _context.SaveChanges();
        }
    }
}