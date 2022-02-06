echo Para instalar os templates abra uma janela de console e digite o seguinte comando:

dotnet new -i IdentityServer4.Templates

echo Primeiro, crie uma nova solucao:
echo
echo dotnet new sln -n ProtegendoUmaAPI

dotnet new sln -n ProtegendoUmaAPI
echo depois use nosso modelo para criar um aplicativo ASP.NET Core que inclua uma configuracao basica do IdentityServer:
echo dotnet new is4empty -n IdentityServer

dotnet new is4empty -n IdentityServer
echo Adicionando o projeto IdentityServer a solucao
echo dotnet sln add IdentityServer\IdentityServer.csproj

dotnet sln add IdentityServer\IdentityServer.csproj

echo 

echo Definindo um escopo de API
echo Uma API e um recurso em seu sistema que voce deseja proteger. As definicoes de recursos podem ser carregadas de varias maneiras, o modelo que voce usou para criar o projeto acima mostra como usar uma abordagem de “codigo como configuracao”.

O Config.cs ja esta criado para voce. Abra-o, atualize o codigo para ficar assim:
echo Adicione ao Config.cs:
echo 
echo Definindo o cliente
echo A proxima etapa e definir um aplicativo cliente que usaremos para acessar nossa nova API. Para este cenario, o cliente nao tera um usuario interativo e se autenticara usando o chamado segredo do cliente com o IdentityServer. Para isso, adicione uma definicao de cliente:
echo 
echo Configurando o IdentityServer
echo O carregamento do recurso e das definicoes do cliente acontece em Startup.cs - atualize o codigo para ficar assim:
echo 
echo 
echo E isso - seu servidor de identidade agora deve estar configurado. Se voce executar o servidor e navegar no navegador para https://localhost:5001/.well-known/openid-configuration, devera ver o chamado documento de descoberta. O documento de descoberta e um endpoint padrao em servidores de identidade. O documento de descoberta sera usado por seus clientes e APIs para baixar os dados de configuracao necessarios.
dotnet new webapi -n Api -f netcoreapp3.1
dotnet sln add Api\Api.csproj
dotnet new console -n Client -f netcoreapp3.1
dotnet sln add Client\Client.csproj
dotnet build
cd IdentityServer
dotnet run
cd ..
chrome "https://localhost:5001/.well-known/openid-configuration"
