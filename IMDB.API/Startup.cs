using FluentValidation;
using FluentValidation.AspNetCore;
using Hangfire;
using Hangfire.SqlServer;
using IMDB.API.Controllers;
using IMDB.DAL.Interface;
using IMDB.DAL.Repositories;
using IMDB.Models.RequestModels;
using IMDB.Service;
using IMDB.Service.Interface;
using IMDB.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Linq;

namespace IMDB.API
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
            services.AddControllers().AddFluentValidation();
            services.AddTransient<IValidator<SearchMovieModel>, SearchMovieModelValidator>();
            services.AddTransient<IValidator<WatchListRequest>, WatchListRequestValidator>();
            services.AddSingleton<IIMDBService, IMDBService>();
            services.AddSingleton<IExternalServiceCaller, ExternalServiceCaller>();
            services.AddSingleton<IWatchListRepository, WatchListRepository>();
            services.AddSingleton<IWatchList, WatchListService>();
            services.AddSingleton<INotificationsRepository, NotificationsRepository>();
            services.AddSingleton<IJobSchedulerService, JobSchedulerService>();
            services.AddSingleton<IEmailService, EmailService>();
            //services.AddHangfire(config =>
            //{
                //config.UseSqlServerStorage(@"Data Source = 62.171.168.156; Initial Catalog = IMDBDB; Persist Security Info = True; User ID = pabuser; Password = u6JVj6lAU9nLJh1FaDpr");
                services.AddHangfire(x => x.UseSqlServerStorage(@"Data Source = 62.171.168.156; Initial Catalog = IMDBDB; Persist Security Info = True; User ID = pabuser; Password = u6JVj6lAU9nLJh1FaDpr"));

           // });
            services.AddHangfireServer();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "IMDB.API", Version = "v1" });
                c.SchemaFilter<EnumSchemaFilter>();
            });

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //JobStorage.Current = new SqlServerStorage(@"Data Source = 62.171.168.156; Initial Catalog = IMDBDB; Persist Security Info = True; User ID = pabuser; Password = u6JVj6lAU9nLJh1FaDpr");
            //ScheduleController schedule = new ScheduleController();
            
            //RecurringJob.AddOrUpdate("weekly", () => jobSchedulerService.SendNotification(), Cron.Weekly(DayOfWeek.Saturday, 16, 53), TimeZoneInfo.FindSystemTimeZoneById("Georgian Standard Time"));
            //app.UseHangfireDashboard();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "IMDB.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
           // app.UseHangfireDashboard();

        }
        private class EnumSchemaFilter : ISchemaFilter
        {
            public void Apply(OpenApiSchema schema, SchemaFilterContext context)
            {
                if (context.Type.IsEnum)
                {
                    int i = 0;
                    schema.Enum.Clear();
                    schema.Type = "string";
                    foreach (var n in Enum.GetNames(context.Type).ToList())
                    {
                        schema.Enum.Add(new OpenApiString(n));
                        i++;
                    }
                }
            }
        }
    }
}
