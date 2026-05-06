using apiProdutos.DTO;
using apiProdutos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace apiProdutos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutosController : ControllerBase
    {
        [HttpGet("lstProdutos")]
        public ActionResult<IEnumerable<ProdutoDTO>> GetProdutos()
        {
            try
            {
                var produtoService = new Produtos();
                var lista = produtoService.lstProdutos();

                return Ok(lista);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    msg = "Erro interno ao listar produtos",
                    detalhe = ex.Message
                });
            }
        }

        [HttpPost("InserirProduto")]
        public ActionResult InserirProduto([FromBody] ProdutoDTO Request)
        {
            try
            {

                return StatusCode(200);


            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }

        [HttpGet("DeletarProduto")]
        public ActionResult DeleteProduto([FromQuery] int ID_PRODUTO)
        {
            try
            {

                return StatusCode(200);
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }

        [HttpGet("AtualizarEstoque")]
        public ActionResult AtualizarEstoque([FromQuery] int ID_PRODUTO, [FromQuery] int QT_NOVA)
        {
            try
            {

                return StatusCode(200);
            }

            catch (Exception ex)
            {
                return StatusCode(400, new { msg = $"Ocorreu um erro em sua API {ex.Message}" });
            }
        }
    }
}
