using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Models;
using System.Collections.Generic;
using BackEnd.Models.Request;
using BackEnd.Database;
using BackEnd.Business;
using BackEnd.Utils;
using BackEnd.Models.Response;


namespace BackEnd.Business
{
    public class FilmeBusiness
    {
        private readonly FilmeDatabase _filmeDatabase;
        private readonly DiretorDatabase _diretorDatabase;
        public FilmeBusiness(FilmeDatabase filmeDatabase, DiretorDatabase diretorDatabase)
        {
            _filmeDatabase = filmeDatabase;
            _diretorDatabase = diretorDatabase;
        }

        public void ValidarFilme (TbFilme filme)
        {
            if(string.IsNullOrEmpty(filme.DsDescricao))
                throw new ArgumentException("Descrição obrigatória!");
            else if(string.IsNullOrEmpty(filme.DsGenero))
                throw new ArgumentException("Gênero obrigatório!");
            else if (string.IsNullOrEmpty(filme.DsLingua))
                throw new ArgumentException("Idioma obrigatório!");
            else if (string.IsNullOrEmpty(filme.DsTipo))
                throw new ArgumentException("Tipo obrigatório!");
            else if (filme.DtLancamento == null)
                throw new ArgumentException("Data de lançamento obrigatório!");
            else if (filme.FkDiretor == null)
                throw new ArgumentException("Diretor obrigatório!");
            else if (filme.FkDiretor <= 0)
                throw new ArgumentException("Id do diretor inválido!");
            else if (string.IsNullOrEmpty(filme.NmFilme))
                throw new ArgumentException("Nome obrigatório!");
        }
        public async Task AdicionarAsync (TbFilme filme)
        {
            this.ValidarFilme(filme);
           
           //Verifica se o diretor existe
            if(await _diretorDatabase.BuscarPorIdAsync(filme.FkDiretor) == null)
                throw new ArgumentException("Diretor não encontrado!");
           
            await _filmeDatabase.AdicionarAsync(filme);
        }

        public async Task<List<TbFilme>> ListarFilmesAsync ()
        {
            List<TbFilme> filmes = await _filmeDatabase.ListarFilmesAsync();
            return filmes;
        }

        public async Task<TbFilme> PegarPorIdAsync (int? id)
        {
            if(id == null || id <= 0)
                throw new ArgumentException("Id do filme inválido!");

            TbFilme filme = await _filmeDatabase.PegarPorIdAsync(id);
            return filme;
        }

        public async Task DeletarAsync (int? id)
        {
            if (id == null || id <= 0)
                throw new ArgumentException("Id do filme inválido!");

            await _filmeDatabase.DeletarAsync(id);
        }

        public async Task AlterarAsync (int id, TbFilme filme)
        {
            if (id <= 0)
                throw new ArgumentException("Id do filme inválido!");

            this.ValidarFilme(filme);

            //Verifica se o diretor existe
            if (await _diretorDatabase.BuscarPorIdAsync(filme.FkDiretor) == null)
                throw new ArgumentException("Diretor não encontrado!");

            await _filmeDatabase.AlterarAsync(id, filme);  
        }

            
    }
}