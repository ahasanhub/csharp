using System;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using IdentityServer3.Core.Configuration;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SocialNetwork.OAuth.Startup))]

namespace SocialNetwork.OAuth
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var inMemoryManager = new InMemoryManager();
            var factory = new IdentityServerServiceFactory()
                .UseInMemoryClients(inMemoryManager.GetClients())
                .UseInMemoryScopes(inMemoryManager.GetScopes())
                .UseInMemoryUsers(inMemoryManager.GetUsers());
            var options=new IdentityServerOptions
            {
                SigningCertificate = new X509Certificate2(Convert.FromBase64String(ConfigurationManager.AppSettings["SigningCertificate"]),ConfigurationManager.AppSettings["SigningCertificatePassword"]),
                RequireSsl = false,//
                Factory = factory//,
                //AuthenticationOptions = new AuthenticationOptions { EnablePostSignOutAutoRedirect = true}
            };

            app.UseIdentityServer(options);
        }
    }
}
