
using LABA_WebAdmin_Corporate.Lib;
using LABA_WebAdmin_Corporate.Mapper;
using LABA_WebAdmin_Corporate.Middlewares;
using LABA_WebAdmin_Corporate.Models;
using LABA_WebAdmin_Corporate.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace LABA_WebAdmin_Corporate
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
					//Domain = "cms.labadalat.com", //Releases in active
					Name = "AuthCMS",
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

			services.AddAutoMapper(typeof(AutoMapperProfile).Assembly); //AutoMapperProfile
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
			services.AddSingleton<IS_Image, S_Image>();
			services.AddSingleton<IS_Address, S_Address>();
			services.AddSingleton<IS_Farm, S_Farm>();
			services.AddSingleton<IS_About, S_About>();
			services.AddSingleton<IS_NewsCategory, S_NewsCategory>();
			services.AddSingleton<IS_News, S_News>();
			services.Configure<Config_ApiSettings>(Configuration.GetSection("ApiSettings"));
			services.Configure<Config_ApiSettings>(Configuration.GetSection("TokenUploadFile"));

			services.AddControllersWithViews();
			services.AddRazorPages().AddRazorRuntimeCompilation();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
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
					name: "Farm Manage",
					pattern: "thong-tin-doanh-nghiep",
					defaults: new { controller = "FarmManage", action = "Index" }
					);

				endpoints.MapControllerRoute(
					name: "About Manage",
					pattern: "gioi-thieu",
					defaults: new { controller = "AboutManage", action = "Index" }
					);

				endpoints.MapControllerRoute(
					name: "Services Category Manage",
					pattern: "danh-muc-dich-vu",
					defaults: new { controller = "ServicesCategoryManage", action = "Index" }
					);

				endpoints.MapControllerRoute(
					name: "Services Manage",
					pattern: "dich-vu",
					defaults: new { controller = "ServicesManage", action = "Index" }
					);

				endpoints.MapControllerRoute(
					name: "News Category Manage",
					pattern: "danh-muc-tin-tuc",
					defaults: new { controller = "NewsCategoryManage", action = "Index" }
					);

				endpoints.MapControllerRoute(
					name: "News Manage",
					pattern: "tin-tuc",
					defaults: new { controller = "NewsManage", action = "Index" }
					);

				endpoints.MapControllerRoute(
					name: "Account",
					pattern: "dang-xuat",
					defaults: new { controller = "Account", action = "SignOut" }
					);

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
