using BaseApi.Application.Dtos.Account;
using BaseApi.Application.Services;

namespace BaseApi.Application.Interfaces
{
    public interface IAccountService
    {
        Task<ResponseService<UserDto>> Create(CreateAccountDto request);
        Task<ResponseService<AuthResponseDto>> Authorization(AuthDto request);
    }
}
