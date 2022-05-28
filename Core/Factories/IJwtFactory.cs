using hakaton_2022_backend.Core.Entities;

namespace hakaton_2022_backend.Core.Factories;

public interface IJwtFactory
{
    Task<string> Generate(User user);
}