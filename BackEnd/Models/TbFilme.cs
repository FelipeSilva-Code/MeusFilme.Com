using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BackEnd.Models
{
    [Table("tb_filme")]
    [Index(nameof(FkDiretor), Name = "fk_diretor")]
    public partial class TbFilme
    {
        public TbFilme()
        {
            TbFilmeAtors = new HashSet<TbFilmeAtor>();
        }

        [Key]
        [Column("id_filme")]
        public int IdFilme { get; set; }
        [Column("fk_diretor")]
        public int? FkDiretor { get; set; }
        [Column("nm_filme")]
        [StringLength(50)]
        public string NmFilme { get; set; }
        [Column("ds_descricao")]
        [StringLength(50)]
        public string DsDescricao { get; set; }
        [Column("dt_lancamento", TypeName = "date")]
        public DateTime? DtLancamento { get; set; }
        [Column("ds_genero")]
        [StringLength(20)]
        public string DsGenero { get; set; }
        [Column("nr_nota")]
        public decimal? NrNota { get; set; }
        [Column("ds_lingua")]
        [StringLength(20)]
        public string DsLingua { get; set; }
        [Column("ds_tipo")]
        [StringLength(10)]
        public string DsTipo { get; set; }
        [Column("ds_foto")]
        [StringLength(30)]
        public string DsFoto { get; set; }

        [ForeignKey(nameof(FkDiretor))]
        [InverseProperty(nameof(TbDiretor.TbFilmes))]
        public virtual TbDiretor FkDiretorNavigation { get; set; }
        [InverseProperty(nameof(TbFilmeAtor.FkFilmeNavigation))]
        public virtual ICollection<TbFilmeAtor> TbFilmeAtors { get; set; }
    }
}
