namespace Shop.Shared.Users;

public sealed class UserDto
{
    public int Id { get; set; }

    public int Role { get; set; }

    public string Token { get; set; }
}