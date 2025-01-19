using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SGETPI.DAL.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGETPI.IOC
{
    public static class Dependencia
    {
        public static void InyectarDependencias(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SGETPI_PruebasContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("Conexion"));
            });
        }
    }
}
