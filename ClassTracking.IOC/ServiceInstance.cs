using ClassTracking.Domain.DbContexts;
using ClassTracking.Repository.UnitOfWork;
using ClassTracking.Service.Implementation;
using ClassTracking.Service.Implementation.ClassTracking;
using ClassTracking.Service.Interface;
using ClassTracking.Service.Interface.ClassTracking;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClassTracking.IOC
{
    public static class ServiceInstance
    {
        public static void RegisterServiceInstance(this IServiceCollection services,
           IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
          
            services.AddDbContext<ClassTrackingDbContext>(options =>
            options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Api")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<ClassTrackingDbContext, ClassTrackingDbContext>();
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));

            services.AddTransient<IStudentService, StudentService>();
        }
    }
}
