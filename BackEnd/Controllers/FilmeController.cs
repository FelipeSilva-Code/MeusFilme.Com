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
    public class FilmeController : ControllerBase
    {

        private readonly FilmeBusiness _filmeBusiness;
        private readonly FilmeDatabase _filmeDatabase;
        private readonly FilmeConversor _filmeConversor;

        public FilmeController (FilmeBusiness filmeBusiness, FilmeDatabase filmeDatabase, FilmeConversor filmeConversor)
        {
            _filmeBusiness  = filmeBusiness;
            _filmeDatabase  = filmeDatabase;
            _filmeConversor = filmeConversor;
        }


        [HttpPost]
        [Authorize(Roles = "Adm")]
        public async Task<ActionResult<FilmeResponse>> AdicionarAsync (FilmeRequest request)
        {
            try
            {
                TbFilme filme = _filmeConversor.ConverteParaTbFilme(request); 
                await _filmeBusiness.AdicionarAsync(filme);
                FilmeResponse response = await _filmeConversor.ConverterParaResponseAsync(filme);
                return response;
            }
            catch (System.Exception ex)
            {
                return BadRequest(new ErroResponse(
                    400, ex.Message
                ));
            }
        }

        [HttpGet]
        [Route("listar")]
        [Authorize]
        public async Task<ActionResult<List<FilmeResponse>>> ListarFilmes ()
        {
            try
            {
                List<TbFilme> tbFilme = await _filmeBusiness.ListarFilmesAsync();

                if (tbFilme == null)
                    return NotFound(new ErroResponse(400, "Nenhum filme encontrado!"));

                List<FilmeResponse> response = new List<FilmeResponse>();

                foreach (TbFilme item in tbFilme)
                {
                    FilmeResponse respUnico = await _filmeConversor.ConverterParaResponseAsync(item);
                    response.Add(respUnico);
                }

                return response;
            }
            catch (System.Exception ex)
            {
                return BadRequest(new ErroResponse(
                    400, ex.Message
                ));
            }
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public async Task<ActionResult<FilmeResponse>> PegarPorId(int id)
        {
            try
            {
                TbFilme filme = await _filmeBusiness.PegarPorIdAsync(id);

                if (filme == null)
                    return NotFound(new ErroResponse(400, "Filme não encontrado!"));
                
                FilmeResponse response = await _filmeConversor.ConverterParaResponseAsync(filme);

                return response;
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
        public async Task<ActionResult<String>> DeletarAsync (int? id)
        {
            try
            {
               await _filmeBusiness.DeletarAsync(id);
               string mensagem = "Filme removido com sucesso!";
               return mensagem;
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
        public async Task<ActionResult<FilmeResponse>> AlterarAsync (int id, FilmeRequest request)
        {
            try
            {
                TbFilme filme = _filmeConversor.ConverteParaTbFilme(request);
                await _filmeBusiness.AlterarAsync(id, filme);
                FilmeResponse response = await _filmeConversor.ConverterParaResponseAsync(filme);
                return response;
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