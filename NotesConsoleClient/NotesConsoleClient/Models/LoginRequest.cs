namespace NotesConsoleClient.Models
{
    public class LoginRequest
    {
        public string UserName { get; set; }    
        public string Password { get; set; }
        public LoginRequest(string username, string password)
        {
            UserName  = username;
            Password = password;
        }
    }
}
