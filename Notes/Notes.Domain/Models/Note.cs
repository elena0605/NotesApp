using Notes.Domain.Enums;

namespace Notes.Domain.Models
{
    public class Note : BaseEntity
    {
        public string Text { get; set; }
        public Priority Priority { get; set; }

        public Tag Tag { get; set; }

        // navigation properties - one note record can point to one user
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
