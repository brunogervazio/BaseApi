using BaseApi.Application.Dtos.Account;
using BaseApi.Application.Interfaces;
using BaseApi.Domain.Exceptions;
using BaseApi.Domain.Interfaces.Factories;
using BaseApi.Domain.Interfaces.Repositories;
using BaseApi.Domain.Interfaces.Services;

namespace BaseApi.Application.Services
{
    public class AccountService(IAccountRepository accountRepository, IUserFactory userFactory, IPasswordEncryptService passwordEncryptService, TokenService tokenService) : IAccountService
    {
        private readonly IAccountRepository _accountRepository = accountRepository;
        private readonly IUserFactory _userFactory = userFactory;
        private readonly IPasswordEncryptService _passwordEncryptService = passwordEncryptService;
        private readonly TokenService _tokenService = tokenService;

        public async Task<ResponseService<AuthResponseDto>> Authorization(AuthDto request)
        {
            var result = await _accountRepository.SelectByEmail(request.Email);

            if (result is null || !_passwordEncryptService.PasswordVerify(result.Password.EncryptedValue, request.Password))
                throw new UnauthorizedException("Invalid email or password");

            var user = new UserDto()
            {
                Uuid = result.Uuid,
                Name = result.Name,
                Email = result.Email.Value,
            };

            return ResponseService<AuthResponseDto>.SeccessResponse(
                new AuthResponseDto() { Token = _tokenService.GerarToken(user) },
                "Authentication success");
        }

        public async Task<ResponseService<UserDto>> Create(CreateAccountDto request)
        {
            try
            {
                if (request.Password != request.ConfirmPassword)
                    throw new Exception("Passwords do not match");

                if (await ExistEmail(request.Email))
                    throw new Exception("Email already registered");

                var user = _userFactory.CreateUser(request.Name, request.Email, request.Password);
                await _accountRepository.Create(user);

                return ResponseService<UserDto>.SeccessResponse(
                    new UserDto()
                    {
                        Uuid = user.Uuid,
                        Name = user.Name,
                        Email = user.Email.Value
                    });
            }
            catch (Exception ex)
            {
                throw new ApiException(ex.Message);
            }
        }

        private async Task<bool> ExistEmail(string email)
        {
            var result = await _accountRepository.SelectByEmail(email);

            return result is not null;
        }
    }
}