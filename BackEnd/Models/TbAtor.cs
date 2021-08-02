using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BackEnd.Models
{
    [Table("tb_ator")]
    public partial class TbAtor
    {
        public TbAtor()
        {
            TbFilmeAtors = new HashSet<TbFilmeAtor>();
        }

        [Key]
        [Column("id_ator")]
        public int IdAtor { get; set; }
        [Column("nm_ator")]
        [StringLength(50)]
        public string NmAtor { get; set; }
        [Column("ds_descricao")]
        [StringLength(50)]
        public string DsDescricao { get; set; }
        [Column("dt_nascimento", TypeName = "date")]
        public DateTime? DtNascimento { get; set; }
        [Column("nm_pais")]
        [StringLength(20)]
        public string NmPais { get; set; }
        [Column("ds_foto")]
        [StringLength(30)]
        public string DsFoto { get; set; }

        [InverseProperty(nameof(TbFilmeAtor.FkAtorNavigation))]
        public virtual ICollection<TbFilmeAtor> TbFilmeAtors { get; set; }
    }
}
