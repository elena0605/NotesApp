using Notes.DTOs;

namespace Notes.Services.Abstraction
{
    public interface IUserService
    {
        void RegisterUser(RegisterUserDto registerUserDto);
        string LoginUser(LoginUserDto loginUserDto);  

    }
}
