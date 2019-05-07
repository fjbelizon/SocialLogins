namespace Social.Logins.Web
{
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class Startup
    {
        #region Constructors

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        #endregion

        #region Properties

        public IConfiguration Configuration { get; }

        #endregion

        #region Methods

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddGoogle(options =>
            {
                // Get data from: https://developers.google.com/identity/sign-in/web/sign-in
                options.ClientId = "";
                options.ClientSecret = "";
            })
            .AddMicrosoftAccount(options =>
            {
                // Get data from: https://apps.dev.microsoft.com/
                options.ClientId = "";
                options.ClientSecret = "";
            })
            .AddFacebook(options =>
            {
                // Get data from: https://developers.facebook.com/apps/
                options.AppId = "";
                options.AppSecret = "";
            })
            .AddTwitter(options =>
            {
                // Get data from: https://developer.twitter.com/en/apps
                options.ConsumerKey = "";
                options.ConsumerSecret = "";
            })
            .AddGitHub(options =>
            {
                // Get data from: https://github.com/settings/developers
                options.ClientId = "";
                options.ClientSecret = "";
            })
            .AddCookie(options =>
            {
                options.LoginPath = "/auth/login";
            });

            services.AddMvc();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();

            // End configuration
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        #endregion
    }
}