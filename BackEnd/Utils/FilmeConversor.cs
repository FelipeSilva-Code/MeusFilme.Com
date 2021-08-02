using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Models;
using BackEnd.Database;
using System.Collections.Generic;
using BackEnd.Models.Request;
using BackEnd.Models.Response;

namespace BackEnd.Utils
{
    public class FilmeConversor
    {

        private readonly DiretorConversor _diretorConversor;
        private readonly FilmeAtorConversor _filmeAtorConversor;
        private readonly FilmeAtorDatabase _filmeAtorDatabase;

        public FilmeConversor(DiretorConversor diretorConversor, FilmeAtorDatabase filmeAtorDatabase, FilmeAtorConversor filmeAtorConversor)
        {
            _diretorConversor   = diretorConversor;
            _filmeAtorDatabase  = filmeAtorDatabase;
            _filmeAtorConversor = filmeAtorConversor;
        }
        public TbFilme ConverteParaTbFilme (FilmeRequest request)
        {
            TbFilme filme = new TbFilme();

            filme.DtLancamento  = request.Lancamento;
            filme.DsDescricao   = request.Descricao;
            filme.FkDiretor     = request.IdDiretor;
            filme.DsGenero      = request.Genero;
            filme.DsLingua      = request.Lingua;
            filme.NmFilme       = request.Nome;
            filme.NrNota        = request.Nota;
            filme.DsTipo        = request.Tipo;
            
            return filme;
        }

        public async Task<FilmeResponse> ConverterParaResponseAsync (TbFilme filme)
        {
            FilmeResponse response = new FilmeResponse();

            response.Descricao  = filme.DsDescricao;
            response.Genero     = filme.DsGenero;
            response.IdFilme    = filme.IdFilme;
            response.Lancamento = filme.DtLancamento;
            response.Lingua     = filme.DsLingua;
            response.Nome       = filme.NmFilme;
            response.Nota       = filme.NrNota;
            response.Tipo       = filme.DsTipo;

            response.Diretor = _diretorConversor.ConverteParaDiretorResponse(filme.FkDiretorNavigation);
            
            //Pega os registros da tbfilmeator em que o fk do filme é igual ao id do filme
            List<TbFilmeAtor> filmeAtor = await _filmeAtorDatabase.ListarFilmeAtorAsync(filme.IdFilme);

            response.Atores = new List<FilmeAtorResponse>();

            foreach(TbFilmeAtor item in filmeAtor)
            {
                FilmeAtorResponse filmeAtorResponse = _filmeAtorConversor.ConverteParaFilmeAtorResponse(item);
                response.Atores.Add(filmeAtorResponse);
            } 

            return response;
        }
    }
}