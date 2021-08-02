using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Security.Claims;
using System.Linq;
using BackEnd.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace BackEnd.Models.Response
{
    public class UsuarioAutenticado
    {
        private readonly IHttpContextAccessor _accessor;
        public UsuarioAutenticado (IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string Id => GetClaimsIdentity().FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
        public string Nome => _accessor.HttpContext.User.Identity.Name;
        public string Email => GetClaimsIdentity().FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
        public string Permissao => GetClaimsIdentity().FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return _accessor.HttpContext.User.Claims;
        }
    }
}