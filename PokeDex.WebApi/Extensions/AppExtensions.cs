using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Security.Cryptography;

namespace PokeDex.WebApi.Extensions
{
    public static class AppExtensions
    {
        public static void UseSwaggerExtension(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "PokeDex API");
            });
        }
    }
}
