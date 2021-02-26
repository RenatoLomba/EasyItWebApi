using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Domain.DTOs.PhotoDTOs;
using Domain.Interfaces.AppServicesInterfaces;
using Domain.Validators.PhotoValidators;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("API/[controller]/[action]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly IPhotoService _service;

        public PhotosController(IPhotoService service)
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
                    return NotFound("Photo não encontrada");
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
        public async Task<ActionResult> Create(PhotoDTOCreate photo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            PhotoCreateValidator validator = new PhotoCreateValidator();
            ValidationResult valResult = validator.Validate(photo);
            if (!valResult.IsValid)
                return BadRequest(valResult.ToString(" "));

            try
            {
                var result = await _service.Create(photo);
                if (result != null)
                    return Ok(result);
                else
                    return BadRequest("Photo não foi cadastrada");
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
