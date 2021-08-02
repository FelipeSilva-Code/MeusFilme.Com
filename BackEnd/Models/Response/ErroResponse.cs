using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Models;
using System.Collections.Generic;

namespace BackEnd.Models.Response
{
    public class ErroResponse
    {
        public int Codigo { get; set; }
        public string Mensagem { get; set; }

        public ErroResponse()
        {
        }

        public ErroResponse(int cdg, string msg)
        {
            this.Codigo   = cdg;
            this.Mensagem = msg;
        }
    }
}