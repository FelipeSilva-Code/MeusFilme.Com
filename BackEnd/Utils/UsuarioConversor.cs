using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Models;
using System.Collections.Generic;
using BackEnd.Models.Request;
using BackEnd.Models.Response;

namespace BackEnd.Utils
{
    public class UsuarioConversor
    {
        public TbUsuario ConverterParaTbUsuario (CadastroRequest request)
        {
            TbUsuario tbUsuario = new TbUsuario();

            tbUsuario.DsEmail = request.Email;
            tbUsuario.DsPermissao = request.Permissao;
            tbUsuario.DsSenha = request.Senha;
            tbUsuario.NmUsuario = request.Nome;

            return tbUsuario;
        }

        public TbUsuario ConverterParaTbUsuario(LoginRequest request)
        {
            TbUsuario tbUsuario = new TbUsuario();

            tbUsuario.DsEmail = request.Email;
            tbUsuario.DsSenha = request.Senha;

            return tbUsuario;
        }

        public LoginResponse ConverterParaUsuarioResponse(TbUsuario usuario)
        {
            LoginResponse response = new LoginResponse();

            response.Id         = usuario.IdUsuario;
            response.Nome       = usuario.NmUsuario;
            response.Email      = usuario.DsEmail;
            response.Permissao  = usuario.DsPermissao;
            response.Senha      = "";

            return response;
        }

        public LoginResponse ConverterParaUsuarioResponse(UsuarioAutenticado usuario)
        {
            LoginResponse response = new LoginResponse();

            response.Id         = Convert.ToInt32(usuario.Id);
            response.Nome       = usuario.Nome;
            response.Email      = usuario.Email;
            response.Permissao  = usuario.Permissao;
            response.Senha      = "";

            return response;
        }
    }
}