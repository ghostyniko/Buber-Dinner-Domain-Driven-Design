using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistance;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.User;
using ErrorOr;

namespace BuberDinner.Application.Services.Queries;

public class AuthenticationQueryService : IAuthenticationQueryService
{

    private readonly IJwtTokenGenerator _jtwGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationQueryService(IJwtTokenGenerator jtwGenerator, IUserRepository userRepository)
    {
        _jtwGenerator = jtwGenerator;
        _userRepository = userRepository;
    }

    public ErrorOr<AuthenticationResult> Login(string email, string password)
    {
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        if (user.Password != password)
        {
            return Errors.Authentication.InvalidCredentials;
        }
        var token = _jtwGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}
