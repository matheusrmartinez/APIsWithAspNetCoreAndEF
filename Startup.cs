using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ProductCatalog.Data;
using ProductCatalog.Repositories;

namespace ProductCatalog
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            //Verifica se existe um StoreDataContext na memória, se não cria 1.
            services.AddScoped<StoreDataContext, StoreDataContext>(); 
            services.AddTransient<ProductRepository, ProductRepository>(); 
            //Não faz a verificação, somente abre uma nova conexão com o banco. (Opção ruim)
            //services.AddTransient<StoreDataContext, StoreDataContext>();
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
