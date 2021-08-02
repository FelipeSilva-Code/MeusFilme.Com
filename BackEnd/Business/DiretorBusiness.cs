using System;
using System.Threading.Tasks;
using BackEnd.Models;
using System.Collections.Generic;
using BackEnd.Database;

namespace BackEnd.Business
{
    public class DiretorBusiness
    {
        private readonly DiretorDatabase _diretorDatabase;

        public DiretorBusiness(DiretorDatabase DiretorDatabase)
        {
            _diretorDatabase = DiretorDatabase;
        }

        public void ValidarDiretor(TbDiretor tbDiretor)
        {
            if (string.IsNullOrEmpty(tbDiretor.NmDiretor))
                throw new ArgumentException("O nome do Diretor é obrigatório!");
            else if (string.IsNullOrEmpty(tbDiretor.DsDescricao))
                throw new ArgumentException("A descrição do Diretor é obrigatória!");
            else if (tbDiretor.DtNascimento > DateTime.Now)
                throw new ArgumentException("A data de nascimento não pode ser maior do que a data atual!");
            else if (tbDiretor.DtNascimento == null)
                throw new ArgumentException("A data de nascimento é obrigatória!");
            else if (string.IsNullOrEmpty(tbDiretor.NmPais))
                throw new ArgumentException("O país do Diretor é obrigatório!");
        }

        public async Task AdicionarAsync(TbDiretor tbDiretor)
        {
            this.ValidarDiretor(tbDiretor);
            await _diretorDatabase.AdicionarAsync(tbDiretor);
        }

        public async Task<List<TbDiretor>> ListaDiretoresAsync()
        {
            List<TbDiretor> tbDiretor = await _diretorDatabase.ListaDiretoresAsync();
            return tbDiretor;
        }

        public async Task<TbDiretor> BuscarPorIdAsync(int? id)
        {
            if (id == null)
                throw new ArgumentException("O id não foi passado!");

            TbDiretor tbDiretor = await _diretorDatabase.BuscarPorIdAsync(id);
            return tbDiretor;
        }

        public async Task AlterarAsync(int id, TbDiretor tbDiretor)
        {
            this.ValidarDiretor(tbDiretor);

            await _diretorDatabase.AlterarAsync(id, tbDiretor);
        }

        public async Task DeletarAsync(int? id)
        {

            if (id == null)
                throw new Exception("Id inválido!");

            await _diretorDatabase.DeletarAsync(id);

        }
    }
}