namespace TaskManager.Api
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using TaskManager.Data;
    using TaskManager.Data.Entities;
    using TaskManager.Data.Repositories;
    using TaskManager.Services;
    using TaskManager.Services.Impl;

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
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddTransient<ITaskService, TaskService>();
            services.AddTransient<ITaskRepository, TaskRepository>();

            var connection = @"Server=(localdb)\mssqllocaldb;Database=Task;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<TaskContext>
                (options => options.UseSqlServer(connection, b => b.MigrationsAssembly("TaskManager.Api")));
            services.AddDbContext<TaskContext>(options => options.UseInMemoryDatabase(connection));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
