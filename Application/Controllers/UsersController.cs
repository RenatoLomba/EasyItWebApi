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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("API/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService service)
        {
            _userService = service;
        }

        #region GETS
        [HttpGet]
        [Authorize("Bearer", Roles = "User")]
        public async Task<ActionResult> All()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _userService.GetAll();
                return Ok(result);
            } catch(ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Authorize("Bearer", Roles = "User")]
        [HttpGet("{id}")]
        public async Task<ActionResult> Id(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _userService.Get(id);
                if (result != null)
                    return Ok(result);
                else
                    return NotFound("Usuário não encontrado");
            } catch(ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize("Bearer", Roles = "User")]
        public async Task<ActionResult> Complete(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _userService.GetComplete(id);
                if (result != null)
                    return Ok(result);
                else
                    return NotFound("Usuário não encontrado");
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        #endregion

        #region PUT
        [Authorize("Bearer", Roles = "User")]
        [HttpPut]
        public async Task<ActionResult> Update(UserDTOUpdate user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            UserUpdateValidator validator = new UserUpdateValidator();
            ValidationResult valResult = await validator.ValidateAsync(user);
            if (!valResult.IsValid)
                return BadRequest(valResult.ToString(" "));

            try
            {
                var result = await _userService.Put(user);
                if (result != null)
                    return Ok(result);
                else
                    return NotFound("Usuário não existente");
            } catch(ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        #endregion

        #region DELETE
        [Authorize("Bearer", Roles = "Administrator")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _userService.Delete(id);
                if (result)
                    return Ok(result);
                else
                    return BadRequest();
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        #endregion
    }
}
