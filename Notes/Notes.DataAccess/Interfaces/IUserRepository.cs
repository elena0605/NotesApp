using Notes.Domain.Models;

namespace Notes.DataAccess.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User? GetUserByUserName(string userName);
        User? LoginUser(string userName, string hashedPassword);
    }
}
