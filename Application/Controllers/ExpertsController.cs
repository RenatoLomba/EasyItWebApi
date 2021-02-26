using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Domain.DTOs.ExpertDTOs;
using Domain.Interfaces.AppServicesInterfaces;
using Domain.Validators.ExpertsValidators;
using Domain.Validators.UsersValidators;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("API/[controller]/[action]")]
    [ApiController]
    public class ExpertsController : ControllerBase
    {
        private readonly IExpertService _expertService;
        public ExpertsController(IExpertService expertService)
        {
            _expertService = expertService;
        }

        #region GETS
        [Authorize("Bearer", Roles = "User")]
        [HttpGet]
        public async Task<ActionResult> All()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _expertService.GetAll();
                return Ok(result);
            }
            catch (ArgumentException ex)
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
                var result = await _expertService.Get(id);
                if (result != null)
                    return Ok(result);
                else
                    return NotFound("Expert não encontrado");
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Authorize("Bearer", Roles = "User")]
        [HttpGet("{id}")]
        public async Task<ActionResult> Complete(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _expertService.GetComplete(id);
                if (result != null)
                    return Ok(result);
                else
                    return NotFound("Expert não encontrado");
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Authorize("Bearer", Roles = "User")]
        [HttpGet("{location}")]
        public async Task<ActionResult> Location(string location)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _expertService.GetByLocation(location);
                if (result != null)
                    return Ok(result);
                else
                    return NotFound("Não há Experts na sua região no momento");
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        #endregion

        #region CREATE
        [AllowAnonymous]
        [HttpPost]
        public async Task<object> Create(ExpertDTOCreate expert)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            ExpertCreateValidator validator = new ExpertCreateValidator();
            ValidationResult valResult = validator.Validate(expert);
            if (!valResult.IsValid)
                return BadRequest(valResult.ToString(" "));

            try
            {
                var result = await _expertService.CreateExpert(expert);
                if (result != null)
                    return Ok(result);
                else
                    return BadRequest("Usuário não foi cadastrado");
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        #endregion

        #region UPDATE
        [Authorize("Bearer", Roles = "User")]
        [HttpPut]
        public async Task<ActionResult> Update(ExpertDTOUpdate expert)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            ExpertUpdateValidator validator = new ExpertUpdateValidator();
            ValidationResult valResult = await validator.ValidateAsync(expert);
            if (!valResult.IsValid)
                return BadRequest(valResult.ToString(" "));

            try
            {
                var result = await _expertService.UpdateExpert(expert);
                if (result != null)
                    return Ok(result);
                else
                    return NotFound("Usuário não existente");
            }
            catch (ArgumentException ex)
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
                var result = await _expertService.Delete(id);
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
