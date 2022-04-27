using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app){

            using(var serviceScope = app.ApplicationServices.CreateScope()){
                SeedData(serviceScope.ServiceProvider.GetService<AppDBContext>());
            }
        }

        private static void SeedData(AppDBContext context){
            if(!context.Platforms.Any()){
                Console.WriteLine("Seeding data");
                context.Platforms.AddRange(
                    new Platform{ Id=1, Name="Dot net", Publisher="Microsoft", Cost="Free"},

                    new Platform{ Id=2, Name="Sql server Express", Publisher="Microsoft", Cost="Free"},
                    new Platform{ Id=3, Name="Kubernetes", Publisher="Cloud", Cost="Free"}
                );
                context.SaveChanges();
            }else{
                Console.WriteLine("We already have data");
            }
        }
    }
}