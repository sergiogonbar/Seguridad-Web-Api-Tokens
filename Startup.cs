using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using WebApiTokens.Credentials;

[assembly: OwinStartup(typeof(WebApiTokens.Startup))]

namespace WebApiTokens
{
    public class Startup
    {
        public void ConfigurarOAuth(IAppBuilder app)
        {

            OAuthAuthorizationServerOptions authoptions =
                new OAuthAuthorizationServerOptions()
                { AllowInsecureHttp = true
                    //RUTA DE ACCESO AL TOKEN
                    ,
                    TokenEndpointPath = new PathString("/api/login") ,
                    AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(10),
                    Provider = new AutorizacionCredentialsToken()
                };
           app.UseOAuthAuthorizationServer(authoptions);
           OAuthBearerAuthenticationOptions beareroptions = new OAuthBearerAuthenticationOptions()
                {
                    AuthenticationMode =
                    Microsoft.Owin.Security.AuthenticationMode.Active
                };
            
            app.UseOAuthBearerAuthentication(beareroptions);
        }
        public void Configuration(IAppBuilder app)
        {
           
            HttpConfiguration config = new HttpConfiguration();
            
            WebApiConfig.Register(config);
          
            ConfigurarOAuth(app);
           
            app.UseWebApi(config);
        }
    }
}
