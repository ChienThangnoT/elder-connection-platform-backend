using Application.IServices;
using Application.Services;
using Domain.Models;
using Infracstructures;
using Application.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ElderConnectionPlatform.API
{
    public static class DependencyInjection
    {
        public static void AddWebAPIService(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            services.AddControllers().AddNewtonsoftJson(o =>
            {
                o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            });

            services.AddEndpointsApiExplorer();

            //add cors
            services.AddCors(options =>
            {
                options.AddPolicy("app-cors",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .WithExposedHeaders("X-Pagination")
                        .AllowAnyMethod();
                    });
            });

            //config authen swagger
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Elder Connection Platform", Version = "v.10.24" });
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            // Add Authentication and JwtBearer
            services
                .AddAuthentication(options =>
                {
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
                        ValidAudience = builder.Configuration["JWT:ValidAudience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:SecretKey"]))
                    };
                });

            // Add Identity
            services
                .AddIdentity<Account, IdentityRole>()
                .AddEntityFrameworkStores<ElderConnectionContext>()
                .AddDefaultTokenProviders();

            //add dj mail service
            services.AddTransient<IMailService, MailService>();

            //Add config mail setting
            services.Configure<EmailConfig>(builder.Configuration.GetSection("MailSettings"));

            services.AddSingleton<IVnpayService, VnpayService>();

            //Add Email Confirm
            services.Configure<IdentityOptions>(
                opt => opt.SignIn.RequireConfirmedEmail = true
                );


        }
    }
}
