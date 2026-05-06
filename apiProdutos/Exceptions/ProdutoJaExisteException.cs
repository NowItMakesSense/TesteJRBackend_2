using System;

namespace apiProdutos.Exceptions
{
    public class ProdutoJaExisteException : Exception
    {
        public ProdutoJaExisteException(int id) : base($"Já existe um produto com o ID {id}.")
        {
        }
    }
}
