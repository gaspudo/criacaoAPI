using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ExoApi.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        [Key]
        [Column("cd_usuario")]
        public int Id {get;set;}

        [Column("ds_email")]
        public string? Email {get;set;}

        [Column("ds_senha")]
        public string? Senha {get;set;}
    }
}