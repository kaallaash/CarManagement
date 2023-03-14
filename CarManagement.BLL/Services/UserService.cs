using CarManagement.BLL.Interfaces;
using CarManagement.DAL.Interfaces;
using CarManagement.Models;
using CarManagement.Models.Authentication;

namespace CarManagement.BLL.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(
        IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserModel> GetByLoginAsync(LoginModel loginModel)
    {
        return await _userRepository.GetByLoginAsync(loginModel);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _userRepository.DeleteAsync(id);
    }

    public async Task<int> RegisterAsync(RegisterModel registerModel)
    {
        return await _userRepository.RegisterAsync(registerModel);
    }

    public async Task<bool> UpdateAsync(RegisterModel registerModel)
    {
        return await _userRepository.UpdateAsync(registerModel);
    }
}