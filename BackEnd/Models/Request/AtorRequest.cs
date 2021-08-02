using System;

namespace BackEnd.Models.Request
{
    public class AtorRequest
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }  
        public DateTime? Nascimento { get; set; } 
        public string Pais {get; set;}

    }
}