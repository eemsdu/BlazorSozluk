using BlazorSozluk.Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Api.Domain.Models;

public class EntryVote: BaseEntity    //Kullanıcnın yukarı ya da aşağı yönlü yön kullanılması 
{
    public Guid EntryId { get; set; } //Kullanılacak oy hangi entrye ait 
    public VoteType VoteType { get; set; }  //Kullanılan oyun türü 
    public Guid CreatedById { get; set; } //kullanılan oy hangi  kullanıcıya ait bilgisi tutulur 
    //ilişkiler
    public virtual Entry Entry{ get; set; }

}
