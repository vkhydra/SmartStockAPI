# SmartStockAPI

## Descrição

SmartStockAPI é uma API RESTful construída com ASP.NET Core para gerenciar produtos em um sistema de estoque inteligente. Ela fornece endpoints para criar, ler, atualizar e excluir produtos, além de listar todos os produtos e obter um produto específico por ID. A API utiliza Entity Framework Core com PostgreSQL para persistência dos dados e segue uma arquitetura em camadas para melhor organização e manutenibilidade do código.

## Tecnologias Utilizadas

*   .NET 9.0
*   ASP.NET Core
*   Entity Framework Core
*   Npgsql (PostgreSQL)
*   Swashbuckle.AspNetCore (Swagger)
*   dotenv.net e DotNetEnv

## Pré-requisitos

*   .NET 9.0 SDK ([Download](https://dotnet.microsoft.com/download/dotnet/9.0))
*   PostgreSQL ([Download](https://www.postgresql.org/download/))
*   Um editor de código (Visual Studio Code, Visual Studio, etc.)

## Configuração

1.  Clone o repositório:

    ```bash
    git clone <url-do-seu-repositorio>
    ```

2.  Navegue até o diretório do projeto:

    ```bash
    cd SmartStockAPI
    ```

3.  Crie um arquivo `.env` na raiz do projeto com a seguinte estrutura:

    ```
    DATABASE_URL="Host=<seu-host>;Database=<seu-banco>;Username=<seu-usuario>;Password=<sua-senha>"
    ```

    Substitua os placeholders com as informações do seu banco de dados PostgreSQL.

4.  Execute as migrações do Entity Framework Core para criar o banco de dados:

    ```bash
    dotnet ef database update
    ```

## Como Executar

1.  Navegue até o diretório do projeto:

    ```bash
    cd SmartStockAPI
    ```

2.  Restaure as dependências do projeto:

    ```bash
    dotnet restore
    ```

3.  Execute o projeto:

    ```bash
    dotnet run
    ```

4.  A API estará disponível em `https://localhost:<porta>`. A porta padrão é 5240, mas pode variar dependendo da sua configuração.

## Endpoints

A API fornece os seguintes endpoints:

*   `GET /api/Product`: Lista todos os produtos.
*   `GET /api/Product/{id}`: Obtém um produto por ID.
*   `POST /api/Product`: Cria um novo produto.
*   `PUT /api/Product/{id}`: Atualiza um produto existente.
*   `DELETE /api/Product/{id}`: Exclui um produto.

Você pode usar a interface do Swagger para testar os endpoints da API. Para acessar o Swagger, navegue até `https://localhost:<porta>/swagger`.

## Variáveis de Ambiente

A API utiliza as seguintes variáveis de ambiente:

*   `DATABASE_URL`: String de conexão para o banco de dados PostgreSQL.