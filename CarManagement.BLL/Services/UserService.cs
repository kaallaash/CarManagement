﻿using CarManagement.BLL.Interfaces;
using CarManagement.DAL.Interfaces;
using CarManagement.Models.Authentication;
using CarManagement.Models.User;

namespace CarManagement.BLL.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(
        IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserModel?> GetByLoginAsync(LoginModel loginModel)
    {
        return await _userRepository.GetByLoginAsync(loginModel);
    }

    public async Task<UserModel?> GetByUsernameAsync(string username)
    {
        return await _userRepository.GetByUsernameAsync(username);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _userRepository.DeleteAsync(id);
    }

    public async Task<int> RegisterAsync(RegisterModel registerModel)
    {
        return await _userRepository.RegisterAsync(registerModel);
    }

    public async Task<bool> UpdateAsync(int id, UserUpdateModel userUpdateModel)
    {
        return await _userRepository.UpdateAsync(id, userUpdateModel);
    }
}