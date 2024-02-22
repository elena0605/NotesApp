namespace Notes.Domain.Models
{
    public class User : BaseEntity
    {
        public string  UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string Password { get; set; }

        public int Age { get; set; }

        // navigation properties - one user can have multiple notes

        public List<Note> Notes { get; set; }


    }
}
