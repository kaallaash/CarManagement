using CarManagement.Models.Authentication;
using CarManagement.Models.User;

namespace CarManagement.BLL.Interfaces;

public interface IUserService
{
    Task<UserModel?> GetByLoginAsync(LoginModel loginModel);
    Task<UserModel?> GetByUsernameAsync(string username);
    Task<int> RegisterAsync(RegisterModel registerModel);
    Task<bool> UpdateAsync(int id, UserUpdateModel userUpdateModel);
    Task<bool> DeleteAsync(int id);
}