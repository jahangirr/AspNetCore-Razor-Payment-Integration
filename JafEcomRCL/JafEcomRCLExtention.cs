using JafEcomRCL.DAL;
using JafEcomRCL.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JafEcomRCL
{
    public static class JafEcomRCLExtention
    {
        public static IServiceCollection AddServiceFromJafEcomRCL(this IServiceCollection services)
        {
            services.AddDbContext<JafEcomRCLDbContext>();
            services.AddScoped<ItemService>();
            return services;
        }
    }
}
