using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bruna.Danilo.Testers.Api.Entities;
using Bruna.Danilo.Testers.Api.Infraestructure;
using Bruna.Danilo.Testers.Logs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

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
			services.AddCors(options => options.AddPolicy("Cors",
            builder =>
            {
                builder.
                AllowAnyOrigin().
                AllowAnyMethod().
                AllowAnyHeader();
            }));

			services.AddDbContext<LogsContext>(options => options.UseSqlServer(AppSettings.DefaultConnectionString, b => b.MigrationsAssembly("Bruna.Danilo.Testers.Api")));
			services.AddDbContext<ApplicationDbContext>();
			services.AddTransient<Logger>();
			services.AddTransient<LogsContext>();

			// ===== Add Identity ========
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

			// ===== Add Jwt Authentication ========
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear(); // => remove default claims
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

                })
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = AppSettings.JwtIssuer,
					ValidAudience = AppSettings.JwtIssuer,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppSettings.JwtKey)),
                        ClockSkew = TimeSpan.Zero // remove delay of token when expire
                    };
                });

			services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, 
		                      IHostingEnvironment env,
                              ApplicationDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

			app.UseCors("Cors");          
			app.UseMvc();

			// ===== Create tables ======
            dbContext.Database.EnsureCreated();
        }
    }
}
