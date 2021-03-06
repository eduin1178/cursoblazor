using Blazored.LocalStorage;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MITIENDA.BlazorServer.Data.Providers;
using MITIENDA.Services;
using MITIENDA.Data.SqlServer;
using MITIENDA.Data.Entities;
using Sotsera.Blazor.Toaster.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace MITIENDA.BlazorServer
{    
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
                        
            services.AddDbContext<MiTiendaDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("MiTiendaDbContext")),
                    ServiceLifetime.Transient);


			//AUTENTICACION CON COOKIES
			services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
				{
                    options.LoginPath = "/auth/login";
                    options.AccessDeniedPath = "/auth/login";
                    options.Cookie.Name = "MITIENDA";
                    options.ForwardSignIn = CookieAuthenticationDefaults.AuthenticationScheme;
				});


            services.AddScoped<MiTiendaDbContext>();
            services.AddScoped<UsuariosService>();
            services.AddScoped<RolesService>();

            services.AddScoped<CategoriasService>();
            services.AddScoped<ProductoService>();
            services.AddScoped<ClientesService>();
            services.AddScoped<FacturasService>();

            //services.AddScoped<AuthProvider>();
            
            services.AddHttpContextAccessor();
            services.AddScoped<HttpContextAccessor>();

            services.AddScoped<AuthenticationStateProvider, CookieAuthenticationState>();

            //TERCEROS

            services.AddSweetAlert2();
            services.AddBlazoredLocalStorage();

            // Add the library to the DI system
            services.AddToaster(config =>
            {
                //example customizations
                config.PositionClass = Defaults.Classes.Position.TopCenter;
                config.PreventDuplicates = true;
                config.NewestOnTop = false;
                
                
            });

        }
                
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
