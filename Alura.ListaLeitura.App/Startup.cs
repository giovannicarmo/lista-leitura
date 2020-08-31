using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Alura.ListaLeitura.App
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }

        public void Configure(IApplicationBuilder app)
        {
            var builder = new RouteBuilder(app);
            builder.MapRoute("livros/paraler", LivrosLogica.Paraler);
            builder.MapRoute("livros/lendo", LivrosLogica.Lendo);
            builder.MapRoute("livros/lidos", LivrosLogica.Lidos);
            builder.MapRoute("livros/detalhes/{id:int}", LivrosLogica.LivroDetalhes);
            builder.MapRoute("cadastro/livro/{nome}/{autor}", CadastroLogica.NovoLivroParaLer);
            builder.MapRoute("cadastro/novo", CadastroLogica.ExibeFormulario);
            builder.MapRoute("cadastro/incluir", CadastroLogica.ResolverFormulario);

            var routes = builder.Build();

            app.UseRouter(routes);
        }
    }
}
