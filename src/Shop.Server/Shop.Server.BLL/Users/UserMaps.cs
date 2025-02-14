using AutoMapper;
using Shop.Server.DAL.Users;
using Shop.Shared.Users;

namespace Shop.Server.BLL.Users;

public sealed class UserMaps : Profile
{
    public UserMaps()
    {
        CreateMap<User, UserDto>();
    }
};