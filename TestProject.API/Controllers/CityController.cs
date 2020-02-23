using Microsoft.AspNetCore.Mvc;
using TestProject.Application.Contracts;
using TestProject.Application.DTO.Requests;
using TestProject.Application.DTOs.City;
using TestProject.Application.DTOs.Filters;
using TestProject.Application.Validation;
using TestProject.Domain.Models;

namespace TestProject.API.Controllers
{
    [Route("api/[controller]")]
    [ModelValidation]
    public class CityController : BaseController
    {
        private readonly ICityService _cityServie;

        public CityController(ICityService cityServie) : base()
        {
            _cityServie = cityServie;
        }

        [HttpGet("{cityId}")]
        public IActionResult GetCityById(int cityId)
        {
            var statusCode = _cityServie.GetCityById(cityId, out CityDTO city);
            return Response(statusCode, city);
        }

        [HttpGet]
        public IActionResult GetCities([FromQuery] ListReuqestDTO<CityFilterDTO> requestParams)
        {
            var cities = _cityServie.GetCities(requestParams);
            return Response(DomainStatusCodes.Success, cities);
        }
    }
}
