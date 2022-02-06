















OpenID Connect permite cenários onde um login pode ser usado em vários aplicativos, também conhecido como single sign-on (SSO).

OAuth 2.0 foi projetado apenas para autorização, para conceder acesso a dados e recursos de um aplicativo para outro. ... 







:: Primeiro, crie uma nova solucao:

dotnet new sln -n ProtegendoUmaAPI

:: Para instalar os templates do IdentityServer4 abra uma janela de console e digite o seguinte comando:

dotnet new -i IdentityServer4.Templates

:: depois use o template para criar um aplicativo ASP.NET Core que inclua uma configuracao basica do IdentityServer:

dotnet new is4empty -n IdentityServer
:: Adicionando o projeto IdentityServer a solucao

dotnet sln add IdentityServer\IdentityServer.csproj

:: O projeto Api conterá um endpoint protegido por autorização: somente um aplicativo autorizado pelo IdentityServer poderá acessar esse endpoint.

dotnet new webapi -n Api -f netcoreapp3.1
dotnet sln add Api\Api.csproj

:: O projeto cliente vai solicitar um token de acesso e, em seguida, use esse token para acessar a API. Para isso, adicione um projeto de console à sua solução, lembre-se de criá-lo no src:

dotnet new console -n Client -f netcoreapp3.1
dotnet sln add Client\Client.csproj

start ProtegendoUmaAPI.sln

:: Definindo um escopo de API
:: Uma API e um recurso em seu sistema que voce deseja proteger. As definicoes de recursos podem ser carregadas de varias maneiras, o modelo que voce usou para criar o projeto acima mostra como usar uma abordagem de “codigo como configuracao”.

O Config.cs ja esta criado para voce. Abra-o, atualize o codigo para ficar assim:

:: Adicione ao Config.cs:
:: 
:: public static class Config
:: {
::     public static IEnumerable<ApiScope> ApiScopes =>
::         new List<ApiScope>
::         {
::             new ApiScope("api1", "My API")
::         };
:: }


:: Definindo o cliente
:: A proxima etapa e definir um aplicativo cliente que usaremos para acessar nossa nova API. Para este cenario, o cliente nao tera um usuario interativo e se autenticara usando o chamado segredo do cliente com o IdentityServer. Para isso, adicione uma definicao de cliente:

:: public static IEnumerable<Client> Clients =>
::     new List<Client>
::     {
::         new Client
::         {
::             ClientId = "client",
:: 
::             //nenhum usuário interativo, 
::             //use o clientid/secret para autenticação
::             AllowedGrantTypes = GrantTypes.ClientCredentials,
:: 
::             // segredo para autenticação
::             ClientSecrets =
::             {
::                 new Secret("secret".Sha256())
::             },
:: 
::             // escopos aos quais o cliente tem acesso
::             AllowedScopes = { "api1" }
::         }
::     };

:: Você pode pensar no ClientId e no ClientSecret como o login e a senha do seu próprio aplicativo. Ele identifica seu aplicativo para o servidor de identidade para que saiba qual aplicativo está tentando se conectar a ele.
    
    
:: 
:: Configurando o IdentityServer
:: O carregamento do recurso e das definicoes do cliente acontece em Startup.cs - atualize o codigo para ficar assim:

:: public void ConfigureServices(IServiceCollection services)
:: {
::     var builder = services.AddIdentityServer()
::         .AddDeveloperSigningCredential()        //This is for dev only scenarios when you don’t have a certificate to use.
::         .AddInMemoryApiScopes(Config.ApiScopes)
::         .AddInMemoryClients(Config.Clients);
:: 
::     // omitted for brevity
:: }

:: RODAR COM F5


:: É isso - seu servidor de identidade agora deve estar configurado. Se voce executar o servidor e navegar no navegador para https://localhost:5001/.well-known/openid-configuration, devera ver o chamado documento de descoberta. O documento de descoberta e um endpoint padrao em servidores de identidade. O documento de descoberta sera usado por seus clientes e APIs para baixar os dados de configuracao necessarios.

:: https://localhost:5001/.well-known/openid-configuration

Configurando a API

:: Abra o projeto Api e apague a configuração IISExpress. Configure o endpoint para https://localhost:5000 somente.

:: Middleware ASP.NET Core que permite que um aplicativo receba um token de portador OpenID Connect.
dotnet add api\Api.csproj package Microsoft.AspNetCore.Authentication.JwtBearer -v 3.1.22

Adicione uma nova classe chamada IdentityController:

