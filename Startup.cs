using Microsoft.AspNetCore.Builder;
using probnik.Data.Mocks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using probnik.Data.Interfaces;
using IHostingEnvironment = Microsoft.Extensions.Hosting.IHostingEnvironment;
using Microsoft.Extensions.Configuration;
using probnik.Data;
using Microsoft.EntityFrameworkCore;
using probnik.Data.Repository;
using Microsoft.AspNetCore.Http;
using probnik.Data.Models;

namespace probnik
{
    public class Startup
    {
        private Microsoft.Extensions.Configuration.IConfigurationRoot ConfString;

        public Startup(IWebHostEnvironment HostEnv)
        {
            ConfString = new ConfigurationBuilder().SetBasePath(HostEnv.ContentRootPath).AddJsonFile("DBSettings.json").Build(); // ���������� �������� ���� ������
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) // ����������� ������������ � ������� �������� (�������, ����, �����!!!!)
        {
            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(ConfString.GetConnectionString("DefaultConnection"))); // ����������� SQL �������
            services.AddTransient<IAllCars, CarsRepository>(); // �������� ����� ����� ����������� � ������������ ��� ����, ��� �� � ��� ������������� ������� ����� ���� ���������� ����� ��������� 
            services.AddTransient<ICarsCategory, CategoryRepository>();
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShopCart.GetCart(sp));           
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // ����������� ������ ����� � ������� (������� ����� ���� �����!!!!)
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvcWithDefaultRoute();
            
            AppDBContent Content; // ������� ������������ ���� ������
            using (var Scope = app.ApplicationServices.CreateScope())
            {
                Content = Scope.ServiceProvider.GetRequiredService<AppDBContent>();
                DBObjects.Initial(Content);
            }
            
        }
    }
}
