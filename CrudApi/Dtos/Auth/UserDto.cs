namespace CrudApi.Dtos.Auth;

public class UserDto
{
    public string Id { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Username { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public List<string> Roles { get; set; } = new List<string>();
}
