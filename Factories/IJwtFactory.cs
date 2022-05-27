using hakaton_2022_backend.Entities;

namespace hakaton_2022_backend.Factories;

public interface IJwtFactory
{
    Task<string> Generate(User user);
}