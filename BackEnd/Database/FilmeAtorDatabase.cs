using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackEnd.Models;
using System.Collections.Generic;
using System.Linq;

namespace BackEnd.Database
{
    public class FilmeAtorDatabase
    {
        db_filmeContext context = new db_filmeContext();

        public async Task AdicionarAsync(TbFilmeAtor filmeAtor)
        {
            context.Add(filmeAtor);
            await context.SaveChangesAsync();
            filmeAtor = await this.PegarPorIdAsync(filmeAtor.IdFilmeAtor);
        }


        public async Task AlterarAsync(int id, TbFilmeAtor filmeAtor)
        {
            if (!await context.TbFilmeAtors.AnyAsync(x => x.IdFilmeAtor == id))
                throw new ArgumentException("Personagem não encontrado!");

            filmeAtor.IdFilmeAtor = id;

            context.Update(filmeAtor);
            await context.SaveChangesAsync();
            filmeAtor = await this.PegarPorIdAsync(filmeAtor.IdFilmeAtor);

        }

        public async Task DeletarAsync(int? id)
        {
            TbFilmeAtor filmeAtor = await this.PegarPorIdAsync(id);

            if (filmeAtor == null)
                throw new ArgumentException("Personagem não encontrado!");

            context.Remove(filmeAtor);
            await context.SaveChangesAsync();

        }
        
        public async Task<List<TbFilmeAtor>> ListarFilmeAtorAsync (int idFilme)
        {
            List<TbFilmeAtor> filmeAtors = await context.TbFilmeAtors.Include(x => x.FkFilmeNavigation)
                                                                     .Include(x => x.FkAtorNavigation)
                                                                     .Where(x => x.FkFilme == idFilme)
                                                                     .ToListAsync();

            return filmeAtors;                                                        
        }

        public async Task<TbFilmeAtor> PegarPorIdAsync(int? id)
        {
            TbFilmeAtor filmeAtor = await context.TbFilmeAtors.Include(x => x.FkFilmeNavigation)
                                                              .Include(x => x.FkAtorNavigation)
                                                              .FirstOrDefaultAsync(x => x.IdFilmeAtor == id);
                                                                    

            return filmeAtor;
        }


    }
}