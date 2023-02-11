using AuthSevice.Database.Entities;
using AuthSevice.Models;

namespace AuthSevice.Services.Interfaces
{
    public interface IAuthenticationService
    {
        bool CreateUser(User model, string Role);
        UserModel ValidateUser(LoginModel model);
        IEnumerable<UserModel> GetUsers();
    }
}
