using CarManagement.Models.Authentication;
using CarManagement.Models.User;

namespace CarManagement.DAL.Interfaces;

public interface IUserRepository
{
    Task<UserModel> GetByLoginAsync(LoginModel loginModel);
    Task<int> RegisterAsync(RegisterModel registerModel);
    Task<bool> UpdateAsync(RegisterModel registerModel);
    Task<bool> DeleteAsync(int id);
}
