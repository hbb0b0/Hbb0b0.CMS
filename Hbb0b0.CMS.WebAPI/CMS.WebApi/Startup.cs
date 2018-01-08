using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Common;
using CMS.Common.Config;
using CMS.Common.DB;
using CMS.IRepository;
using CMS.IService;
using CMS.Repository;
using CMS.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CMS.WebApi
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
            services.AddMvc()
            //序列化设置
            .AddJsonOptions(options =>
             {
                 //忽略循环引用
                 options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                 //不使用驼峰样式的key
                 //options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                 //设置时间格式
                 options.SerializerSettings.DateFormatString = "yyyy-MM-dd hh-MM-ss";
             }
        );

            services.AddOptions();

            services.Configure<WebApiOption>(Configuration.GetSection("WebAPI"));
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            //获取配置
            WebApiOption config = serviceProvider.GetService<IOptions<WebApiOption>>().Value;

            AddCorsService(services,config);
            AddDBService(services,config);
        

        }

        private void AddDBService(IServiceCollection services,WebApiOption config)
        {
           
            //设置全局配置
            services.AddSingleton<IDapperContext>(_ => new DapperContext(
               config
               ));

            services.AddScoped<IDepartmentRep, DepartmentRep>();
            services.AddScoped<IDepartmentService, DepartmentService>();

            services.AddScoped<IEmployeeRep, EmployeeRep>();
            services.AddScoped<IEmployeeService, EmployeeService>();


        }

        private void AddCorsService(IServiceCollection services, WebApiOption config)
        {
          
            //添加cors 服务
            services.AddCors(options =>
                                     options.AddPolicy(WebApiOption.CORS_POLICY_NAME, p => p.WithOrigins(config.Cors.Original)
             .AllowAnyMethod().AllowAnyHeader()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();


            app.UseMvc(routes =>
            {

                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Home", action = "Index" });
            });
           
            //配置Cors
            app.UseCors(WebApiOption.CORS_POLICY_NAME);


        }
    }
}
