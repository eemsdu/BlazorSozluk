using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSozluk.Common.ViewModels
{
    public enum  VoteType
    {
        None=-1, //hiç oy yok ise -1 
        // Oy kullanılmış ise downvote ya da upvote olarak tutulacak 
        DownVote=0,
        UpVote=1
    }
}
