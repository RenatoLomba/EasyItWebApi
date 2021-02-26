using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Domain.DTOs.TestimonialDTOs;
using Domain.Interfaces.AppServicesInterfaces;
using Domain.Validators.ServicesValidators;
using Domain.Validators.TestimonialsValidators;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("API/[controller]/[action]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly ITestimonialService _service;

        public TestimonialsController(ITestimonialService service)
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
                    return NotFound("Testimonial não encontrado");
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
                    return NotFound("Testimonial não encontrado");
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
        public async Task<ActionResult> Create(TestimonialDTOCreate testimonial)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            TestimonialCreateValidator validator = new TestimonialCreateValidator();
            ValidationResult valResult = validator.Validate(testimonial);
            if (!valResult.IsValid)
                return BadRequest(valResult.ToString(" "));

            try
            {
                var result = await _service.Create(testimonial);
                if (result != null)
                    return Ok(result);
                else
                    return BadRequest("Testimonial não foi cadastrado");
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
