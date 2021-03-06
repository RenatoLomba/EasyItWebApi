using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Domain.DTOs.FavoritesDTOs;
using Domain.Interfaces.AppServicesInterfaces;
using Domain.Validators.FavoritesValidators;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        private readonly IFavoritesService _service;

        public FavoritesController(IFavoritesService service)
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
                    return NotFound("Favorito não encontrado");
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Authorize("Bearer", Roles = "User")]
        [HttpGet("{userId}/{expertId}")]
        public async Task<ActionResult> FindRelation(Guid userId, Guid expertId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var result = await _service.GetByUserAndExpert(userId, expertId);
                if (result != null)
                    return Ok(result);
                else
                    return NotFound("Favorito não encontrado");
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
        public async Task<ActionResult> Create(FavoritesDTOCreate favorite)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            FavoritesCreateValidator validator = new FavoritesCreateValidator();
            ValidationResult valResult = validator.Validate(favorite);
            if (!valResult.IsValid)
                return BadRequest(valResult.ToString(" "));

            try
            {
                var result = await _service.Create(favorite);
                if (result != null)
                    return Ok(result);
                else
                    return BadRequest("Favorito não foi cadastrado");
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
