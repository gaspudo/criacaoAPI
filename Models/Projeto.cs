using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ExoApi.Models
{
    [Table("tb_projetos")]
    public class Projeto
    {
        [Key]
        [Column("cd_projeto")]
        public int Id {get;set;}
        [Column("nm_projeto")]
        public string Nome {get;set;} = string.Empty;
        [Column("nm_area")]
        public string Area {get;set;} = string.Empty;
        [Column("fl_status")]
        public bool Status {get;set;}
    }
}