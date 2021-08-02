using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BackEnd.Models
{
    [Table("tb_diretor")]
    public partial class TbDiretor
    {
        public TbDiretor()
        {
            TbFilmes = new HashSet<TbFilme>();
        }

        [Key]
        [Column("id_diretor")]
        public int IdDiretor { get; set; }
        [Column("nm_diretor")]
        [StringLength(50)]
        public string NmDiretor { get; set; }
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

        [InverseProperty(nameof(TbFilme.FkDiretorNavigation))]
        public virtual ICollection<TbFilme> TbFilmes { get; set; }
    }
}
