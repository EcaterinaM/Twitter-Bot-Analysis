using Autofac;
using Infrastructure.Autofac;
using Infrastructure.Automapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using Tweetinvi;
using Tweetinvi.Models;
using Autofac.Extensions.DependencyInjection;
using DataPersistance.Context;
using Microsoft.EntityFrameworkCore;

namespace TweetApp.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddDbContext<DatabaseContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("AppConnection")));

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAnyOrigin",
                    b => b
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            ITwitterCredentials creds = new TwitterCredentials(Configuration["TwitterConnection:ConsumerKey"], Configuration["TwitterConnection:ConsumerSecretKey"],
                Configuration["TwitterConnection:AccesToken"], Configuration["TwitterConnection:AccesTokenSecret"]);
            Auth.SetCredentials(creds);

            TweetinviConfig.CurrentThreadSettings.TweetMode = TweetMode.Extended;
            TweetinviConfig.ApplicationSettings.TweetMode = TweetMode.Extended;

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "TweetApp.Api", Version = "v1" });
            });


            var builder = new ContainerBuilder();
            services.AddSingleton(new AutomapperConfig(builder));
            builder.RegisterModule<AutofacModule>();
            builder.Populate(services);
            var container = builder.Build();

            return container.Resolve<IServiceProvider>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAnyOrigin");

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Too V1");
            });


            app.UseMvc();
        }
    }
}
