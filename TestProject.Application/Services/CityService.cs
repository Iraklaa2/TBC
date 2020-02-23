using AutoMapper;
using System.Collections.Generic;
using TestProject.Application.Contracts;
using TestProject.Application.DTO.Requests;
using TestProject.Application.DTO.Responses;
using TestProject.Application.DTOs.City;
using TestProject.Application.DTOs.Filters;
using TestProject.Domain.Contracts;
using TestProject.Domain.Entities;
using TestProject.Domain.Models;

namespace TestProject.Application.Services
{
    public class CityService : Service, ICityService
    {
        private readonly ICityRepository _cityRepository;
        
        public CityService(ICityRepository cityRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(unitOfWork, mapper)
        {
            _cityRepository = cityRepository;
        }

        public bool CheckIfCityExists(int cityId, out CityEntity existingCity)
        {
            existingCity = _cityRepository.GetById(cityId);

            return existingCity != null;
        }

        public ListViewDTO<CityDTO> GetCities(ListReuqestDTO<CityFilterDTO> requestParams)
        {
            var cities = _cityRepository.GetAll(requestParams.Filter, requestParams.Page, requestParams.Limit, out var totalRecords);

            return new ListViewDTO<CityDTO>
            {
                Data = Mapper.Map<IEnumerable<CityDTO>>(cities),
                TotalRecords = totalRecords
            };
        }

        public DomainStatusCodes GetCityById(int cityId, out CityDTO city)
        {
            city = null;

            if (!CheckIfCityExists(cityId, out var cityEntity))
                return DomainStatusCodes.RecordNotFound;

            city = Mapper.Map<CityDTO>(cityEntity);

            return DomainStatusCodes.Success;
        }
    }
}
