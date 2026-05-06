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
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        [HttpGet("{id}")]
        public ActionResult<ProdutoDTO> GetProdutos(int id)
        {
            try
            {
                var produtoService = new Produtos();
                var produtoEncontrado = produtoService.GetProdutoById(id);

                return Ok(produtoEncontrado);
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

        [HttpGet("BuscarPorNome")]
        public ActionResult<IEnumerable<ProdutoDTO>> BuscarPorNome([FromQuery] string nome)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nome)) return BadRequest(new { msg = "Informe um nome para busca." });

                var produtoService = new Produtos();
                var resultado = produtoService.BuscarPorNome(nome);

                if (!resultado.Any()) return NoContent();

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    msg = "Erro ao buscar produtos",
                    detalhe = ex.Message
                });
            }
        }

        [HttpGet("BuscaSemEstoque")]
        public ActionResult<IEnumerable<ProdutoDTO>> ListarSemEstoque()
        {
            try
            {
                var produtoService = new Produtos();
                var lista = produtoService.ListarSemEstoque();

                if (!lista.Any()) return NoContent();

                return Ok(lista);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    msg = "Erro ao listar produtos sem estoque",
                    detalhe = ex.Message
                });
            }
        }

        [HttpGet("CalculaValorTotalEstoque")]
        public ActionResult<decimal> CalcularValorTotalEstoque()
        {
            try
            {
                var produtoService = new Produtos();
                var total = produtoService.CalcularValorTotalEstoque();

                return Ok(total);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    msg = "Erro ao calcular valor do estoque",
                    detalhe = ex.Message
                });
            }
        }

        [HttpPost("InserirProduto")]
        public ActionResult<IEnumerable<ProdutoDTO>> InserirProduto([FromBody] ProdutoDTO request)
        {
            try
            {
                if (request == null) return BadRequest(new { msg = "Dados do produto não enviados." });

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

        [HttpDelete("DeletarProduto")]
        public ActionResult<IEnumerable<ProdutoDTO>> DeleteProduto([FromQuery] int ID_PRODUTO)
        {
            try
            {
                var produtoService = new Produtos();
                var listaAtualizada = produtoService.DeletarProduto(ID_PRODUTO);

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

        [HttpPatch("AtualizarEstoque")]
        public ActionResult<ProdutoDTO> AtualizarEstoque([FromQuery] int ID_PRODUTO, [FromQuery] int QT_NOVA)
        {
            try
            {
                var produtoService = new Produtos();
                var produtoAtualizado = produtoService.AtualizarEstoque(ID_PRODUTO, QT_NOVA);

                return Ok(produtoAtualizado);
            }
            catch (ProdutoNaoEncontradoException ex)
            {
                return BadRequest(new
                {
                    msg = ex.Message
                });
            }
            catch (EstoqueInvalidoException ex)
            {
                return BadRequest(new
                {
                    msg = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    msg = "Erro interno ao atualizar estoque",
                    detalhe = ex.Message
                });
            }
        }
    }
}
