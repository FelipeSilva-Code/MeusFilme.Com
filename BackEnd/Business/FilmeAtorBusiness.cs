using System;
using System.Threading.Tasks;
using BackEnd.Models;
using System.Collections.Generic;
using BackEnd.Database;

namespace BackEnd.Business
{
    public class FilmeAtorBusiness
    {
        private readonly FilmeAtorDatabase _filmeAtorDatabase;
        private readonly FilmeDatabase _filmeDatabase;
        private readonly AtorDatabase _atorDatabase;

        public FilmeAtorBusiness (FilmeAtorDatabase filmeAtorDatabase, FilmeDatabase filmeDatabase, AtorDatabase atorDatabase)
        {
            _filmeAtorDatabase = filmeAtorDatabase;
            _filmeDatabase     = filmeDatabase;
            _atorDatabase      = atorDatabase;
        }
       
        public async Task ValidarFilmeAtor (TbFilmeAtor filmeAtor)
        {
            if(filmeAtor.FkAtor <= 0 || filmeAtor.FkAtor == null)
                throw new ArgumentException("Id do ator inválido!");
            else if(filmeAtor.FkFilme <= 0 || filmeAtor.FkFilme == null)
                throw new ArgumentException("Id do filme inválido!");
            else if(string.IsNullOrEmpty(filmeAtor.NmPersonagem))
                throw new ArgumentException("O nome do personagem é obrigatório!");
            else if(await _filmeDatabase.PegarPorIdAsync(filmeAtor.FkFilme) == null)
                throw new ArgumentException("Filme não encontrado!");
            else if (await _atorDatabase.BuscarPorIdAsync(filmeAtor.FkAtor) == null)
                throw new ArgumentException("Ator não encontrado!");
        }
        public async Task AdicionarAsync(TbFilmeAtor filmeAtor)
        {
            await this.ValidarFilmeAtor(filmeAtor);

            await _filmeAtorDatabase.AdicionarAsync(filmeAtor);
        }


        public async Task AlterarAsync(int id, TbFilmeAtor filmeAtor)
        {
            if (id <= 0)
                throw new ArgumentException("Id do Personagem inválido!");

            await this.ValidarFilmeAtor(filmeAtor);

            await _filmeAtorDatabase.AlterarAsync(id, filmeAtor);
        }

        public async Task DeletarAsync(int? id)
        {
            if (id == null || id <= 0)
                throw new ArgumentException("Id do personagem inválido!");

            await _filmeAtorDatabase.DeletarAsync(id);
        }
    }
}