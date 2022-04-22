using Domain.Base;

namespace Domain.Entities
{
    public class Car: BaseEntity
    {
        public string Aciklama { get; set; }
        public string Plaka { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
