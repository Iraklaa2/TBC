using System;
using System.ComponentModel.DataAnnotations;
using TestProject.Application.Validation;
using TestProject.Application.Validation.Filters;
using TestProject.Domain.Models;

namespace TestProject.Application.DTOs.Filters
{
    public class PersonFilterDTO
    {
        [RegularExpression(ValidationConfig.OnlyGeoOrLatFilterPattern, ErrorMessage = ValidationErrorCodes.NotValidFormat)]
        public string FirstName { get; set; }

        [RegularExpression(ValidationConfig.OnlyGeoOrLatFilterPattern, ErrorMessage = ValidationErrorCodes.NotValidFormat)]
        public string LastName { get; set; }

        [RegularExpression(ValidationConfig.PersonalNumberFilterPattern, ErrorMessage = ValidationErrorCodes.NotValidFormat)]
        public string PersonalNumber { get; set; }

        [EnumDataType(typeof(GenderType), ErrorMessage = ValidationErrorCodes.NotValidDataType)]
        public GenderType? Gender { get; set; }

        [DataType(DataType.Date, ErrorMessage = ValidationErrorCodes.NotValidDataType)]
        [MinimumAge(ValidationConfig.MinimumAge, ErrorMessage = ValidationErrorCodes.AgeRestrictionViolation)]
        public DateTime? DateOfBirth { get; set; }

        public CityFilterDTO City { get; set; }

        public PhoneNumberFilter PhoneNumbers { get; set; }
    }
}
