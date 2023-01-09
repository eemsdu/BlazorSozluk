using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Api.Domain.Models
{
    public class EmailConfirmation:BaseEntity
    {
        //Kullanıcı İlk defa oluşturulduğunda veya oluşturulmuş bir kullancının hali hazırda değiştirildiğinde kullanılacak yapı
         //eski email neydi yeni email ne oldu bu bilgiler tutulacak 
        public string OldEmailAddress { get; set; } 
        public string NewEmailAddress { get; set; }
    }
}
