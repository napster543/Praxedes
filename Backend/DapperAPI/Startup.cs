using DapperAPI.Model.Common;
using DapperAPI.Model.Data;
using DapperAPI.Repository;
using DapperAPI.Services;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperAPI
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
            services.AddSingleton<DapperDBContext>();
            services.AddSingleton<IClienteRepository, ClienteRepository>();

            services.AddSingleton<IUsuarioServices, UsuarioServices>();
            services.AddSingleton<IJsonplaceholderRepository, JsonplaceholderRepository>();
            services.AddSingleton<IGrupoFamiliarRepository, GrupoFamiliarRepository>();
            services.AddSingleton<ICommentsRepository, CommentsRepository>();
            services.AddSingleton<IPostRepository, PostRepository>();

            services.AddControllers();

            /* configura JWT */
            var appSettingSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingSection);

            // JWT Inicio
            var appSettings = appSettingSection.Get<AppSettings>();
            var llave = Encoding.ASCII.GetBytes(appSettings.Secreto);
            services.AddAuthentication(d =>
            {
                d.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                d.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(d =>
            {
                d.RequireHttpsMetadata = false;
                d.SaveToken = true;
                d.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(llave),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            // JWT Fin


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DapperAPI", Version = "v1" });
            });

            services.AddValidatorsFromAssemblyContaining<Program>(); // Fluentvalidator 1
            //services.AddFluentValidationAutoValidation(); // con esta linea se valida automaticamente apenas llega un a la clase X
            services.AddCors(options => {
                options.AddPolicy("NewPolitic", app => {
                    app.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DapperAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("NewPolitic");
            app.UseAuthentication(); // linea añadida token
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
