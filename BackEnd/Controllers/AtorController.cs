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

    public class AtorController : ControllerBase
    {

        private readonly AtorDatabase _atorDatabase;
        private readonly AtorBusiness _atorBusiness;
        private readonly AtorConversor _atorConversor;

        public AtorController (AtorDatabase atorDatabase, AtorBusiness atorBusiness, AtorConversor atorConversor)
        {
            _atorBusiness  = atorBusiness;
            _atorDatabase  = atorDatabase;
            _atorConversor = atorConversor;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<AtorResponse>>> ListarAtoresAsync()
        {
            try
            {
                List<TbAtor> tbAtor = await _atorBusiness.ListaAtoresAsync();

                if (tbAtor == null)
                    return NotFound(new ErroResponse(404, "Nenhum ator encontrado!"));

                List<AtorResponse> response = new List<AtorResponse>();

                foreach (TbAtor item in tbAtor)
                {
                    AtorResponse atorResp = _atorConversor.ConverteParaAtorResponse(item);
                    response.Add(atorResp);
                }

                return response;

            }
            catch (System.Exception ex)
            {
                return BadRequest(new ErroResponse(
                    404, ex.Message
                ));
            }
        }


        [HttpGet]
        [Route("porId/{id}")]
        [Authorize]
        public async Task<ActionResult<AtorResponse>> BuscarPorIdAsync(int? id)
        {
            try
            {
                TbAtor tbAtor = await _atorBusiness.BuscarPorIdAsync(id);

                if (tbAtor == null)
                    return NotFound(new ErroResponse(404, "Ator não encontrado!"));

                AtorResponse response = _atorConversor.ConverteParaAtorResponse(tbAtor);

                return response;
            }
            catch (System.Exception ex)
            {
                return BadRequest(new ErroResponse(
                    400, ex.Message
                ));
            }
        }

        
        [Route("Adicionar")]
        [HttpPost]
        [Authorize(Roles = "Adm")]
        public async Task<ActionResult<AtorResponse>> AdicionarAsync (AtorRequest ator)
        {
            try
            {
                
                TbAtor tbAtor = _atorConversor.ConverteParaTbAtor(ator);       
                await _atorBusiness.AdicionarAsync(tbAtor);
                return _atorConversor.ConverteParaAtorResponse(tbAtor);
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
        public async Task<ActionResult<AtorResponse>> AlterarAsync (int id, AtorRequest atorRequest)
        {
            try
            {
                TbAtor tbAtor = _atorConversor.ConverteParaTbAtor(atorRequest);
                
                await _atorBusiness.AlterarAsync(id, tbAtor);
               
                return _atorConversor.ConverteParaAtorResponse(tbAtor);
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
        public async Task<ActionResult<string>> DeletarAsync(int? id)
        {
            
            try
            {
                await _atorBusiness.DeletarAsync(id);
                string msg = "Ator removido com sucesso!";
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