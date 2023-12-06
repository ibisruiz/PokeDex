using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PokeDex.Core.Application.Interfaces.Services;
using PokeDex.Core.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeDex.Core.Application
{

    //Extension Method - Decorator
    public static class ServiceRegistration
    {
        public static void AddAplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            #region Services
            services.AddScoped<IPokemonService, PokemonService>();
            services.AddScoped<IRegionService, RegionService>();
            services.AddScoped<ITipoService, TipoService>(); 
            #endregion
        }
    }
}
