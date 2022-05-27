using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BitadAPI.Repositories;
using hakaton_2022_backend.Entities;
using Microsoft.IdentityModel.Tokens;

namespace hakaton_2022_backend.Factories;

public class JwtTokenFactory : IJwtFactory
{
    private readonly IConfiguration _configuration;
    private readonly IEnterpriseRepository _enterpriseRepository;

    public JwtTokenFactory(IConfiguration configuration, IEnterpriseRepository enterpriseRepository)
    {
        _configuration = configuration;
        _enterpriseRepository = enterpriseRepository;
    }
    public string Generate(User user)
    {
        var keyBytes = Encoding.UTF8.GetBytes(_configuration["jwtSecret"]);
        var secret = new SymmetricSecurityKey(keyBytes);
        var credentials = new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        
        var claims = new List<Claim>
        {
            new Claim("Id", user.Id.ToString()),
            new Claim(ClaimTypes.Role, _enterpriseRepository.IsUserEnterpriseOwner(user.Id, user.Enterprise.Id) ? "Owner" : "User")
        };
        var token = new JwtSecurityToken(
            _configuration["jwtIssuer"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(120),
            signingCredentials: credentials
        );
        var jwtTokenHandler = new JwtSecurityTokenHandler();
        return jwtTokenHandler.WriteToken(token);
    }
}