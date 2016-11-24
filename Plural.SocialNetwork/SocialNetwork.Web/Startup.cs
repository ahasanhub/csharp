using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.IdentityModel.Tokens;
using System.Collections.Generic;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.OpenIdConnect;

[assembly: OwinStartup(typeof(SocialNetwork.Web.Startup))]

namespace SocialNetwork.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            JwtSecurityTokenHandler.InboundClaimTypeMap
                = new Dictionary<string, string>();

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie
            });
            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                ClientId = "socialnetwork_implicit",
                Authority = "http://localhost:23837",
                RedirectUri = "http://localhost:28037",
                ResponseType = "token id_token",
                Scope = "openid profile",
                SignInAsAuthenticationType = DefaultAuthenticationTypes.ApplicationCookie
            });
        }
    }
}
