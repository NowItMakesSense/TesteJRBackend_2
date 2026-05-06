# Reflexão sobre o Teste

1. Qual foi a decisão técnica mais relevante que você tomou durante o teste? Por quê?

A decisão mais relevante foi modelar regras de negócio com exceptions customizadas e tratá-las no controller com status HTTP adequados.
Alem de aplicar as boas práticas REST nas classes e Controllers, padronizando o codigo e deixando mais legivel e melhor de manutenção. 

2. Tem alguma parte do código que você não ficou satisfeito? O que faria diferente com mais tempo?

O código está correto funcionalmente, mas ainda não está pronto para ser colocado para produção. 
Faltam persistência real (pois não tem algum banco de dados salvando as informações), separação de responsabilidades e testes. 
Com mais tempo, eu evoluiria para uma arquitetura baseada em camadas com EF Core, tratamento global de exceções e cobertura de testes, transformando a API de um mock funcional para uma solução escalável.

3. Se fosse necessário adicionar um campo "categoria" nos produtos e permitir filtrar por categoria, o que precisaria mudar no projeto?

Em um cenário real, eu provavelmente modelaria categoria como uma entidade separada e usaria relacionamento para liga-los, evitando strings livres e garantindo a integridade dos dados.
Ex:

public class Categoria
{
    public int Id { get; set; }
    public string Nome { get; set; }
}

4. Ferramentas utilizadas:
   - [ x ] Usei IA (qual? como?)
   - [ x ] Documentação oficial
   - [ ] Stack Overflow / outros sites

   Utilizei um pouco do ChatGPT como IA apenas para me ajudar a pensar em melhores soluções para poder padronizar o projeto sem ter que ajustar muito o codigo e deixa-lo irreconhecivel.
   Assim, acabei pedindo apenas para me sugerir um padrao e implementei todo conteudo de forma manual. 
   Depois de definido e codado, pedi apenas que me ajuda-se a revisar o codigo para ver se deixei algo escapar.

5. (Responda apenas se usou IA) Existe algum trecho de código gerado por IA que você não entendeu completamente mas manteve no projeto? Qual? Por quê?

Não. Como dito anteriormente, não pedi o código pronto para ele, apenas pedi sugestões de padrão para poder utilizar sem extrapolar demais. 

Estou acostumado a utilizar Clean Architecture, CQRS etc. O que me faz querer mexer muito no código e deixar ele mais escalável, desacoplado e mais fácil de testar. 
Por isso apenas pedi um padrão limpo, organizado e fácil de aplicar sem deixar o teste irreconhecível para quem o montou. 
Apenas nisso foi utilizado, então tenho bastante conciencia do codigo aplicado no projeto.