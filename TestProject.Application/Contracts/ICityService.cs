using TestProject.Application.DTO.Requests;
using TestProject.Application.DTO.Responses;
using TestProject.Application.DTOs.City;
using TestProject.Application.DTOs.Filters;
using TestProject.Domain.Entities;
using TestProject.Domain.Models;

namespace TestProject.Application.Contracts
{
    public interface ICityService
    {
        bool CheckIfCityExists(int cityId, out CityEntity existingCity);

        DomainStatusCodes GetCityById(int cityId, out CityDTO city);

        ListViewDTO<CityDTO> GetCities(ListReuqestDTO<CityFilterDTO> requestParams);
    }
}
