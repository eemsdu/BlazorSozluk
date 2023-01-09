using BlazorSozluk.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Infrastructure.Persistance.Extensions
{
    public static class Registration
    {
        //static bir fonksiyon barındıracak içerisine bir extension yazılacak 
        public static IServiceCollection AddInfrastructureRegistration(this IServiceCollection services,IConfiguration configuration)
        {
            //extencion metot yazacağımız icin static bir metot olmalıdır static olan metotun classınında static olma gibi bir zorunluluğu vardır. 
            services.AddDbContext<BlazorSozlukContext>(conf =>
            {
                //connection stringi alabilmemiz için config dosyasını okuyabilmek adına Iconfiguration alındır buradan okuma yapılacak 
                 // Bu şekilde connection string buradan inject edilmiş olundu 
                var connStr = configuration["BlazorSozlukDbConnectionString"].ToString();

                conf.UseSqlServer(connStr,opt =>
                {
                    opt.EnableRetryOnFailure(); //Sql servcra bağlanırken burada bir tane retry mekanizması devreye girsin diyoruz 
                });
            });
            return services;
        }
    }
}
