using BlazorSozluk.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Api.Domain.Models
{
    public class EntryCommentVote:BaseEntity
    {
        public Guid EntryCommentId { get; set; } //Kullanılacak oy hangi entrye ait 
        public VoteType VoteType { get; set; }  //Kullanılan oyun türü 
        public Guid CreatedById { get; set; } //kullanılan oy hangi  kullanıcıya ait bilgisi tutulur 
                                              //ilişkiler
        public virtual EntryComment EntryComment { get; set; }
    }
}
