using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Models;
using System.Collections.Generic;
using BackEnd.Models.Request;
using BackEnd.Models.Response;

namespace BackEnd.Utils
{
    public class AtorConversor
    {

        public TbAtor ConverteParaTbAtor (AtorRequest atorRequest)
        {
            TbAtor tbAtor = new TbAtor();

            tbAtor.DsDescricao   = atorRequest.Descricao;
            tbAtor.DtNascimento  = atorRequest.Nascimento;
            tbAtor.NmAtor        = atorRequest.Nome;
            tbAtor.NmPais        = atorRequest.Pais;
            
            return tbAtor;
        }


        public AtorResponse ConverteParaAtorResponse(TbAtor tbAtor)
        {
            AtorResponse response = new AtorResponse();

            response.Id          = tbAtor.IdAtor;
            response.Nascimento  = tbAtor.DtNascimento;
            response.Nome        = tbAtor.NmAtor;
            response.Pais        = tbAtor.NmPais;
            response.Descricao   = tbAtor.DsDescricao;

            return response;
        }
    }
}