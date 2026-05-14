using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using Owin;
using System.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

[assembly: OwinStartup(typeof(TuProyecto.Startup))]
namespace TuProyecto
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Define una clave secreta fija (mínimo 32 caracteres)
            var secret = "4d6d6a6d6a6d6a6d6a6d6a6d6a6d6a6d6a6d6a6d6a6d6a6d6a6d6a6d6a6d6a6d";
            var key = Encoding.Default.GetBytes(secret);

            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateLifetime = false // Falso para que el token fijo no expire
                    }
                });
        }
    }
}