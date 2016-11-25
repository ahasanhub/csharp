using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.IdentityModel.Tokens;
using System.Collections.Generic;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.OpenIdConnect;
using System.Security.Claims;
using Microsoft.IdentityModel.Protocols;

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
                PostLogoutRedirectUri = "http://localhost:28037",
                SignInAsAuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                Notifications=new OpenIdConnectAuthenticationNotifications {
                    SecurityTokenValidated = notification => 
                    {
                        var identity=notification.AuthenticationTicket.Identity;
                        identity.AddClaim(new Claim("id_token", notification.ProtocolMessage.IdToken));
                        identity.AddClaim(new Claim("access_token", notification.ProtocolMessage.AccessToken));
                        notification.AuthenticationTicket = new Microsoft.Owin.Security.AuthenticationTicket(identity,notification.AuthenticationTicket.Properties);
                        return Task.FromResult(0);
                    },
                    RedirectToIdentityProvider=notification=>
                    {
                        if (notification.ProtocolMessage.RequestType != OpenIdConnectRequestType.LogoutRequest)
                        {
                            return Task.FromResult(0);
                        }
                        notification.ProtocolMessage.IdTokenHint =
                        notification.OwinContext.Authentication.User.FindFirst("id_token").Value;
                        return Task.FromResult(0);
                    }
                }
            });
        }
    }
}
