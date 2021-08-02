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
    public class UsuarioBusiness
    {
        private readonly UsuarioDatabase _usuarioDatabase;
        public UsuarioBusiness (UsuarioDatabase usuarioDatabase)
        {
            _usuarioDatabase = usuarioDatabase;
        }
        public void ValidarCadastro(TbUsuario usuario)
        {
            if (string.IsNullOrEmpty(usuario.NmUsuario))
                throw new ArgumentException("O nome é obrigatório!");
            else if (usuario.DsSenha.Length < 8)
                throw new ArgumentException("A senha deve conter no mínimo 8 caracteres!");
            else if (string.IsNullOrEmpty(usuario.DsPermissao))
                throw new ArgumentException("A permissão é obrigatória!");

            this.ValidarEmail(usuario.DsEmail);

        }

        public void  ValidarEmail (string email)
        {
            if(string.IsNullOrEmpty(email))
                throw new ArgumentException("O email é obrigatório!");
            else if (!email.Contains("@") || !email.Contains(".com"))
                throw new ArgumentException("Email inválido!");
            else if ( _usuarioDatabase.VerificarSeEmailJaFoiCadastrado(email))
                 throw new ArgumentException("Email já cadastrado!");
        }

        public void ValidarLogin (TbUsuario usuario)
        {
            if (string.IsNullOrEmpty(usuario.DsEmail))
                throw new ArgumentException("O email é obrigatório!");
            else if (string.IsNullOrEmpty(usuario.DsSenha))
                throw new ArgumentException("A senha é obrigatória!");
        }
        
        public async Task CadastrarAsync(TbUsuario usuario)
        {
            this.ValidarCadastro(usuario);
            await _usuarioDatabase.CadastrarAsync(usuario);
        }

        public async Task<TbUsuario> LogarAsync(TbUsuario usuario)
        {
            this.ValidarLogin(usuario);
            TbUsuario login = await _usuarioDatabase.LogarAsync(usuario);
            return login;
        }
    }
}