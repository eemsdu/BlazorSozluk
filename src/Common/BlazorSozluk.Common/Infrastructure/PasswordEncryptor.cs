using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Common.Infrastructure
{
    public class PasswordEncryptor //seed data üretilirkenb password bilgisinde oluşturulan bu metot kullanılacak 
    {
        public static string Encrpt(string password)
        {
            //Geriye string dönecek static bir metot oluşturuyorum 
            using var md5=MD5.Create(); //Md5 algoritması geri dönülemeyecek bir şifreleme algoritması sunar 
            byte[] inputBytes=Encoding.ASCII.GetBytes(password);
            
            //Dışarıdan gönderilen bir passwordün byte arraye dönüştürülmesi sağlandı  ascıı encodingi kullanılarak 
            byte[] hashBytes=md5.ComputeHash(inputBytes); 
            //Dışarıdan byte arraye dönüştürülen password bilgisi md4 kullanılarak hashlenir 
             return Convert.ToHexString(hashBytes);
            //MD5 algoritması kullanılarak  yine bytearraye çevirir ama bu sefer şifrelenmiş  olarak geriye yalnızca bu şifrelenmiş datayı string olarak döndürmek kalıyor  
             //Rastgele bir şifre göndermiştim tohexstring metodu ile de haşhlenmiş olan bu yapı stringe çevrilir ve şifrelenmiş string tipde bir yapı ile geriye döndürülmüş olur 

        }
    }
}
