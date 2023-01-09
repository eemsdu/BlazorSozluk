using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Api.Domain.Models;

public class Entry:BaseEntity
{
    public string Subject { get; set; } //Entry'nin başlık kısmı 
    public string Content { get; set; } //Entry'nin içeriğine ne girilmiş onu tutar
    public Guid CreatedById { get; set; } //Entry'i oluşturan kişi
    
    //İlişki kurulması :İlişkiler kurulurken virtual olarak tanımlamamız gerekir.Aksi takdirde hata alınır;virtual tanımlanır çünkü kullanılmayan zamanlarda da hata vermeden kullanılabilsin istiyoruz
    public virtual User CreatedBy { get; set; } 
    public virtual ICollection<EntryComment> EntryComments { get; set; }    
    public virtual ICollection<EntryVote> EntryVotes{ get; set; }    
    public virtual ICollection<EntryFavorite> EntryFavorites{ get; set; }    

}
