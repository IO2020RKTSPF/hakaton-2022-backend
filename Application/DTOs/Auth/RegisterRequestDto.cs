namespace hakaton_2022_backend.Application.DTOs.Auth;

public class RegisterDto
{
    public string OrganizationName { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}