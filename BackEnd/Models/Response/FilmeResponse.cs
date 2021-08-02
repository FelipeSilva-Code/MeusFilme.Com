using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Models;
using System.Collections.Generic;

namespace BackEnd.Models.Response
{
    public class FilmeResponse
    {
        public int IdFilme { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime? Lancamento { get; set; }
        public string Genero { get; set; }
        public decimal? Nota { get; set; }
        public string Lingua { get; set; }
        public string Tipo {get; set;}
        public DiretorResponse Diretor {get; set;}
        public List<FilmeAtorResponse> Atores {get; set;}

    }
}