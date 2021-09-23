using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Globalization;

namespace TimeSheet.API
{
    using TimeSheet.API.Middlewares;
    using TimeSheet.Domain.TimeSheetContext.Repositories;
    using TimeSheet.Domain.TimeSheetContext.Services;
    using TimeSheet.Domain.TimeSheetContext.UnitOfWork;
    using TimeSheet.Infra.TimeSheetContext.DataContext;
    using TimeSheet.Infra.TimeSheetContext.DataContext.Mapper;
    using TimeSheet.Infra.TimeSheetContext.Repositories;
    using TimeSheet.Infra.TimeSheetContext.Services;
    using TimeSheet.Infra.TimeSheetContext.UoW;
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TimeSheet.API", Version = "v1" });
            });

            services.AddScoped<DbSession>();

            AddIoCRepositories(services);
            AddIoCServices(services);

            services.AddHttpContextAccessor();

            RegisterMapping.Register();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TimeSheet.API v1"));
            }

            var supportedCultures = new[] { new CultureInfo("pt-BR") };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(culture: "pt-BR", uiCulture: "pt-BR"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            app.UseHttpsRedirection();
            app.UseMiddleware(typeof(ExceptionHandlingMiddleware));
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        #region Métodos Auxiliares
        private void AddIoCRepositories(IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
        }
        private void AddIoCServices(IServiceCollection services)
        {
            services.AddTransient<ICEPService, CEPService>();
        }
        #endregion
    }
}
