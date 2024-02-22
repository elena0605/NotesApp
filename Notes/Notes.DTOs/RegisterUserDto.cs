namespace Notes.DTOs
{
    public class RegisterUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public int Age { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
