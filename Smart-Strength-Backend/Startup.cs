using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Smart_Strength_Backend.Services;
using Smart_Strength_Backend.Services.Interfaces;

namespace Smart_Strength_Backend
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
            services.AddSingleton<IFirebaseService, FirebaseService>();
            services.AddSingleton<ICommentsService, CommentsService>();
            services.AddSingleton<IDietsService, DietsService>();
            services.AddSingleton<IExcercisesService, ExcercisesService>();
            services.AddSingleton<IPostsService, PostsService>();
            services.AddSingleton<ITrainingsService, TrainingsService>();
            services.AddSingleton<IUsersService, UsersService>();
            services.AddTransient<IExcercisesRepo, ExcercisesRepo>();
            services.AddTransient<IWorkoutsService, WorkoutsService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
