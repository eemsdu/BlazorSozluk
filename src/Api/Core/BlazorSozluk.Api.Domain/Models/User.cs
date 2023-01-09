using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Api.Domain.Models
{
    public class User:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool EmailConfirmed  { get; set; } //mail ile kaydaoldu lakin bu mail doğrulanmalıdır
        //ilişkiler 
        public virtual ICollection<Entry> Entries { get; set;} //bir userın açmış olduğu tüm entrylere ulaşmak istersek burayı tanımlamamız gerekir 
        public virtual ICollection<EntryFavorite> EntryFavorites { get; set; }


        public virtual ICollection<EntryComment> EntryComments { get; set; }
    
        public virtual ICollection<EntryCommentFavorite> EntryCommentFavorites { get; set; }
        



    }
}
