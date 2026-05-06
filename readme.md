# Teste Técnico — Desenvolvedor Backend Junior C#

## Antes de começar

- Faça um **fork** deste repositório
  > Você precisa estar logado na sua conta GitHub para fazer o fork.
- Ferramentas recomendadas: **Visual Studio 2022** + **.NET SDK** instalado

---

## Regras de entrega

- **Commits obrigatórios:**
  - Ao iniciar: commit com a mensagem exata `"Iniciando o teste de tecnologia"`
  - A cada etapa concluída: pelo menos um commit descrevendo o que foi feito (ex: `"Implementa listagem de produtos"`)
  - Ao finalizar: commit com a mensagem exata `"Finalizado o teste de tecnologia"`
- Não use branches — todo o trabalho deve estar na `main`
- Não há restrições quanto ao uso de bibliotecas externas
- Ao finalizar, envie o link do seu repositório para o RH

---

## O TESTE

O projeto já possui a estrutura base criada. Sua tarefa é implementar os métodos que estão em branco.

### Tarefa 1 — Listar produtos

Implemente o método `lstProdutos` no `ProdutosController`, que deve chamar o método correspondente na classe `Produtos` e retornar a lista de produtos com **HTTP 200**.

### Tarefa 2 — Inserir produto

Implemente o método `InserirProduto` no `ProdutosController`, que deve receber um objeto `ProdutoDTO` pelo body, inserir na lista e retornar a lista atualizada com **HTTP 200**.

### Tarefa 3 — Deletar produto

Implemente o método `DeleteProduto` no `ProdutosController`, que deve receber o `ID_PRODUTO` por query string, deletar o item da lista e retornar a lista atualizada com **HTTP 200**.

Além de implementar:

- **Comente linha a linha** o método `AtualizarEstoque` da classe `Produtos`, explicando o que cada linha faz
- **Trate o cenário de erro** em que o usuário tenta deletar o produto de código `2050` (que não existe na lista)

### Tarefa 4 — Atualizar estoque

Implemente o método `AtualizarEstoque` no `ProdutosController`, que deve receber o `ID_PRODUTO` e a `QT_NOVA` (quantidade a adicionar) por query string, atualizar o estoque do produto e retornar o produto atualizado com **HTTP 200**.

Além de implementar:

- **Trate o cenário de erro** em que o usuário tenta atualizar o estoque com uma quantidade negativa que resultaria em estoque abaixo de zero

---

## BÔNUS

> Não obrigatório, mas demonstra iniciativa.

- Aplicar boas práticas REST nas classes e Controllers (verbos HTTP corretos, status codes adequados)
- Criar método para **buscar um produto por ID**, retornando o objeto correspondente
- Criar método para **buscar produtos por nome** (busca parcial), retornando os produtos que contenham o texto informado no nome
- Criar método para **listar produtos sem estoque** (`QT_ESTOQUE == 0`), retornando apenas os produtos indisponíveis
- Criar método para **calcular o valor total do estoque**, que deve retornar a soma de `VL_PRECO * QT_ESTOQUE` de todos os produtos

---

## Uso de Inteligência Artificial

O uso de ferramentas de IA (ChatGPT, GitHub Copilot, Claude, etc.) **é permitido**.

Porém, **é obrigatório** criar um arquivo chamado `REFLEXAO.md` na raiz do projeto respondendo às perguntas abaixo. Esse arquivo faz parte da avaliação.

```markdown
# Reflexão sobre o Teste

1. Qual foi a decisão técnica mais relevante que você tomou durante o teste? Por quê?

2. Tem alguma parte do código que você não ficou satisfeito? O que faria diferente com mais tempo?

3. Se fosse necessário adicionar um campo "categoria" nos produtos e permitir filtrar por categoria, o que precisaria mudar no projeto?

4. Ferramentas utilizadas:
   - [ ] Usei IA (qual? como?)
   - [ ] Documentação oficial
   - [ ] Stack Overflow / outros sites

   Descreva brevemente como e para quê usou cada ferramenta.

5. (Responda apenas se usou IA) Existe algum trecho de código gerado por IA que você não entendeu completamente mas manteve no projeto? Qual? Por quê?
```

> A sinceridade nas respostas é valorizada. Não há penalização por usar IA — há penalização por omitir o uso.

---

## PONTOS QUE SERÃO AVALIADOS

| Critério                 | O que observamos                                                   |
| ------------------------ | ------------------------------------------------------------------ |
| **Código funcional**     | Os endpoints funcionam? Os status codes estão corretos?            |
| **Boas práticas**        | Nomenclatura, organização, separação de responsabilidades          |
| **Tratamento de erros**  | O código lida bem com situações inesperadas?                       |
| **Histórico de commits** | Os commits são incrementais e as mensagens fazem sentido?          |
| **Clareza**              | O código é legível? Os comentários explicam o raciocínio?          |
| **Reflexão**             | As respostas no `REFLEXAO.md` são coerentes com o código entregue? |
