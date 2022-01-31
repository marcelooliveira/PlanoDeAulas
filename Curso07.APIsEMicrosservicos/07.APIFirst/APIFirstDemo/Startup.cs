using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace APIFirstDemo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Activity.DefaultIdFormat = System.Diagnostics.ActivityIdFormat.W3C;

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            services.AddSwaggerGen(options =>
            {
                //Definir o documento OpenAPI
                //que será criado pelo Swagger generator
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    //Versão do documento openApi
                    Version = "v1",
                    //Título da API
                    Title = "ToDo API",
                    //Descrição da API
                    Description = "Uma Web API ASP.NET Core para gerenciamento de tarefas",
                    //Termos de serviço
                    TermsOfService = new Uri("https://example.com/termos"),
                    //Contato
                    Contact = new OpenApiContact
                    {
                        //Nome do contato
                        Name = "Fulano de Tal",
                        //Url do contato
                        Url = new Uri("https://example.com/fulano")
                    },
                    License = new OpenApiLicense
                    {
                        //Nome da licença
                        Name = "Licença de exemplo",
                        //Url da licença
                        Url = new Uri("https://example.com/license")
                    }
                });

                //arquivo xml
                var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //incluir/injetar comentários xml
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,
                    xmlFileName));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            //registra o Swagger
            app.UseSwagger();

            //registra o Swagger com interface do usuário
            app.UseSwaggerUI(options =>
            {
                //Adicionar endpoint do Swagger Json
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                //prefixo de rota para acessar o swagger-ui
                options.RoutePrefix = string.Empty;
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
