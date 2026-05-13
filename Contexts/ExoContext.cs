using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExoApi.Models;

namespace ExoApi.Contexts
{
    public class ExoContext : DbContext
    {
        public ExoContext(DbContextOptions<ExoContext> options) : base(options) {}

        public DbSet<Projeto> Projetos {get;set;}
        public DbSet<Usuario> Usuarios {get;set;}
    }
}