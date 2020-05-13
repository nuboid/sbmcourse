using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MyResearch.Auth.JWTToken.ConsumingAPI.FW;
using System.Text;

namespace MyResearch.Auth.JWTToken.ConsumingAPI
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
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });


            var keyAsString = @"@h9y+Xuk(w]+sjaprqw9v8R*'RK343wVPr}{dEuA[9HxqDq ? Fx < f_] zpP_`E ~@7.Lk+zCL'gKWzKw;5:2xb~8x\Akp#*4mcM}6&8.`&B+4Eg[r!n2`_`9/EHbqmLE";
            //var keyAsString = @"Euh, I do not have the key";
            var keyAsBytes = Encoding.UTF8.GetBytes(keyAsString);
            var fromIssuer = "MeAsGenerator";
            var forAudience = "OtherPartyAsAudience";

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = fromIssuer,
                    ValidAudience = forAudience,
                    
                    IssuerSigningKey = new SymmetricSecurityKey(keyAsBytes)
                };
              
            });

#if DEBUG
            //services.AddTransient<IAuthorizationHandler, DisableAuthorizationHandler<IAuthorizationRequirement>>();
#endif
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
