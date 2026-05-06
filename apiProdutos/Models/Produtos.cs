using apiProdutos.DTO;
using apiProdutos.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace apiProdutos.Models
{
    public class Produtos
    {
        public List<ProdutoDTO> lstProdutos()
        {
            try
            {
                List<ProdutoDTO> lstProdutos = new List<ProdutoDTO>();

                lstProdutos.Add(new ProdutoDTO
                {
                    ID_PRODUTO = 1,
                    NM_PRODUTO = "Teclado Mecânico",
                    VL_PRECO = 349.90m,
                    QT_ESTOQUE = 15
                });

                lstProdutos.Add(new ProdutoDTO
                {
                    ID_PRODUTO = 2,
                    NM_PRODUTO = "Mouse Gamer",
                    VL_PRECO = 189.90m,
                    QT_ESTOQUE = 30
                });

                lstProdutos.Add(new ProdutoDTO
                {
                    ID_PRODUTO = 3,
                    NM_PRODUTO = "Monitor 24 polegadas",
                    VL_PRECO = 1299.00m,
                    QT_ESTOQUE = 8
                });

                lstProdutos.Add(new ProdutoDTO
                {
                    ID_PRODUTO = 4,
                    NM_PRODUTO = "Headset USB",
                    VL_PRECO = 129.90m,
                    QT_ESTOQUE = 0
                });

                return lstProdutos;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<ProdutoDTO> InserirProduto(ProdutoDTO request)
        {
            try
            {
                List<ProdutoDTO> lista = lstProdutos();

                if (lista.Any(x => x.ID_PRODUTO == request.ID_PRODUTO)) throw new ProdutoJaExisteException(request.ID_PRODUTO);

                lista.Add(request);
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeletarProduto(int ID_PRODUTO)
        {
            try
            {
                List<ProdutoDTO> lstResponse = lstProdutos();
                var Produto = lstResponse.FirstOrDefault(x => x.ID_PRODUTO == ID_PRODUTO);
                ProdutoDTO Produto2 = lstResponse.Where(x=> x.ID_PRODUTO == Produto.ID_PRODUTO).FirstOrDefault();
                lstResponse.Remove(Produto2);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void AtualizarEstoque(int ID_PRODUTO, int QT_NOVA)
        {
            try
            {
                List<ProdutoDTO> lstResponse = lstProdutos();
                var Produto = lstResponse.Where(x => x.ID_PRODUTO == ID_PRODUTO).FirstOrDefault();
                int estoqueAtual = Produto.QT_ESTOQUE;
                int estoqueNovo = estoqueAtual + QT_NOVA;
                Produto.QT_ESTOQUE = estoqueNovo;
                int index = lstResponse.IndexOf(Produto);
                lstResponse[index] = Produto;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
