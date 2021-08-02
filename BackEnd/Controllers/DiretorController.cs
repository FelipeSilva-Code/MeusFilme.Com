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
    public class DiretorController : ControllerBase
    {
        private readonly DiretorBusiness _diretorBusiness;
        private readonly DiretorDatabase _diretorDatabase;
        private readonly DiretorConversor _diretorConversor;

        public DiretorController (DiretorBusiness diretorBusiness, DiretorDatabase diretorDatabase, DiretorConversor diretorConversor)
        {
            _diretorBusiness  = diretorBusiness;
            _diretorDatabase  = diretorDatabase;
            _diretorConversor = diretorConversor;
        }
       
        [Route("Adicionar")]
        [HttpPost]
        [Authorize(Roles = "Adm")]
        public async Task<ActionResult<DiretorResponse>> AdicionarAsync(DiretorRequest diretor)
        {
            try
            {

                TbDiretor tbDiretor = _diretorConversor.ConverteParaTbDiretor(diretor);
                await _diretorBusiness.AdicionarAsync(tbDiretor);
                return _diretorConversor.ConverteParaDiretorResponse(tbDiretor);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new ErroResponse(
                    400, ex.Message
                ));
            }
        }


        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<DiretorResponse>>> ListarDiretoresAsync()
        {
            try
            {
                List<TbDiretor> tbDiretor = await _diretorBusiness.ListaDiretoresAsync();

                if (tbDiretor == null)
                    return NotFound(new ErroResponse(404, "Nenhum diretor encontrado!"));

                List<DiretorResponse> response = new List<DiretorResponse>();

                foreach (TbDiretor item in tbDiretor)
                {
                    DiretorResponse DiretorResp = _diretorConversor.ConverteParaDiretorResponse(item);
                    response.Add(DiretorResp);
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
        public async Task<ActionResult<DiretorResponse>> BuscarPorIdAsync(int? id)
        {
            try
            {
                TbDiretor tbDiretor = await _diretorBusiness.BuscarPorIdAsync(id);

                if (tbDiretor == null)
                    return NotFound(new ErroResponse(404, "Diretor não encontrado!"));

                DiretorResponse response = _diretorConversor.ConverteParaDiretorResponse(tbDiretor);

                return response;
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
        public async Task<ActionResult<DiretorResponse>> AlterarAsync(int id, DiretorRequest diretorRequest)
        {
            try
            {
                TbDiretor tbDiretor = _diretorConversor.ConverteParaTbDiretor(diretorRequest);

                await _diretorBusiness.AlterarAsync(id, tbDiretor);

                return _diretorConversor.ConverteParaDiretorResponse(tbDiretor);
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
                await _diretorBusiness.DeletarAsync(id);
                string msg = "Diretor removido com sucesso!";
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