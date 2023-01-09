using BlazorSozluk.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Infrastructure.Persistance.Context
{
    public class BlazorSozlukContext:DbContext
    {
        public const string DEFAULT_SCHEMA = "dbo";
        public BlazorSozlukContext()
        {
            //parametresiz bir ctor eklememiz gerekiyor 
        }

        public BlazorSozlukContext(DbContextOptions options) : base(options)
        {
            //Bu parametreyi de ddışarıdan alıp base entiyede gönderelim çünkü dbcontextin içinde parametre alan dbcontextoptions isminde bir ctor var onu buradan çağıralım bu ctora options gönderildiğinde oda kendi içinde kullanılmak üzere set etmiş olucak 
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<EntryVote> EntryVotes { get; set; }
        public DbSet<EntryFavorite> EntryFavorites { get; set; }
        public DbSet<EntryComment> EntryComments { get; set; }
        public DbSet<EntryCommentVote> EntryCommentVotes { get; set; }
        public DbSet<EntryCommentFavorite> EntryCommentFavorites { get; set; }
        public DbSet<EmailConfirmation> EmailConfirmations{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //entitymiz configure edilmemişse uygulama ayağa kaltığında configure edicez uygulama çalıştırılmıyor iken  migrate edilebilmesi burasına bakılmalacaktır...
                var connStr = "Data Source=BURAKELDUT\\SQLEXPRESS;Initial Catalog=blazorsozluk;Persist Security Info=True;User ID=sa;Password=1234";
                optionsBuilder.UseSqlServer(connStr, opt =>
                {
                    //bu işlem ne zman gerçekleşecek birisi blazorsozlukcontexti ctoru kullanarak oluşturduğu anda designtime bunu oluşturursa çağırırsa parametresiz ctoru çağırırak kullanırsa bu connectionstringi kullanarak opsiyon yaratacağım 
                    opt.EnableRetryOnFailure();
                });
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //extencion metot sayesinde tek tek tüm Ientityden türemiş class var ise otomatik oalrak kendisini  eklicek configuretionlar burada instance alınmış olunacak diğer türlü tek tek kendimiz eklememiz gerekecekti...
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override int SaveChanges()
        {
            //Savechanges çağırılmadan hemen önce burada bir işlem yapmak istiyorum burada createdDate otomatik oalrak set edilmesini sağlayacağım . 
            OnBeforeSave();
            return base.SaveChanges();
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            
            OnBeforeSave();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            OnBeforeSave();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnBeforeSave();
            return base.SaveChangesAsync(cancellationToken);
        }
        private void OnBeforeSave()
        {
            //Changetracker tüm entitylerimi yakalayacak ben onlar arasında filtreleme yapıcam  veri tabanına kayıt ekleme yapıldığında araya girmek istiyorum eklenmiş olan entity'nin baseentitysini bana getir diyorum 
            var addedEntites = ChangeTracker.Entries().Where(i => i.State == EntityState.Added).Select(i => (BaseEntity)i.Entity);
            PrepareAddedEntities(addedEntites); 
        }
        private void PrepareAddedEntities(IEnumerable<BaseEntity> entities)
        {
            //eklenmiş olan tüm entityleri bul onların arasında dön ;onların arasında dönerek created date now olarak işaretlenmiş oldu 
            foreach (var entity in entities) //baseentityler arasında dönelim istiyorum 
            {
                if (entity.CreatedDate==DateTime.MinValue) //set edilmeden önce createddate min value şeklindedir eğer bu minvalue ise yani createddate set edilmemişse onun otomatik olarak set edilmesi sağlandı 
                     entity.CreatedDate = DateTime.Now; 
            }
        }
    }
}
