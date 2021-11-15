using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using SGS.Repositories;
using SGS.Domain.Entities;
using SGS.Services.Interfaces;
using SGS.Services.Implementation;

namespace SGS.MVC
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
            services.AddMvc();
            services.AddControllersWithViews();
            services.AddDbContext<SGSDbContext>(options =>
      options.UseSqlServer(
      Configuration.GetConnectionString("MyConnection")));

         
            services.AddTransient<IFiscalYear, FiscalYearRepositort1>();
            services.AddTransient<IInvoiceHDR, InvoiceHDRRepositort>();


            // Add framework services.
            services
				.AddControllersWithViews()
				.SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
				// Maintain property names during serialization. See:
				// https://github.com/aspnet/Announcements/issues/194
				.AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
			// Add Kendo UI services to the services container
			services.AddKendo();

            services.AddCors(o =>
            {
                o.AddPolicy("_specificOrigin",
                    p => p.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    );
            });
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
           
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                
                    
                    //هان بحدد  اسم الصفحه يلي يبدا فيها
                    pattern: "{controller=InvoiceHDR}/{action=Index}/{id?}");
            });
        }
    }
}
