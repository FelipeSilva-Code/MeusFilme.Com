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
using Microsoft.AspNetCore.Authorization;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeAtorController : ControllerBase
    {

        private readonly FilmeAtorConversor _filmeAtorConversor;
        private readonly FilmeAtorBusiness _filmeAtorBusiness;

        public FilmeAtorController (FilmeAtorConversor filmeAtorConversor, FilmeAtorBusiness filmeAtorBusiness)
        {
            _filmeAtorConversor = filmeAtorConversor;
            _filmeAtorBusiness  = filmeAtorBusiness;
        }

        [HttpPost]
        [Authorize(Roles = "Adm")]
        public async Task<ActionResult<FilmeAtorResponse>> AdicionarAsync (FilmeAtorRequest request)
        {
            try
            {
                TbFilmeAtor tbFilmeAtor = _filmeAtorConversor.ConverterParaTbFilme(request);
                await _filmeAtorBusiness.AdicionarAsync(tbFilmeAtor);
                return _filmeAtorConversor.ConverteParaFilmeAtorResponse(tbFilmeAtor);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new ErroResponse(
                    400, ex.Message
                ));
            }
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = "Adm")]
        public async Task<ActionResult<FilmeAtorResponse>> AlterarAsync (int id, FilmeAtorRequest request)
        {
            try
            {
                TbFilmeAtor filmeAtor = _filmeAtorConversor.ConverterParaTbFilme(request);

                await _filmeAtorBusiness.AlterarAsync(id, filmeAtor);

                return _filmeAtorConversor.ConverteParaFilmeAtorResponse(filmeAtor);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new ErroResponse(
                     400, ex.Message
                ));
            }
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Adm")]
        public async Task<ActionResult<string>> DeletarAsync (int? id)
        {
            try
            {
                await _filmeAtorBusiness.DeletarAsync(id);
                string msg = "Personagem removido com sucesso!";
                return msg;
            }
            catch (System.Exception ex)
            {
                return BadRequest(new ErroResponse(
                    400, ex.Message
                ));
            }
        }
    }
}