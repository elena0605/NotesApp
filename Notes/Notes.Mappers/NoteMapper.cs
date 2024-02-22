using Notes.Domain.Models;
using Notes.DTOs;

namespace Notes.Mappers
{
    public static class NoteMapper
    {
        public static Note ToNote(this AddNoteDto addNoteDto)
        {
            return new Note 
            { 
                Text = addNoteDto.Text,
                Tag = addNoteDto.Tag,
                Priority = addNoteDto.Priority,
                UserId = addNoteDto.UserId, 
            };

        }

        public static NoteDto ToNoteDto(this Note note)
        {
           var noteDto =  new NoteDto 
            { 
                Text = note.Text,
                Tag = note.Tag,
                Priority = note.Priority,

            };

            if(note.User is not null )
            {
                noteDto.UserFullName = $"{note.User.FirstName} {note.User.LastName}";
            }
            return noteDto;
        }


    }
}
