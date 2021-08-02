using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BackEnd.Models
{
    [Table("tb_usuario")]
    public partial class TbUsuario
    {
        [Key]
        [Column("id_usuario")]
        public int IdUsuario { get; set; }
        [Column("nm_usuario")]
        [StringLength(100)]
        public string NmUsuario { get; set; }
        [Column("ds_email")]
        [StringLength(60)]
        public string DsEmail { get; set; }
        [Column("ds_senha")]
        [StringLength(60)]
        public string DsSenha { get; set; }
        [Column("ds_permissao")]
        [StringLength(30)]
        public string DsPermissao { get; set; }
        [Column("ds_foto")]
        [StringLength(30)]
        public string DsFoto { get; set; }
    }
}
