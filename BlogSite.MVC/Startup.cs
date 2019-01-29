using BlogSite.Application.Blogs.Commands;
using BlogSite.Application.Infrastructure;
using BlogSite.Common;
using BlogSite.Intrastructure;
using BlogSite.MVC.Areas.Identity.Data;
using BlogSite.MVC.Models;
using BlogSite.Persistance;
using FluentValidation.AspNetCore;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System.Reflection;

namespace BlogSite.MVC
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
            services.AddMiniProfiler().AddEntityFramework();

            services.Configure<CookiePolicyOptions>(options =>
            {                
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddTransient<IDateTime, MachineDateTime>();
            services.AddTransient<IDateTimeOffset, MachineDateTimeOffset>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddMediatR(typeof(CreateBlogCommand).GetTypeInfo().Assembly);
            
            services.AddDbContext<BlogSiteDBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("BlogSiteDBContext")));

            services.AddDbContext<BlogSiteUserContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("BlogSiteDBContext")));
            services.AddDefaultIdentity<BlogSiteUser>()
                .AddEntityFrameworkStores<BlogSiteUserContext>();

            services.AddAuthentication()
                .AddGoogle(googleOptions =>
                {
                    googleOptions.ClientId = "597745951925-0l96a67dinti2hche0ms3eapuc0t7pap.apps.googleusercontent.com";
                    googleOptions.ClientSecret = "For9L8Uz6EpqEVq8k_rRNYHF";                   
                });

            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddFluentValidation(fv => {
                    fv.RegisterValidatorsFromAssemblyContaining<CreateBlogCommandValidator>();
                    fv.ImplicitlyValidateChildProperties = true;
                    fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                });            
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseMiniProfiler();
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
