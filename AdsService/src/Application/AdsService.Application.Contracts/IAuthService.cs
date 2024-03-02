namespace AdsService.Application.Contracts;

public interface IAuthService
{
    Bool Signup(SignupRequestDto signupRequestDto);
    AuthenticatedUserDTO Authenticate(AuthenticateRequestDTO request);
}