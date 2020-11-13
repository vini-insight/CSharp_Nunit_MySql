# CSharp_Nunit_MySql
C# Nunit MySql

Dependências:

    $ dotnet add package MySql.Data

para acessar bancos de dados MySql ADO.NET framework.

Criação de um projeto do tipo Console Application.

O objetivo é para tratar de uma lista de usuários com as seguintes propriedades: Nome, CPF, Data de nascimento e Sexo a partir da leitura de um arquivo no formato Json.

Validações:

[X] todas as propriedades devem estar preenchidas;

[X] nenhum documento igual;

[X] sexo válido;

[X] data de nascimento valida

[X] que tenha pelo menos dois nomes. EX: "Vinicius" (invalido) e "Vinicius Monteiro" (válido)

[X] após as validações, inserir no "banco de dados".

[X] consulta dados no BD

[X] criar testes de unidade para a aplicação;

[X] testar quantidade de números CPF, e, se apenas números

[X] testar valores data 31 dias, 12 meses...
