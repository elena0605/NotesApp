namespace Notes.CustomExceptions
{
    public class NoteDataException : Exception
    {
        public NoteDataException() : base("Generic note data exception occured") { }
        

        public NoteDataException(string message) : base(message){ }
       
    }
}
