using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BackEnd.Models
{
    [Table("tb_filme_ator")]
    [Index(nameof(FkAtor), Name = "fk_ator")]
    [Index(nameof(FkFilme), Name = "fk_filme")]
    public partial class TbFilmeAtor
    {
        [Key]
        [Column("id_filme_ator")]
        public int IdFilmeAtor { get; set; }
        [Column("fk_filme")]
        public int? FkFilme { get; set; }
        [Column("fk_ator")]
        public int? FkAtor { get; set; }
        [Column("nm_personagem")]
        [StringLength(50)]
        public string NmPersonagem { get; set; }
        [Column("ds_foto")]
        [StringLength(30)]
        public string DsFoto { get; set; }

        [ForeignKey(nameof(FkAtor))]
        [InverseProperty(nameof(TbAtor.TbFilmeAtors))]
        public virtual TbAtor FkAtorNavigation { get; set; }
        [ForeignKey(nameof(FkFilme))]
        [InverseProperty(nameof(TbFilme.TbFilmeAtors))]
        public virtual TbFilme FkFilmeNavigation { get; set; }
    }
}
