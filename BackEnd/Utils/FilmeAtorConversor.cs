using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Models;
using System.Collections.Generic;
using BackEnd.Models.Request;
using BackEnd.Models.Response;

namespace BackEnd.Utils
{
    public class FilmeAtorConversor
    {
        public FilmeAtorResponse ConverteParaFilmeAtorResponse (TbFilmeAtor filmeAtor)
        {
            FilmeAtorResponse response = new FilmeAtorResponse();

            //Ator
            response.Ator = new AtorResponse();
            response.Ator.Descricao = filmeAtor.FkAtorNavigation.DsDescricao;
            response.Ator.Id = filmeAtor.FkAtorNavigation.IdAtor;
            response.Ator.Nascimento = filmeAtor.FkAtorNavigation.DtNascimento;
            response.Ator.Nome = filmeAtor.FkAtorNavigation.NmAtor;
            response.Ator.Pais = filmeAtor.FkAtorNavigation.NmPais;

            response.Id = filmeAtor.IdFilmeAtor;
            response.Personagem = filmeAtor.NmPersonagem;

            return response;
        }

        public TbFilmeAtor ConverterParaTbFilme (FilmeAtorRequest request)
        {
            TbFilmeAtor filmeAtor = new TbFilmeAtor();

            filmeAtor.FkAtor       = request.IdAtor;
            filmeAtor.FkFilme      = request.IdFilme;
            filmeAtor.NmPersonagem = request.Personagem;

            return filmeAtor;
        }
    }
}