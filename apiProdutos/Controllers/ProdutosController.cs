using apiProdutos.DTO;
using apiProdutos.Exceptions;
using apiProdutos.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

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

                if (!lista.Any()) return NoContent();

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
        public ActionResult<IEnumerable<ProdutoDTO>> InserirProduto([FromBody] ProdutoDTO request)
        {
            try
            {
                if (request == null)  return BadRequest(new { msg = "Dados do produto não enviados." });

                var produtoService = new Produtos();
                var listaAtualizada = produtoService.InserirProduto(request);

                return CreatedAtAction(nameof(GetProdutos), listaAtualizada);
            }
            catch (ProdutoJaExisteException ex)
            {
                return Conflict(new
                {
                    msg = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    msg = "Erro interno ao inserir produto",
                    detalhe = ex.Message
                });
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<ProdutoDTO>> DeleteProduto(int id)
        {
            try
            {
                var produtoService = new Produtos();
                var listaAtualizada = produtoService.DeletarProduto(id);

                return Ok(listaAtualizada);
            }
            catch (ProdutoNaoEncontradoException ex)
            {
                return NotFound(new
                {
                    msg = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    msg = "Erro interno ao deletar produto",
                    detalhe = ex.Message
                });
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
