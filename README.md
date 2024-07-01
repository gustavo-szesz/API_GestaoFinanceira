Backend - Gestão Financeira
Este repositório contém a parte Backend do projeto de aplicação Gestão Financeira, desenvolvido para a disciplina Modelos de Processos de Software, ministrada pelo professor Evandro Zatti.

Tecnologias Utilizadas
C# e .NET Core: Implementação do backend utilizando o padrão de projeto MVC.
PostgreSQL: Banco de dados utilizado para armazenamento das informações.
Entity Framework: ORM utilizado para facilitar a interação com o banco de dados.
DTOs: Utilizados para transferir dados entre a aplicação e o banco de dados.
Funcionalidades
Exemplos de Funções PATCH
csharp
Copiar código
[HttpPatch("{cnpj}/associar-a-pessoa")]
public async Task<IActionResult> AssociarEmpresa(string cnpj, int pessoaId)
{
    // Implementação da função
}
Configuração
Para configurar o PostgreSQL, edite o arquivo appsettings.json e altere os parâmetros de conexão:

json
Copiar código
"ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=VARIABLE;Username=VARIABLE;Password=VARIABLE"
}
Testes
Utilize o arquivo API_GestaoFinanceira.http para exemplos de requisições do sistema e realização de testes.

Considerações sobre Relacionamentos em Tabelas
O Swagger exibe as tabelas de forma aninhada nas suas requisições, o que pode resultar em um JSON extenso. Para facilitar, você pode excluir o campo ID e, nos campos aninhados (por exemplo, usuario[]), também excluir o campo correspondente. Exceção: Quando o campo for uma chave primária da tabela (exemplo: LancamentoValoresID).
