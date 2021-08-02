using System;
using System.Threading.Tasks;
using BackEnd.Models;
using System.Collections.Generic;
using BackEnd.Database;


namespace BackEnd.Business
{
    public class AtorBusiness
    {
        private readonly AtorDatabase _atorDatabase;

        public AtorBusiness (AtorDatabase atorDatabase)
        {
            _atorDatabase = atorDatabase;
        }

        public void ValidarAtor (TbAtor tbAtor)
        {
            if (string.IsNullOrEmpty(tbAtor.NmAtor))
                throw new ArgumentException("O nome do ator é obrigatório!");
            else if (string.IsNullOrEmpty(tbAtor.DsDescricao))
                throw new ArgumentException("A descrição do ator é obrigatória!");
            else if (tbAtor.DtNascimento > DateTime.Now)
                throw new ArgumentException("A data de nascimento não pode ser maior do que a data atual!");
            else if (tbAtor.DtNascimento == null)
                throw new ArgumentException("A data de nascimento é obrigatória!");
            else if (string.IsNullOrEmpty(tbAtor.NmPais))
                throw new ArgumentException("O país do ator é obrigatório!");
        }

        public async Task AdicionarAsync (TbAtor tbAtor)
        {
            this.ValidarAtor(tbAtor);
            await _atorDatabase.AdicionarAsync(tbAtor);
        }

        public async Task<List<TbAtor>> ListaAtoresAsync ()
        {
            List<TbAtor> tbAtor = await _atorDatabase.ListaAtoresAsync();
            return tbAtor;
        }

        public async Task<TbAtor> BuscarPorIdAsync(int? id)
        {
            if (id == null)
                throw new ArgumentException("O id não foi passado!");

            TbAtor tbAtor = await _atorDatabase.BuscarPorIdAsync(id);
            return tbAtor;
        }

        public async Task AlterarAsync(int id, TbAtor tbAtor)
        {
            this.ValidarAtor(tbAtor);
            
            await _atorDatabase.AlterarAsync(id, tbAtor);
        }

        public async Task DeletarAsync(int? id)
        {

            if (id == null)
                throw new Exception("Id inválido!");

            await _atorDatabase.DeletarAsync(id);

        }
    }
}