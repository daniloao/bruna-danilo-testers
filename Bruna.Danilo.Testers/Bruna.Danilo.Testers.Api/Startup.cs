using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bruna.Danilo.Testers.Api.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bruna.Danilo.Testers.Api
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
            services.AddMvc();
			services.AddCors(options => options.AddPolicy("Cors",
            builder =>
            {
                builder.
                AllowAnyOrigin().
                AllowAnyMethod().
                AllowAnyHeader();
            }));

			services.AddTransient<SignInManager<UserModel>, SignInManager<UserModel>>()
			        .AddTransient<UserManager<UserModel>, UserManager<UserModel>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

			app.UseCors("Cors");          
			app.UseMvc();
        }
    }
}
