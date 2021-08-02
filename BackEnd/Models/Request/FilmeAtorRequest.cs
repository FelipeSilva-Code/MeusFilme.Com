using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Models;
using System.Collections.Generic;

namespace BackEnd.Models.Request
{
    public class FilmeAtorRequest
    {
        public int? IdFilme { get; set; }
        public int? IdAtor { get; set; }
        public string Personagem { get; set; }
    }
}