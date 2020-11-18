using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using TutoFinder.Entity.Identity;
using TutoFinder.Persistence;
using TutoFinder.Service;
using TutoFinder.Service.Impl;

namespace TutoFinder
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
            services.AddControllers();

            //services.AddDbContext<ApplicationDbContext>
              //  (opts => opts.UseSqlServer(Configuration.GetConnectionString
                //("DefaultConnection")));

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<IdentityOptions>(options =>
            {
                //Default Password settings
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
            });
                

            services.AddAutoMapper(typeof(Startup));

            services.AddTransient<AlumnoService, AlumnoServiceImpl>();
            services.AddTransient<CursoService, CursoServiceImpl>();
            services.AddTransient<DocenteService, DocenteServiceImpl>();
            services.AddTransient<InformeService, InformeServiceImpl>();
            services.AddTransient<PadreService, PadreServiceImpl>();
            services.AddTransient<PagoService, PagoServiceImpl>();
            services.AddTransient<TarjetaService, TarjetaServiceImpl>();
            services.AddTransient<TutoriaService, TutoriaServiceImpl>();
            services.AddTransient<MembresiaService, MembresiaServiceImpl>();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin", builder =>
                    builder.AllowAnyHeader()
                           .AllowAnyMethod()
                           .AllowAnyOrigin()
                );
            });
            //Configuracion de que la autentitacion es a traves de un token tipo Bearer
            //Leemos el secretkey
            //var key = Encoding.ASCII.GetBytes(
              //Configuration.GetValue<string>("SecretKey"));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            var key = Encoding.ASCII.GetBytes(
              Configuration.GetValue<string>("SecretKey")
            );

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                //Se configura el token para indicar como sera leido
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false; //Queremos validar si las peticiones validar si vienen de https en produccion pueden colocar si viene desde un SSL
                x.SaveToken = true; //No vamos almacenar el token
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),//este debe contener la información del secret key
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowSpecificOrigin");

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
