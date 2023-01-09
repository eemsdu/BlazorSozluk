using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Api.Domain.Models
{
    public class EntryCommentFavorite:BaseEntity
    {
        public Guid EntryCommentId { get; set; } //bu favori hangi entryecommente ait olduğu bilgisi
        public Guid CreatedById { get; set; } //hangi kullanıcı favarilerine ekledi 

        //ilişkiler
        public virtual EntryComment EntryComment { get; set; }
        public virtual User CreatedUser { get; set; }
    }
}
