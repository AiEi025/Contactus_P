using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contactus_P.MiddleWare;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Contactus_P
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
            services.AddControllersWithViews();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseTest();
            //app.Map("/home", Test);
            //app.MapWhen(context=> context.Request.Path.ToString().ToLower() =="/home/index" , MapWhereMethod);
            //app.MapWhen(context => context.Request.Query.ContainsKey("test"), MapWhereMethod);



            //app.Use(async (context, next) =>

            //{
            //    //logic
            //    var url = context.Request.Path.ToString();
            //    if (url.ToLower() == "/home/index")
            //    {
            //        //context.Response.Headers.Add("customheader", "mohammad");
            //        //await context.Response.WriteAsync("awd  wad   wfe   wfe     wsfda");//با نوشتن این خط به اخرین میدل ویر تبدیل میشود

            //        context.Items.Add("Test", "firstUse");
            //    }

            //    await next();
            //    //Morelogic : نباید در این مقدار ریسپانس را تعیییر بدهیم
            //});

            //app.Run(async (context) =>
            //{
            //    var item = context.Items["Test"]?.ToString();
            //    await context.Response.WriteAsync($"<h1>Callout {item}</h1>");
            //});


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            //map : بر اساس شرط اگر درست بود یکسری میدل ویر اجرا میشود که این شرط بر اساس روت انجام میشود
            //MAPWHEN : قابلیت ان نیز بیشتر میباشد
            //use : 
            //run :بعد از این میدل ویر دیگری صدا زده نمیشود



        }
        public static void MapWhereMethod(IApplicationBuilder app) 
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Map Run");
            });
        }
        public static void Test(IApplicationBuilder app) 
        {
            app.Map("/index", config2 =>
            {
                config2.Run(async context =>
                {
                    await context.Response.WriteAsync("fswefswef");
                });
            });

            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("Test", "Hello");
                await next();
            });
            app.Run(async (context) =>
            {
                var text = context.Response.Headers["Test"].ToString();
                if (text == "Hello")
                {
                    await context.Response.WriteAsync(text);
                }
                else
                {
                    context.Response.Redirect("https://fonts.google.com/");
                }
            });
        }
    }
}
