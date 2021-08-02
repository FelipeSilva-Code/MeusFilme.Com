using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackEnd.Models;
using System.Collections.Generic;

namespace BackEnd.Database
{
    public class FilmeDatabase
    {
        db_filmeContext context = new db_filmeContext();

        public async Task AdicionarAsync (TbFilme filme)
        {
            context.Add(filme);
            await context.SaveChangesAsync();
            filme = await this.PegarPorIdAsync(filme.IdFilme);
        }

        public async Task<TbFilme> PegarPorIdAsync (int? id)
        {
            TbFilme filme =  await context.TbFilmes.Include(x => x.FkDiretorNavigation)
                                                   .FirstOrDefaultAsync(x => x.IdFilme == id);
            
            return filme;
        }

        public async Task<List<TbFilme>> ListarFilmesAsync()
        {
            List<TbFilme> filmes = await context.TbFilmes
                                                .Include(x => x.FkDiretorNavigation)
                                                .ToListAsync();
            return filmes;
        }

        public async Task DeletarAsync (int? id)
        {
            TbFilme filme = await this.PegarPorIdAsync(id);

            if (filme == null)
                throw new ArgumentException("Filme não encontrado!");

            context.Remove(filme);
            await context.SaveChangesAsync();
        
        }

        public async Task AlterarAsync (int id, TbFilme filme)
        {
            filme.IdFilme = id;
            
            if (!await context.TbFilmes.AnyAsync(x => x.IdFilme == id))
                throw new ArgumentException("Filme não encontrado!");

            context.Update(filme);
            await context.SaveChangesAsync();
            filme = await this.PegarPorIdAsync(filme.IdFilme);
        }
    }
}