using BlazorSozluk.Api.Domain.Models;
using BlazorSozluk.Common.Infrastructure;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Infrastructure.Persistance.Context
{
    internal class SeedData
    {
        //internal olarak bırakılabilir dışarıdan ihtiyacımız olmucak 
        //İlk olarak user oluşturmak ile başlıyorum bu userı birden fazla yerde kullanacağım için bunu metot haline getiriyorum 
        private static List<User> GetUsers()
        {

            var result = new Faker<User>("tr").RuleFor(i=>i.Id,i=>Guid.NewGuid()).RuleFor(i=>i.CreatedDate,i=>i.Date.Between(DateTime.Now.AddDays(-100),DateTime.Now)).RuleFor(i=>i.FirstName,i=>i.Person.FirstName).RuleFor(i=>i.LastName,i=>i.Person.LastName).RuleFor(i => i.EmailAddress, i => i.Internet.Email()).RuleFor(i=>i.UserName,i=>i.Internet.UserName()).RuleFor(i=>i.Password,i=>PasswordEncryptor.Encrpt(i.Internet.Password())).RuleFor(i=>i.EmailConfirmed,i=>i.PickRandom(true,false)).Generate(500);  
            //Rastgele 500 kayıt oluşturucaktır  EmailConfirmed true ya da false olabilir    
            //Burada bogus kullanılarak fake datalar oluşturma sağlandı aynı zamanda localication verebiliyorum string tipte diyorum ki türkçe dilini kullanarak bu dataları oluşturmasını söylüyorum 
            // RuleFor(i => i.Id, i => Guid.NewGuid() Bu user oluşturulurken id set etmek istiyorum ,d set ederken guidin newguid metodunu set edebilirsin diyorum
            // RuleFor(i => i.CreatedDate, i => i.Date.Between(DateTime.Now.AddDays(-100), DateTime.Now));:Createddate set edilirken between metodu kullanılır bu kullanılırken iki tarih aralıpı istiyor bu tarih aralığından rastegele tarih seçer DateTime.Now.AddDays(-100) ==>100 gün önceye gidiyoruz 
            return result;  

        }
        public async Task SeedAsync(IConfiguration configuration)
        {
            var dbContextBuilder = new DbContextOptionsBuilder(); //Bu benim için dbcontextoptions oluşturma işlemini gerçekleştiricek 
            dbContextBuilder.UseSqlServer(configuration["BlazorSozlukDbConnectionString"]);
            //dbcontextbuilder benden dbcontextoptionsbuilder ister 
            //dbcontextbuilderçoptions tamda bu istenilen dbcontextoptionsbuildera denk gelir...
            var context =new BlazorSozlukContext(dbContextBuilder.Options);
            var users=GetUsers();
            var userIds=users.Select(i=>i.Id);
            await context.Users.AddRangeAsync(users);
            //Gidecek user tablosuna benim için 500 tane insert atmak üzere işlemleri yapacak  ve son olarak işlemin bitmesi için savechanges çağırılmalıdır.Bundan sonra savechanges çağırıldığında user tablosu dolmuş olacaktı
            
     
        }
    }
}
