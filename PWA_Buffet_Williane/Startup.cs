using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PWA_Buffet_Williane.Data;
using PWA_Buffet_Williane.Models.Acesso;
using PWA_Buffet_Williane.Models.Buffet.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PWA_Buffet_Williane.Models.Buffet.Convidado;
using PWA_Buffet_Williane.Models.Buffet.Evento;
using PWA_Buffet_Williane.Models.Buffet.Local;
using PWA_Buffet_Williane.Models.Buffet.TipoEvento;

namespace PWA_Buffet_Williane
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddControllersWithViews()
                .AddSessionStateTempDataProvider();
            services.AddRazorPages()
                .AddSessionStateTempDataProvider();

            services.AddHttpContextAccessor();
            
            services.AddSession();
            
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            
            services.AddControllersWithViews();

            services.AddDbContext<DatabaseContext>(options => 
                options.UseMySql(Configuration.GetConnectionString("BuffetDb"))
            );

            // Configurar o Controle de Acesso de Usu�rios
            services.AddIdentity<Usuario, Papel>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 8;
            }).AddEntityFrameworkStores<DatabaseContext>();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Acesso/Login";
            });

            services.AddTransient<AcessoService>();
            services.AddTransient<ClienteService>();
            services.AddTransient<ConvidadoService>();
            services.AddTransient<LocalService>();
            services.AddTransient<TipoEventoService>();
            services.AddTransient<EventoService>();

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
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseSession();
            
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Acesso}/{action=Login}/{id?}");
            });
        }
    }
}
