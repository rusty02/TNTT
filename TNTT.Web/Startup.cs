using System.Web.Http;
using System.Web.Optimization;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using Owin;
using TNTT.Web.App_Start;
using TNTT.Web.Provider;

[assembly: OwinStartup(typeof(TNTT.Web.Startup))]

namespace TNTT.Web
{
    public partial class Startup
    {
        public const string ExternalCookieAuthenticationType = CookieAuthenticationDefaults.ExternalAuthenticationType;
        public const string ExternalOAuthAuthenticationType = "ExternalToken";

        static Startup()
        {
            PublicClientId = "self";

            IdentityManagerFactory = new IdentityManagerFactory(IdentityConfig.Settings, () => new IdentityStore());

            CookieOptions = new CookieAuthenticationOptions();

            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = "/Token",
                AuthorizeEndpointPath = "/api/Account/ExternalLogin",
                Provider = new ApplicationOAuthProvider(PublicClientId, IdentityManagerFactory, CookieOptions)
            };
        }

        public void Configuration(IAppBuilder app)
        {
            // Enable the application to use cookies to authenticate users
            app.UseCookieAuthentication(CookieOptions);

            // Enable the application to use a cookie to store temporary information about a user logging in with a third party login provider
            app.UseExternalSignInCookie(ExternalCookieAuthenticationType);

            // Enable the application to use bearer tokens to authenticate users
            app.UseOAuthBearerTokens(OAuthOptions, ExternalOAuthAuthenticationType);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //    consumerKey: "",
            //    consumerSecret: "");

            //app.UseFacebookAuthentication(
            //    appId: "",
            //    appSecret: "");

            app.UseGoogleAuthentication();

            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                  name: "DefaultApi",
                  routeTemplate: "api/{controller}/{id}",
                  defaults: new { id = RouteParameter.Optional }
              );
            GlobalConfig.CustomizeConfig(config);
            app.UseWebApi(config);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            
        }

        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public static CookieAuthenticationOptions CookieOptions { get; private set; }

        public static IdentityManagerFactory IdentityManagerFactory { get; set; }

        public static string PublicClientId { get; private set; }


    }
}