using A1PL3Y_HFT2023241.Logic.Interfaces;
using A1PL3Y_HFT2023241.Logic;
using A1PL3Y_HFT2023241.Models;
using A1PL3Y_HFT2023241.Repository.ModelReps;
using A1PL3Y_HFT2023241.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Diagnostics;

namespace A1PL3Y_HFT2023241.Endpoint
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ProjectDbContext>();

            services.AddTransient<IRepository<CourseModel>, CourseRepository>();
            services.AddTransient<IRepository<EnrollmentModel>, EnrollmentRepository>();
            services.AddTransient<IRepository<StudentModel>, StudentRepository>();

            services.AddTransient<ICourseLogic, CourseLogic>();
            services.AddTransient<IEnrollmentLogic, EnrollmentLogic>();
            services.AddTransient<IStudentLogic, StudentLogic>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "A1PL3Y_HFT2023241.Endpoint", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "A1PL3Y_HFT2023241.Endpoint1 v1"));
            }

            app.UseExceptionHandler(c => c.Run(async context =>
            {
                var expection = context.Features
                     .Get<IExceptionHandlerFeature>()
                     .Error;
                var response = new { Msg = expection.Message };
                await context.Response.WriteAsJsonAsync(response);
            }));


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
