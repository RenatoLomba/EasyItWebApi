using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Domain.DTOs.UserDTOs;
using Domain.Interfaces.AppServicesInterfaces;
using Domain.Validators.UsersValidators;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("API/[controller]/[action]")]
    [ApiController]
    public class SignController : ControllerBase
    {
        private readonly ISignService _signService;
        public SignController(ISignService signService)
        {
            _signService = signService;
        }

        #region SIGN IN
        [AllowAnonymous]
        [HttpPost]
        public async Task<object> SignIn(UserDTOLogin login)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            UserLoginValidator validator = new UserLoginValidator();
            ValidationResult valResult = await validator.ValidateAsync(login);
            if(!valResult.IsValid)
                return BadRequest(valResult.ToString(" "));

            try
            {
                var result = await _signService.SignInService(login);

                if (result != null)
                    return Ok(result);
                else
                    return NotFound("Usuário não encontrado");
            } catch(ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        #endregion

        #region SIGN UP
        [AllowAnonymous]
        [HttpPost]
        public async Task<object> SignUp(UserDTOCreate user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            UserCreateValidator validator = new UserCreateValidator();
            ValidationResult valResult = validator.Validate(user);
            if (!valResult.IsValid)
                return BadRequest(valResult.ToString(" "));

            try
            {
                var result = await _signService.SignUpService(user);
                if (result != null)
                    return Ok(result);
                else
                    return BadRequest("Usuário não foi cadastrado");
            } catch(ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        #endregion
    }
}
