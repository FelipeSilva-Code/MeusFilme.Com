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
using BackEnd.Service;
using Microsoft.AspNetCore.Authorization;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioAutenticado _usuarioAutenticado;
        private readonly UsuarioBusiness _usuarioBusiness;
        private readonly UsuarioConversor _usuarioConversor;
        

        public UsuarioController (UsuarioAutenticado usuarioAutenticado, UsuarioBusiness usuarioBusiness, UsuarioConversor usuarioConversor)
        {
            _usuarioAutenticado = usuarioAutenticado;
            _usuarioBusiness    = usuarioBusiness;
            _usuarioConversor   = usuarioConversor;
        }


        [HttpPost]
        [Route("cadastro")]
        [AllowAnonymous]
        public async Task<ActionResult<string>> CadastrarAsync (CadastroRequest request)
        {
            try
            {
                TbUsuario usuario = _usuarioConversor.ConverterParaTbUsuario(request);
                await _usuarioBusiness.CadastrarAsync(usuario);
                string msg = "Usuário cadastrado com sucesso!";
                return msg;
            }
            catch (System.Exception ex)
            {
                return BadRequest(new ErroResponse(
                    400, ex.Message
                ));
            }
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> LogarAsync(LoginRequest request)
        {
            try
            {                
                TbUsuario usuario = _usuarioConversor.ConverterParaTbUsuario(request);
                usuario = await _usuarioBusiness.LogarAsync(usuario);

                if (usuario == null)
                    return NotFound(new ErroResponse(404, "Email ou senha inválido!"));

                // Gera o Token
                var token = TokenService.GenerateToken(usuario);

                LoginResponse response = _usuarioConversor.ConverterParaUsuarioResponse(usuario); 
                
                // Retorna os dados
                return new
                {
                    usuario = response,
                    token = token
                };
            }
            catch (System.Exception ex)
            {
                return BadRequest(new ErroResponse(
                    400, ex.Message
                ));
            }
        }

        [HttpGet]
        [Route("validar")]
        [Authorize]
        public ActionResult<LoginResponse> VerificarToken (){

            return _usuarioConversor.ConverterParaUsuarioResponse(_usuarioAutenticado);
        }


        

    }
}