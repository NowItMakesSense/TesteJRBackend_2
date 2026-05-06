using System;

namespace apiProdutos.Exceptions
{
    public class EstoqueInvalidoException : Exception
    {
        public EstoqueInvalidoException() : base("Operação inválida: o estoque não pode ficar negativo.")
        {
        }
    }
}
