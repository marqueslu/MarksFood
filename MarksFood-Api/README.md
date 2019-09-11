
#  BackEnd

###  Pré-requisitos

- .Net Core 2.2. Disponível em [dotnet.microsoft.com](https://dotnet.microsoft.com/download)

- SQL Server. Caso não possua, siga o passo a passo disponível nesse link para configurar: [hub.docker.com](https://hub.docker.com/_/microsoft-mssql-server)

  
###  Configuração da base de dados

Antes de rodarmos a aplicação, é importante configurar a base dados.

No projeto `MarksFoodApi.Infra` contém dois arquivos no diretório `scripts` que auxiliaram na estruturação da base de dados.

- DatabaseStructure.sql (Arquivo responsável pela criação da base e das procedures)

- DatabaseInsert.Sql (Arquivo responsável pela carga inicial de dados)

  
###  Cofiguração da aplicação

Após a configuração da base de dados, altere a connection string diponível no projeto `MarksFoodApi.Api` no arquivo `appsettings.json`


###  Execução

Após isso, defina o projeto `MarksFoodApi.Api` como **startup project** caso o mesmo já não esteja configurado.

Para realizar esse procedimento é só clicar com o botão direito no projeto, e selecionar a opção `set as startup project`.

Obs. Esse procedimento é somente para quem estiver executando o projeto através do Visual Studio.
  
Caso esteja executando o projeto através do visual code, entre no diretório do projeto `MarksFoodAPi.Api` via terminal e execute o comando `dotnet run` para executar a aplicação.