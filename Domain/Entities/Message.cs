using Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Message:BaseEntity
    {
        public string SendUserId { get; set; }
        public string ReceiveUserId { get; set; }
        public string Text { get; set; }
        public bool IsLooked { get; set; }

        //[ForeignKey("SendUserId")]
        public virtual User SendUser { get; set; }
        //[ForeignKey("ReceiveUserId")]
        public virtual User ReceiveUser { get; set; }
    }
}
