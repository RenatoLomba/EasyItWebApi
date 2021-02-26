using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Domain.DTOs.AvailableDateDTOs;
using Domain.Interfaces.AppServicesInterfaces;
using Domain.Validators.AvailableDatesValidators;
using Domain.Validators.AvailableHoursValidators;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("API/[controller]/[action]")]
    [ApiController]
    public class AvailableDatesController : ControllerBase
    {
        private readonly IAvailableDateService _service;

        public AvailableDatesController(IAvailableDateService service)
        {
            _service = service;
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
                var result = await _service.GetAll();
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
                var result = await _service.Get(id);
                if (result != null)
                    return Ok(result);
                else
                    return NotFound("Data não encontrada");
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
                var result = await _service.GetComplete(id);
                if (result != null)
                    return Ok(result);
                else
                    return NotFound("Data não encontrado");
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        #endregion

        #region CREATE
        [Authorize("Bearer", Roles = "User")]
        [HttpPost]
        public async Task<object> Create(AvailableDateDTOCreate date)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            AvailableDateCreateValidator dateValidator = new AvailableDateCreateValidator();
            AvailableHoursCreateValidator hourValidator = new AvailableHoursCreateValidator();
            ValidationResult valResult = dateValidator.Validate(date);
            if (!valResult.IsValid)
                return BadRequest(valResult.ToString(" "));

            foreach(var hour in date.AvailableHours)
            {
                valResult = hourValidator.Validate(hour);
                if (!valResult.IsValid)
                    return BadRequest(valResult.ToString(" "));
            }

            try
            {
                var result = await _service.Create(date);
                if (result != null)
                    return Ok(result);
                else
                    return BadRequest("Data não foi cadastrada");
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
                var result = await _service.Delete(id);
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
