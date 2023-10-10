﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Person.API.Dtos;
using Person.API.Services;

namespace Person.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var person_response = await _personService.GetAllAsync();

            return new OkObjectResult(person_response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PersonCreateDto personCreateDto)
        {
            try
            {
                var new_person_response = await _personService.CreateAsync(personCreateDto);
                return new OkObjectResult(new_person_response);
            }
            catch (Exception)
            {
                return BadRequest(new { errorMessage = "Somethings gone wrong!" });
            }
        }
    }
}
