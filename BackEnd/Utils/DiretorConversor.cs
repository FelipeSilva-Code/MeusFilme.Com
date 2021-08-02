using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Models;
using System.Collections.Generic;
using BackEnd.Models.Request;
using BackEnd.Models.Response;

namespace BackEnd.Utils
{
    public class DiretorConversor
    {

        public TbDiretor ConverteParaTbDiretor (DiretorRequest request)
        {
            TbDiretor diretor = new TbDiretor();

            diretor.DsDescricao  = request.Descricao;
            diretor.DtNascimento = request.Nascimento;
            diretor.NmDiretor    = request.Nome;
            diretor.NmPais       = request.Pais;

            return diretor;
        }

        public DiretorResponse ConverteParaDiretorResponse (TbDiretor diretor)
        {
            DiretorResponse response = new DiretorResponse();

            response.Id         = diretor.IdDiretor;
            response.Descricao  = diretor.DsDescricao;
            response.Nascimento = diretor.DtNascimento;
            response.Nome       = diretor.NmDiretor;
            response.Pais       = diretor.NmPais;

            return response;
        }
    }
}