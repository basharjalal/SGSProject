using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using SGS.Repositories;
using SGS.Repositories.Implementation;
using SGS.Repositories.Interfaces;
using SGS.Services.Implementation;
using SGS.Services.Interfaces;
using SGS.Services.Mapping;

namespace SGSProject
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
            services.AddCors(o =>
            {
                o.AddPolicy("_specificOrigin",
                    p => p.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    );
            });
            services.AddControllersWithViews();
            services.AddDbContext<SGSDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("ConnStr")));
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });
            services.AddAutoMapper(typeof(MappingProfileBase));

            services.AddScoped(typeof(IInvoiceHDRService), typeof(InvoiceHDRService));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IInvoiceHDRRepository), typeof(InvoiceHDRRepository));
            services.AddScoped(typeof(IItemDTLRepository), typeof(ItemDTLRepository));
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseStaticFiles();


            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
