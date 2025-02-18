using System.Net.Http.Json;
using Shop.Shared.Users;

namespace Shop.Client.Admin.Services.UserServices;

public sealed class UserService(HttpClient http) : IUserService
{
    public async Task<string> LoginJwtAsync(UserLoginDto dto)
    {
        var result = await http.PostAsJsonAsync("api/user/login", dto);

        if (!result.IsSuccessStatusCode)
            throw new Exception("No token received");

        return await result.Content.ReadAsStringAsync();
    }
}