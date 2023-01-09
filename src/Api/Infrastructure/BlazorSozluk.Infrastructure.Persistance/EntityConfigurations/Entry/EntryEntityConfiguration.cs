using BlazorSozluk.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Infrastructure.Persistance.EntityConfigurations.Entry
{
    public class EntryEntityConfiguration : BaseEntityConfiguration<Api.Domain.Models.Entry>
    {
        public override void Configure(EntityTypeBuilder<Api.Domain.Models.Entry> builder)
        {
            base.Configure(builder);
            builder.ToTable("entry", BlazorSozlukContext.DEFAULT_SCHEMA);
            builder.HasOne(i => i.CreatedBy).WithMany(i => i.Entries).HasForeignKey(i => i.CreatedById).OnDelete(DeleteBehavior.Restrict);
            //Bir kullanıcının birden fazla entrysi olabilir o tanımlandı 
            //Herhangi bir silme işleminde createuserıon nasıl davranacağını bu silme işleminde kurduğumuz ilişkilerde nasıl davranacağını ifade eder .OnDelete(DeleteBehavior.Restrict);

        }
    }
}   
