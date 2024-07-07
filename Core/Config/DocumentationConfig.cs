using Microsoft.OpenApi.Models;

namespace TWJobs.Core.Config;


public static class DocumentationConfig
{
    public static void RegisterDocumentation(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        { 
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "TW Jobs API",
                Description = "API de um portal de vagas de emprego",
                Contact = new OpenApiContact
                {
                    Name = "Antonio Amaral",
                    Url = new Uri("https://www.afmixshopping.com.br"),
                    Email = "contato@afmixshopping.com.br"
                }
            }); 
        });
    }
}