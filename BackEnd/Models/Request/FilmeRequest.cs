using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Models;
using System.Collections.Generic;

namespace BackEnd.Models.Request
{
    public class FilmeRequest
    {
        public int? IdDiretor {get; set;}
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime? Lancamento { get; set; }
        public string Genero { get; set; }
        public decimal? Nota { get; set; }
        public string Lingua { get; set; }
        public string Tipo { get; set; }
       
    }
}