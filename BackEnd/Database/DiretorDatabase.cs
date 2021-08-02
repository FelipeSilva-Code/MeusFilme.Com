using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackEnd.Models;
using System.Collections.Generic;

namespace BackEnd.Database
{
    public class DiretorDatabase
    {
        db_filmeContext context = new db_filmeContext();

        public async Task AdicionarAsync(TbDiretor tbDiretor)
        {
            context.Add(tbDiretor);
            await context.SaveChangesAsync();
        }

        public async Task<List<TbDiretor>> ListaDiretoresAsync()
        {
            List<TbDiretor> tbDiretor = await context.TbDiretors.ToListAsync();
            return tbDiretor;
        }

        public async Task<TbDiretor> BuscarPorIdAsync(int? id)
        {
            TbDiretor tbDiretor = await context.TbDiretors.FirstOrDefaultAsync(x => x.IdDiretor == id);

            return tbDiretor;
        }

        public async Task<TbDiretor> AlterarAsync(int id, TbDiretor tbDiretor)
        {

            tbDiretor.IdDiretor = id;

            if (!await context.TbDiretors.AnyAsync(x => x.IdDiretor == tbDiretor.IdDiretor))
                throw new Exception("Diretor não encontrado!");

            context.Update(tbDiretor);
            await context.SaveChangesAsync();

            return tbDiretor;
        }

        public async Task DeletarAsync(int? id)
        {
            TbDiretor tbDiretor = await this.BuscarPorIdAsync(id);

            if (tbDiretor == null)
                throw new Exception("Diretor não encontrado!");

            context.TbDiretors.Remove(tbDiretor);
            await context.SaveChangesAsync();
        }
    }
}