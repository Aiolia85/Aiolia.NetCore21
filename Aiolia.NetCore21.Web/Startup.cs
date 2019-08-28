using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aiolia.NetCore21.Repository.EFRepository;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Aiolia.NetCore21.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);



            //custom config
            var connection = @"Data Source=EFCore.db";
            services.AddDbContext<EFCoreContext>
                (options => options.UseSqlite(connection));


            //var log4netConfig = new System.Xml.XmlDocument();
            //log4netConfig.Load(File.OpenRead(@"log4net.config"));
            //var repo = LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));
            //XmlConfigurator.Configure(repo, log4netConfig["log4net"]);


            ContainerBuilder builder = new ContainerBuilder();
            builder.Populate(services);
            //builder.RegisterModule<DefaultModuleRegister>();

            builder.RegisterType<UnitOfWork>().PropertiesAutowired();


            var AutofacContainer = builder.Build();
            //使用容器创建 AutofacServiceProvider 
            return new AutofacServiceProvider(AutofacContainer);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