[Route("identity")]
[Authorize]
public class IdentityController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
    }
}

Este controlador será usado posteriormente para testar o requisito de autorização, bem como visualizar a identidade das declarações através dos olhos da API.


Configuração

:: A última etapa é adicionar os serviços de autenticação ao DI (injeção de dependência) e o middleware de autenticação ao pipeline. Estes vão:

:: validar o token de entrada para garantir que ele seja proveniente de um emissor confiável
:: validar se o token é válido para ser usado com esta api (também conhecido como público)
:: Atualize o Startup para ficar assim:

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        services.AddAuthentication("Bearer")
            .AddJwtBearer("Bearer", options =>
            {
                options.Authority = "https://localhost:5001";

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false
                };
            });
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}

:: O que o código faz?
:: AddAuthentication adiciona os serviços de autenticação ao DI e configura o Bearer como o esquema padrão.
:: UseAuthentication adiciona o middleware de autenticação ao pipeline para que a autenticação seja executada automaticamente em cada chamada no host.
:: UseAuthorization adiciona o middleware de autorização para garantir que nosso endpoint de API não possa ser acessado por clientes anônimos.

:: DEFINA MÚLTIPLOS projetos

:: Navegar para o controlador https://localhost:5000/identity em um navegador deve retornar um código de status 401. Isso significa que sua API requer uma credencial e agora está protegida pelo IdentityServer.

:: CONFIGURANDO O CLIENTE
:: ======================

:: O cliente solicita um token de acesso e, em seguida, use esse token para acessar a API.

:: O endpoint IdentityServer implementa o protocolo OAuth 2.0 e você pode usar HTTP  para acessá-lo. No entanto, temos uma biblioteca cliente chamada IdentityModel, que encapsula a interação do protocolo em uma API fácil de usar.

:: Adicione o pacote IdentityModel NuGet ao seu cliente. Isso pode ser feito por meio do gerenciador de pacotes Nuget do Visual Studio ou CLI do dotnet:

dotnet adicionar pacote IdentityModel

:: IdentityModel inclui uma biblioteca de cliente para usar com o endpoint de descoberta. Dessa forma, você só precisa saber o endereço base do IdentityServer - os endereços reais do endpoint podem ser lidos nos metadados:

// descobre endpoints a partir de metadados
var client = new HttpClient();
var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5001");
if (disco.IsError)
{
    Console.WriteLine(disco.Error);
    return;
}




Em seguida, você pode usar as informações do documento de descoberta para solicitar um token ao IdentityServer para acessar api1:

// request token
var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
{
    Address = disco.TokenEndpoint,

    ClientId = "client",
    ClientSecret = "secret",
    Scope = "api1"
});

if (tokenResponse.IsError)
{
    Console.WriteLine(tokenResponse.Error);
    return;
}

Console.WriteLine(tokenResponse.Json);

//Impede que a tela se feche
Console.ReadKey();



Chamando a API

Para enviar o token de acesso à API, você normalmente usa o cabeçalho HTTP Authorization. Isso é feito usando o método de extensão SetBearerToken:

// chama a api
var apiClient = new HttpClient();
apiClient.SetBearerToken(tokenResponse.AccessToken);

var response = await apiClient.GetAsync("https://localhost:5000/identity");
if (!response.IsSuccessStatusCode)
{
    Console.WriteLine(response.StatusCode);
}
else
{
    var content = await response.Content.ReadAsStringAsync();
    Console.WriteLine(JArray.Parse(content));
}

Autorização na API

No momento, a API aceita qualquer token de acesso emitido pelo seu servidor de identidade.

A seguir, adicionaremos um código que permite verificar a presença do escopo no token de acesso que o cliente solicitou (e obteve). Para isso, usaremos o sistema de política de autorização ASP.NET Core. Adicione o seguinte ao método ConfigureServices na inicialização:

services.AddAuthorization(options =>
{
    options.AddPolicy("ApiScope", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "api1");
    });
});

Agora você pode aplicar essa política em vários níveis, por exemplo,

globalmente
para todos os endpoints da API
para controladores/ações específicos

Normalmente, você configura a política para todos os endpoints da API no sistema de roteamento:

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers()
        .RequireAuthorization("ApiScope");
});

VocÊ pode modificar a action do controller para especificar qual policy é autorizada:

    [Authorize("ApiScope")]

Se você mudar abaixo, a api retornará InternalServerError:

    [Authorize("ApiScopeXXX")]




