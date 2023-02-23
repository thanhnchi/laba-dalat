using LABA_WebPortal_Corporate.Lib;
using LABA_WebPortal_Corporate.Middlewares;
using LABA_WebPortal_Corporate.Models;
using LABA_WebPortal_Corporate.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace LABA_WebPortal_Corporate
{
	public class Startup
	{
		public IConfiguration Configuration { get; }
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		private void GetDefaultHttpClient(IServiceProvider serviceProvider, HttpClient httpClient, string hostUri)
		{
			if (!string.IsNullOrEmpty(hostUri))
				httpClient.BaseAddress = new Uri(hostUri);
			//client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue { NoCache = true };
			httpClient.Timeout = TimeSpan.FromMinutes(1);
			httpClient.DefaultRequestHeaders.Clear();
			httpClient.DefaultRequestHeaders.Add("Accept", "text/html,application/xhtml+xml+json");
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		}
		private HttpClientHandler GetDefaultHttpClientHandler()
		{
			return new HttpClientHandler
			{
				AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
				UseCookies = false,
				AllowAutoRedirect = false,
				UseDefaultCredentials = true,
				/*ClientCertificateOptions = ClientCertificateOption.Manual,
				ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) => true,*/
			};
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{

			services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
			{
				options.Cookie = new CookieBuilder
				{
					//Domain = ".koolselling.com", //Releases in active
					Name = "Authentication",
					HttpOnly = true,
					Path = "/",
					SameSite = SameSiteMode.Lax,
					SecurePolicy = CookieSecurePolicy.Always
				};
				options.LoginPath = new PathString("/Account/SignIn");
				options.LogoutPath = new PathString("/Account/SignOut");
				options.AccessDeniedPath = new PathString("/Error/403");
				options.SlidingExpiration = true;
				options.Cookie.IsEssential = true;
			});
			services.AddSession(options =>
			{
				//options.Cookie.Domain = ".koolselling.com"; //Releases in active
				options.IdleTimeout = TimeSpan.FromMinutes(30);
				options.Cookie.SameSite = SameSiteMode.Lax;
				options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
				options.Cookie.IsEssential = true;
				options.Cookie.HttpOnly = true;
			});

			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

			services.AddHttpClient("base")
				.ConfigureHttpClient((serviceProvider, httpClient) => GetDefaultHttpClient(serviceProvider, httpClient, Configuration.GetSection("ApiSettings:UrlApi").Value))
				.SetHandlerLifetime(TimeSpan.FromMinutes(5)) //Default is 2 min
				.ConfigurePrimaryHttpMessageHandler(x => GetDefaultHttpClientHandler());

			services.AddHttpClient("custom")
				.ConfigureHttpClient((serviceProvider, httpClient) => GetDefaultHttpClient(serviceProvider, httpClient, string.Empty))
				.SetHandlerLifetime(TimeSpan.FromMinutes(5)) //Default is 2 min
				.ConfigurePrimaryHttpMessageHandler(x => GetDefaultHttpClientHandler());

			services.AddSingleton<IBase_CallApi, Base_CallApi>();
			services.AddSingleton<ICallBaseApi, CallBaseApi>();
			services.AddSingleton<ICallApi, CallApi>();
			services.AddSingleton<IS_Home, S_Home>();
			services.AddSingleton<IS_Farm, S_Farm>();
			services.AddSingleton<IS_About, S_About>();
			services.AddSingleton<IS_NewsCategory, S_NewsCategory>();
			services.AddSingleton<IS_News, S_News>();
			services.AddSingleton<IS_Contact, S_Contact>();
			services.Configure<Config_ApiSettings>(Configuration.GetSection("ApiSettings"));
			services.Configure<Config_MetaSEO>(Configuration.GetSection("MetaSEO"));

			services.AddControllersWithViews();
			services.AddRazorPages().AddRazorRuntimeCompilation();
			services.AddMemoryCache();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseStatusCodePagesWithReExecute("/error/{0}");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			GlobalVariables.SetVariablesEnviroment(isDevelop: true /*env.IsDevelopment()*/); //Set global url liverun or develop
			app.UseMiddleware<SecurityHeadersMiddleware>(); //App config security header

			app.UseHttpsRedirection();
			app.UseStaticFiles(new StaticFileOptions
			{
				OnPrepareResponse = ctx =>
				{
					const int durationInSeconds = 7 * 60 * 60 * 24; //7 days
					ctx.Context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.CacheControl] =
						"public,max-age=" + durationInSeconds;
				}
			});

			app.UseRouting();
			app.UseCookiePolicy();

			app.UseAuthentication(); //Authen of Microsoft login session
			app.UseAuthorization();

			app.UseSession();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "Contact",
					pattern: "lien-he",
					defaults: new { controller = "Contact", action = "Index" });

				endpoints.MapControllerRoute(
					name: "News",
					pattern: "tin-tuc",
					defaults: new { controller = "News", action = "Index" });

				endpoints.MapControllerRoute(
					name: "News Detail",
					pattern: "tin-tuc/{titleSlug}-{id}",
					defaults: new { controller = "News", action = "Detail" });

				endpoints.MapControllerRoute(
					name: "Services",
					pattern: "dich-vu",
					defaults: new { controller = "Services", action = "Index" });

				endpoints.MapControllerRoute(
					name: "Services Detail",
					pattern: "dich-vu/{titleSlug}-{id}",
					defaults: new { controller = "Services", action = "Detail" });

				endpoints.MapControllerRoute(
					name: "About IsHot",
					pattern: "gioi-thieu",
					defaults: new { controller = "About", action = "Index" });

				endpoints.MapControllerRoute(
					name: "About",
					pattern: "gioi-thieu/{titleSlug}-{id}",
					defaults: new { controller = "About", action = "Index" });

				endpoints.MapControllerRoute(
					name: "Error status code",
					pattern: "error/{statusCode}",
					defaults: new { controller = "Error", action = "Index" });

				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
