using System;

namespace BackEnd.Models.Abstract
{
    public abstract class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime? Nascimento { get; set; }
        public string Pais { get; set; }
    }
}