using Domain.Base;

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
