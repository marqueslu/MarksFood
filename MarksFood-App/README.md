# FrontEnd

### Pré-Requisitos

- Nodejs. Disponível em [nodejs.org](https://nodejs.org)
-Angular na versão 8. Instruções de instalação do Angular CLI Disponível em [cli.angular.io](https://cli.angular.io)

### Configuração do Projeto

Após instalação dos pré-requisitos (caso não possua), abra o diretório `MarksFood-App` e execute o comando `npm install`.

Obs. Caso esteja usando alguma distribuição linux, será necessário executar o comando `sudo npm install`.

### Configurações de Execução

Após instalar os pacotes do node, acesse o diretório `MarksFood-App/app/environments/` e altere o arquivo `environment.ts` adicionando na propriedade **API**, a porta em que a aplicação esta rodando locamente na sua máquina.

Obs. Esse passo é importante pois existe diferença na porta em que a aplicação é executada via Visual Studio e Via Visual Studio Code

Após esse procedimento, execute o comando `ng serve -o` via linha de comando para execução da aplicação.
