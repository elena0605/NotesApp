using Notes.DTOs;

namespace Notes.Services.Abstraction
{
    public interface INoteService
    {
        List<NoteDto> GetAll(int userId);
        NoteDto GetById(int id);
        void AddNote(AddNoteDto addNoteDto);
        void UpdateNote(UpdateNoteDto updateNoteDto);
        void DeleteNote(int id);    


    }
}
