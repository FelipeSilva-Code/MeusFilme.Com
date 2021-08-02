using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BackEnd.Models;
using Microsoft.IdentityModel.Tokens;

namespace BackEnd.Service
{
    public static class TokenService
    {
        public static string GenerateToken(TbUsuario usuario)
        { 
            //Instância da classe que gera o token
            var tokenHandler = new JwtSecurityTokenHandler();

            //Pega os bytes da chave criada no settings
            var key = Encoding.ASCII.GetBytes(Settings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                //Pega as informações a partir do usuario para gerar o token
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, usuario.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Name, usuario.NmUsuario.ToString()),
                    new Claim(ClaimTypes.Role, usuario.DsPermissao.ToString()),
                    new Claim(ClaimTypes.Email, usuario.DsEmail.ToString())
                }),

                //Tempo em que o token expira
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            //Cria o token a partir das informações passadas acima
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}