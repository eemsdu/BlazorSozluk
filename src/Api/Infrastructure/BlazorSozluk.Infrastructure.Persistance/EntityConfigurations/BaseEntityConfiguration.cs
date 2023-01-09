using BlazorSozluk.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Infrastructure.Persistance.EntityConfigurations
{
    public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        //exencion metotlarda efcore tarafından bu tüm entityler tarandığından bahsetmiştik bu taramada ise bir classın IEntityTypeConfiguration interfaceden türeyip türemediğine bakar  ona göre ekler  
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(i=>i.Id).ValueGeneratedOnAdd(); 
            //Ben daha veriyi add metodu ile çağırır çağırmaz savechanges demeden id işlemi generate edilsin 
            builder.Property(i=>i.CreatedDate).ValueGeneratedOnAdd();
            //Addmetodu çağırılır çağırılmaz  created date generate edilsin 
            //Base class sayesinde bu işlemler tüm entyilerde tek tek yapılmamış olundu 
        }
    }
}
