using AutoMapper;
using CarManagement.BLL.Interfaces;
using CarManagement.Models.Authentication;
using CarManagement.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<int> Create(
        [FromBody] RegisterModel registerModel)
    {
        return await _userService.RegisterAsync(registerModel);
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<bool> Update(
        int id,
        [FromBody] UserUpdateModel userUpdateModel)
    {
        return await _userService.UpdateAsync(id, userUpdateModel);
    }

    [Authorize]
    [HttpDelete("{id}")]
    public Task Delete(int id)
    {
        return _userService.DeleteAsync(id);
    }
}