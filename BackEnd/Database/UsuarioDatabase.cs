using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BackEnd.Models;
using System.Linq;
using System.Collections.Generic;

namespace BackEnd.Database
{
    public class UsuarioDatabase
    {
        db_filmeContext context = new db_filmeContext();
        public async Task CadastrarAsync(TbUsuario usuario)
        {
            context.Add(usuario);
            await context.SaveChangesAsync();
        }

        public async Task<TbUsuario> LogarAsync(TbUsuario usuario)
        {
            TbUsuario login = await context.TbUsuarios.FirstOrDefaultAsync(x => x.DsEmail == usuario.DsEmail 
                                                                             && x.DsSenha == usuario.DsSenha);
            return login;
        }

        public bool VerificarSeEmailJaFoiCadastrado (string email)
        {
            return context.TbUsuarios.Any(x => x.DsEmail == email);
        }
    }
}