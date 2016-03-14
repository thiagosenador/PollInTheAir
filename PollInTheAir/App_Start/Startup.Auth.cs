using System;
using System.Net.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Facebook;
using Microsoft.Owin.Security.MicrosoftAccount;
using Owin;
using PollInTheAir.Domain.Models;
using PollInTheAir.Domain.Repository;

namespace PollInTheAir.Web
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context and user manager to use a single instance per request
            app.CreatePerOwinContext(AppDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            // Configure the sign in cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                SlidingExpiration = false,
                ExpireTimeSpan = TimeSpan.FromMinutes(15),
                Provider = new CookieAuthenticationProvider
                {
                    OnValidateIdentity =
                        SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, User>(
                            validateInterval: TimeSpan.FromMinutes(30),
                            regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });

            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Uncomment the following lines to enable logging in with third party login providers
            app.UseGoogleAuthentication("1058035413863-pmbgn6n7slu0nph17l96nu65r9oeuqui.apps.googleusercontent.com", "J5wsfYCsgClB9G5miL7Bj8A7");

            var facebookOptions = new FacebookAuthenticationOptions()
            {
                AppId = "899746186808173",
                AppSecret = "4a339373d1748469a27a021c376a6ac2",
                BackchannelHttpHandler = new FacebookBackChannelHandler(),
                UserInformationEndpoint = "https://graph.facebook.com/v2.4/me?fields=id,name,email,first_name,last_name,location"
            };

            facebookOptions.Scope.Add("email");

            app.UseFacebookAuthentication(facebookOptions);

            var microsoftOptions = new MicrosoftAccountAuthenticationOptions
            {
                Caption = "Live",
                ClientId = "000000004018626B",
                ClientSecret = "0JN-2FYhsi4z-NnskF3C97A63nSJbkW8"
            };
            microsoftOptions.Scope.Add("wl.basic");
            microsoftOptions.Scope.Add("wl.emails");

            app.UseMicrosoftAccountAuthentication(microsoftOptions);
        }

        public class FacebookBackChannelHandler : HttpClientHandler
        {
            protected override async System.Threading.Tasks.Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
            {
                // Replace the RequestUri so it's not malformed
                if (!request.RequestUri.AbsolutePath.Contains("/oauth"))
                {
                    request.RequestUri = new Uri(request.RequestUri.AbsoluteUri.Replace("?access_token", "&access_token"));
                }

                return await base.SendAsync(request, cancellationToken);
            }
        }
    }
}
