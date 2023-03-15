using AutoMapper;
using CarManagement.Models.User;

namespace CarManagement.API.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserModel, UserUpdateModel>().ReverseMap();
    }
}