using NotesConsoleClient.Enums;

namespace NotesConsoleClient.Models
{
    public class NoteResponse
    {
        public string Text { get; set; }
        public Priority Priority { get; set; }
        public string UserFullName { get; set; }    
        public Tag Tag { get; set; }

        public override string ToString()
        {
           return $"\n*Note Text: {Text}. *Priority: {Priority}. *Tag: {Tag}. *User: {UserFullName}";
        }
    }
}
