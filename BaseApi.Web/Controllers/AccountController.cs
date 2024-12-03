using BaseApi.Application.Dtos.Account;
using BaseApi.Application.Interfaces;
using BaseApi.Application.Services;
using BaseApi.Domain.Exceptions;
using BaseApi.Web.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BaseApi.Web.Controllers
{
    [Route("api/v1/account")]
    [ApiController]
    public class AccountController(IAccountService accountService) : ControllerBase
    {
        private readonly IAccountService _accountService = accountService;

        /// <summary>
        /// Create Account
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType<ResponseService<UserDto>>(StatusCodes.Status201Created)]
        [ProducesResponseType<ResponseService>(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ResponseService<UserDto>>> Create([FromBody] CreateAccountDto request)
        {
            try
            {
                var result = await _accountService.Create(request);
                return ActionResultService.SuccessResult(result, HttpStatusCode.Created);
            }
            catch (ApiException ex)
            {
                return ActionResultService.ErrorResult(ex);
            }
        }

        /// <summary>
        /// Authentication
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("auth")]
        [ProducesResponseType<ResponseService<AuthResponseDto>>(StatusCodes.Status200OK)]
        [ProducesResponseType<ResponseService>(StatusCodes.Status400BadRequest)]
        [ProducesResponseType<ResponseService>(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<ResponseService<AuthResponseDto>>> Auth([FromBody] AuthDto request)
        {
            try
            {
                var result = await _accountService.Authorization(request);
                return ActionResultService.SuccessResult(result);
            }
            catch (ApiException ex)
            {
                return ActionResultService.ErrorResult(ex);
            }
        }
    }
}
