using System;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using IdentityServer3.Core.Configuration;
using Microsoft.Owin;
using Owin;
using IdentityServer3.EntityFramework;
using System.Collections.Generic;
using IdentityServer3.Core.Models;
using System.Linq;
using System.Data.SqlClient;
using IdentityServer3.Core.Services;
using SocialNetwork.Data.Repositories;

[assembly: OwinStartup(typeof(SocialNetwork.OAuth.Startup))]

namespace SocialNetwork.OAuth
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var entityFrameworkOptions = new EntityFrameworkServiceOptions
            {
                ConnectionString =
                    ConfigurationManager.ConnectionStrings["SocialNetwork.Idsvr"].ConnectionString
            };
            var inMemoryManager = new InMemoryManager();
            SetupClients(inMemoryManager.GetClients(), entityFrameworkOptions);
            SetupScopes(inMemoryManager.GetScopes(), entityFrameworkOptions);
            var userRepository = new Data.Repositories.UserRepository(
                () => new SqlConnection(ConfigurationManager.ConnectionStrings["SocialNetwork"].ConnectionString)
            );

            var factory = new IdentityServerServiceFactory();
            factory.RegisterConfigurationServices(entityFrameworkOptions);
            factory.RegisterOperationalServices(entityFrameworkOptions);
            factory.UserService = new Registration<IUserService>(typeof(SocialNetworkUserService));
            factory.Register(new Registration<IUserRepository>(userRepository));

            new TokenCleanup(entityFrameworkOptions, 1).Start();

            var options=new IdentityServerOptions
            {
                SigningCertificate = new X509Certificate2(Convert.FromBase64String(ConfigurationManager.AppSettings["SigningCertificate"]),ConfigurationManager.AppSettings["SigningCertificatePassword"]),
                RequireSsl = false,//
                Factory = factory//,
                //AuthenticationOptions = new AuthenticationOptions { EnablePostSignOutAutoRedirect = true}
            };

            app.UseIdentityServer(options);
        }

        public void SetupClients(IEnumerable<Client> clients,
                                    EntityFrameworkServiceOptions options)
        {
            using (var context =
                new ClientConfigurationDbContext(options.ConnectionString,
                                                options.Schema))
            {
                if (context.Clients.Any()) return;

                foreach (var client in clients)
                {
                    context.Clients.Add(client.ToEntity());
                }

                context.SaveChanges();
            }
        }

        public void SetupScopes(IEnumerable<Scope> scopes,
                                 EntityFrameworkServiceOptions options)
        {
            using (var context =
                new ScopeConfigurationDbContext(options.ConnectionString,
                                                options.Schema))
            {
                if (context.Scopes.Any()) return;

                foreach (var scope in scopes)
                {
                    context.Scopes.Add(scope.ToEntity());
                }

                context.SaveChanges();
            }
        }
    }
}
