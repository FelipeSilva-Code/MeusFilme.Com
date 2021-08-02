using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackEnd.Models;
using System.Collections.Generic;


namespace BackEnd.Database
{
    public class AtorDatabase
    {
        db_filmeContext context = new db_filmeContext();
        public async Task AdicionarAsync(TbAtor tbAtor)
        {
            context.Add(tbAtor);
            await context.SaveChangesAsync();
        }

        public async Task<List<TbAtor>> ListaAtoresAsync()
        {
            List<TbAtor> tbAtor = await context.TbAtors.ToListAsync();
            return tbAtor;
        }

        public async Task<TbAtor> BuscarPorIdAsync(int? id)
        {
            TbAtor tbAtor = await context.TbAtors.FirstOrDefaultAsync(x => x.IdAtor == id);

            return tbAtor;
        }

        public async Task<TbAtor> AlterarAsync(int id, TbAtor tbAtor)
        {

            tbAtor.IdAtor = id;

            //verifica se o usuario existe
            if (!await context.TbAtors.AnyAsync(x => x.IdAtor == tbAtor.IdAtor))
                throw new Exception("Ator não encontrado!");

            context.Update(tbAtor);
            await context.SaveChangesAsync();
            
            return tbAtor;
        }

        public async Task DeletarAsync (int? id)
        {
            TbAtor tbAtor = await this.BuscarPorIdAsync(id);

            if(tbAtor == null)
                throw new Exception("Ator não encontrado!");

            context.TbAtors.Remove(tbAtor);
            await context.SaveChangesAsync();
        }
    }
}