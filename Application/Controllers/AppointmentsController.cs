using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Domain.DTOs.AppointmentDTOs;
using Domain.Interfaces.AppServicesInterfaces;
using Domain.Validators.AppointmentsValidators;
using Domain.Validators.ServicesValidators;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _service;

        public AppointmentsController(IAppointmentService service)
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
                var result = await _service.GetById(id);
                if (result != null)
                    return Ok(result);
                else
                    return NotFound("Agendamento não encontrado");
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
        public async Task<ActionResult> Create(AppointmentDTOCreate appointment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            AppointmentCreateValidator validator = new AppointmentCreateValidator();
            AppointmentCreateDateValidator dateValidator = new AppointmentCreateDateValidator();
            ValidationResult valResult = validator.Validate(appointment);
            if (!valResult.IsValid)
                return BadRequest(valResult.ToString(" "));

            valResult = dateValidator.Validate(appointment.DateInfo);
            if (!valResult.IsValid)
                return BadRequest(valResult.ToString(" "));

            try
            {
                var result = await _service.Create(appointment);
                if (result != null)
                    return Ok(result);
                else
                    return BadRequest("Agendamento não foi cadastrado");
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        #endregion

        #region DELETE
        [Authorize("Bearer", Roles = "User")]
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
