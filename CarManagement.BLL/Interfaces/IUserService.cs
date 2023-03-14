﻿using CarManagement.Models.Authentication;
using CarManagement.Models;

namespace CarManagement.BLL.Interfaces;

public interface IUserService
{
    Task<UserModel> GetByLoginAsync(LoginModel loginModel);
    Task<int> RegisterAsync(RegisterModel registerModel);
    Task<bool> UpdateAsync(RegisterModel registerModel);
    Task<bool> DeleteAsync(int id);
}