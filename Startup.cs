using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VocabularyAppBackend.Constants;
using VocabularyAppBackend.Context;
using VocabularyAppBackend.IRepositories;
using VocabularyAppBackend.IServices;
using VocabularyAppBackend.Repositories;
using VocabularyAppBackend.Services;

namespace VocabularyAppBackend
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

      services.AddHttpContextAccessor();

      services.AddDbContext<VocabularyAppBackendContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));

      services.AddScoped<IModeRepository, ModeRepository>();
      services.AddScoped<IUserRepository, UserRepository>();

      services.AddScoped<IModeService, ModeService>();
      services.AddScoped<IUserService, UserService>();
      services.AddScoped<IAuthService, AuthService>();

      services.AddAuthentication(AuthenticationCookie.Name).AddCookie(AuthenticationCookie.Name, options =>
      {
        options.Cookie.Name = AuthenticationCookie.Name;
        options.ExpireTimeSpan = TimeSpan.FromMinutes(10); // This will make the cookie expire after a certain time.
      });

      services.AddAuthorization(options => { });

      services.AddSwaggerGen(c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "VocabularyAppBackend", Version = "v1" }));
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VocabularyAppBackend v1"));
      }

      app.UseHttpsRedirection();

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
