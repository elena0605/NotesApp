using Microsoft.EntityFrameworkCore;
using Notes.DataAccess.Interfaces;
using Notes.Domain.Models;

namespace Notes.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly NotesDbContext _notesDbContext;

        public UserRepository(NotesDbContext notesDbContext)
        {
            _notesDbContext = notesDbContext;
        }
        public void Add(User entity)
        {
            _notesDbContext.Users.Add(entity);
            _notesDbContext.SaveChanges();
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User? GetById(int id)
        {
            return _notesDbContext.Users
                .Include(u => u.Notes)
                .SingleOrDefault(u => u.Id == id);
        }

        public User? GetUserByUserName(string userName)
        {
            return _notesDbContext.Users
                .SingleOrDefault(u => u.UserName == userName);
        }

        public User? LoginUser(string userName, string hashedPassword)
        {
            return _notesDbContext.Users
                .FirstOrDefault(u => u.UserName.ToLower() == userName.ToLower() && u.Password == hashedPassword);
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
