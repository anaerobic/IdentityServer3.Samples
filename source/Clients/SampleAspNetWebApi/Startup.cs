using Microsoft.Owin;
using Owin;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens;
using Thinktecture.IdentityServer.AccessTokenValidation;

[assembly: OwinStartup(typeof(SampleAspNetWebApi.Startup))]

namespace SampleAspNetWebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            JwtSecurityTokenHandler.InboundClaimTypeMap = new Dictionary<string, string>();

            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
                {
                    Authority = ConfigurationManager.AppSettings["Authority"],
                    RequiredScopes = new[] { "write" },
                    ValidationMode = ValidationMode.ValidationEndpoint
                });

            app.UseWebApi(WebApiConfig.Register());
        }
    }
}