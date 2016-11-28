using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Reflection;

namespace OAuth.IdentityServer4.Serv
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            var connectionString = @"server=SHAPLA-PC\SQLEXPRESS;database=IdentityServer4;UID=sa;PWD=mzaman9";
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            //services.AddIdentityServer()
            //    .AddTemporarySigningCredential()
            //    .AddInMemoryPersistedGrants()
            //    .AddInMemoryScopes(Config.GetScopes())
            //    .AddInMemoryClients(Config.GetClients())
            //    .AddInMemoryUsers(Config.GetUsers());
            // configure identity server with in-memory users, but EF stores for clients and scopes
            services.AddIdentityServer()
                .AddTemporarySigningCredential()
                .AddInMemoryUsers(Config.GetUsers())
                .AddConfigurationStore(builder =>
                    builder.UseSqlServer(connectionString, options =>
                        options.MigrationsAssembly(migrationsAssembly)))
                .AddOperationalStore(builder =>
                    builder.UseSqlServer(connectionString, options =>
                        options.MigrationsAssembly(migrationsAssembly)));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            // this will do the initial DB population
            //InitializeDatabase(app);
            loggerFactory.AddConsole(LogLevel.Debug);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseIdentityServer();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
        private void InitializeDatabase(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();

                var context = scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
                context.Database.Migrate();
                if (!context.Clients.Any())
                {
                    var rr = Config.GetClients();
                    foreach (var client in Config.GetClients())
                    {
                        context.Clients.Add(client.ToEntity());
                    }
                    context.SaveChanges();
                }

                if (!context.Scopes.Any())
                {
                    foreach (var client in Config.GetScopes())
                    {
                        context.Scopes.Add(client.ToEntity());
                    }
                    context.SaveChanges();
                }
            }
        }
    }
}
