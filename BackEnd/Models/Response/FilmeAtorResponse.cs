using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Models;
using System.Collections.Generic;

namespace BackEnd.Models.Response
{
    public class FilmeAtorResponse
    {
        public int Id { get; set; }
        public FilmeResponse Filme { get; set; }
        public AtorResponse Ator {get; set;}
        public string Personagem { get; set; }
    }
}