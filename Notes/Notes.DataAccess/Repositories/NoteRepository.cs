using Microsoft.EntityFrameworkCore;
using Notes.DataAccess.Interfaces;
using Notes.Domain.Models;

namespace Notes.DataAccess.Repositories
{
    public class NoteRepository : IRepository<Note>
    {
        private readonly NotesDbContext _notesDbContext;

        public NoteRepository(NotesDbContext notesDbContext)
        {
            _notesDbContext = notesDbContext;
        }
        public void Add(Note entity)
        {
            _notesDbContext.Notes.Add(entity);
            _notesDbContext.SaveChanges();  

        }

        public void Delete(Note entity)
        {
           _notesDbContext.Notes.Remove(entity);
            _notesDbContext.SaveChanges();
        }

        public List<Note> GetAll()
        {
            return _notesDbContext.Notes
                .Include(n => n.User)
                .ToList();
        }

        public Note? GetById(int id)
        {
            return _notesDbContext.Notes
                .Include(n => n.User)
                .SingleOrDefault(n => n.Id == id);
        }

        public void Update(Note entity)
        {
            _notesDbContext.Notes .Update(entity);
            _notesDbContext.SaveChanges();
        }
    }
}
