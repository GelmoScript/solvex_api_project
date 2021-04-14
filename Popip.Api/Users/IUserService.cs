using System;
using Popip.Infrastructure.Dtos;

namespace Popip.Service.Users
{
    public interface IUserService
    {
        UserDto AuthenticateUser(UserDto loginCredentials);
        string GenerateJWTToken(UserDto userInfo);
    }
}
