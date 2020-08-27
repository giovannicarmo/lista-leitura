using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App
{
    public class Startup
    {
        private readonly LivroRepositorioCSV repo = new LivroRepositorioCSV();

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }

        public void Configure(IApplicationBuilder app)
        {
            var builder = new RouteBuilder(app);
            builder.MapRoute("livros/paraler", LivrosParaler);
            builder.MapRoute("livros/lendo", LivrosLendo);
            builder.MapRoute("livros/lidos", LivrosLidos);

            var routes = builder.Build();

            app.UseRouter(routes);
        }

        public Task Routes(HttpContext context)
        {

            var caminhosAtendidos = new Dictionary<string, RequestDelegate>
            {
                {"/livros/paraler", LivrosParaler },
                {"/livros/lendo", LivrosLendo },
                {"/livros/lidos", LivrosLidos },
            };

            if(caminhosAtendidos.ContainsKey(context.Request.Path))
            {
                var method = caminhosAtendidos[context.Request.Path];

                return method.Invoke(context);
            }

            context.Response.StatusCode = 404;
            return context.Response.WriteAsync("Caminho Inesistente");
        }

        public Task LivrosParaler(HttpContext context)
        {

            return context.Response.WriteAsync(repo.ParaLer.ToString());
        }

        public Task LivrosLendo(HttpContext context)
        {

            return context.Response.WriteAsync(repo.Lendo.ToString());
        }

        public Task LivrosLidos(HttpContext context)
        {

            return context.Response.WriteAsync(repo.Lidos.ToString());
        }
    }
}
