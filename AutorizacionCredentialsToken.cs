using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using WebApiTokens.Models;
using WebApiTokens.Repositories;

namespace WebApiTokens.Credentials
{
    public class AutorizacionCredentialsToken : OAuthAuthorizationServerProvider
    {
        RepositoriesUsuarios repo;

        public AutorizacionCredentialsToken()
        {
            this.repo = new RepositoriesUsuarios();
        }
        public override  Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
            return base.ValidateClientAuthentication(context);
        }

        public override  Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            String nombre = context.UserName;
            String pass = context.Password;
            Usuarios usuarios =
                this.repo.ExisteUsuario(nombre, pass);
              
            if (usuarios == null)
            {
               context.SetError("Usuario/Password incorrectos");
            }
            else
            {
                ClaimsIdentity identidad = new ClaimsIdentity(context.Options.AuthenticationType);
                 identidad.AddClaim(new Claim(ClaimTypes.Name,usuarios.Nombre));
                 identidad.AddClaim(new Claim(ClaimTypes.NameIdentifier, usuarios.Password));
                 identidad.AddClaim(new Claim(ClaimTypes.Role, usuarios.Funcion));

                    context.Validated(identidad);
            }
            return base.GrantResourceOwnerCredentials(context);
        }

    }
}
