using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebExAPITool.Models.APICall;

namespace WebExAPITool
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            // Get the Server Variables 
            services.AddMvc().AddXmlSerializerFormatters();
            services.AddMvc(options =>
            {
                options.ReturnHttpNotAcceptable = true;
                options.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>();
                options.InputFormatters.Add(new XmlSerializerInputFormatter());
                options.OutputFormatters.Add(new XmlSerializerOutputFormatter());

                options.FormatterMappings.SetMediaTypeMappingForFormat(
                                             "xml", "application/xml");
            });

            services.AddDbContext<WebExAPITool.Models.DB.WebExDBContext>(options =>
          options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IWebAPICall, WebAPICall>();

            // set the variable for connectionstring 
            WebExAPITool.Models.Common.ConnectionString = Configuration.GetConnectionString("DefaultConnection");
            //services.AddSingleton<Models.ICompiledXML, Models.CompileXML>();
            services.AddScoped<WebExAPITool.Controllers.IAdminController, WebExAPITool.Controllers.WebExAdminController>();

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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
