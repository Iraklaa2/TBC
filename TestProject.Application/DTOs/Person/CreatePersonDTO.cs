using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TestProject.Application.DTOs.PhoneNumber;
using TestProject.Application.Validation;
using TestProject.Application.Validation.Filters;
using TestProject.Domain.Models;

namespace TestProject.Application.DTOs.Person
{
    public class CreatePersonDTO
    {
        [Required(ErrorMessage = ValidationErrorCodes.Required)]
        [RegularExpression(ValidationConfig.OnlyGeoOrLatPattern, ErrorMessage = ValidationErrorCodes.NotValidFormat)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = ValidationErrorCodes.Required)]
        [RegularExpression(ValidationConfig.OnlyGeoOrLatPattern, ErrorMessage = ValidationErrorCodes.NotValidFormat)]
        public string LastName { get; set; }

        [Required(ErrorMessage = ValidationErrorCodes.Required)]
        [RegularExpression(ValidationConfig.PersonalNumberPattern, ErrorMessage = ValidationErrorCodes.NotValidFormat)]
        public string PersonalNumber { get; set; }

        [Required(ErrorMessage = ValidationErrorCodes.Required)]
        [MinimumAge(ValidationConfig.MinimumAge, ErrorMessage = ValidationErrorCodes.AgeRestrictionViolation)]
        [DataType(DataType.Date, ErrorMessage = ValidationErrorCodes.NotValidDataType)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = ValidationErrorCodes.Required)]
        [EnumDataType(typeof(GenderType), ErrorMessage = ValidationErrorCodes.NotValidDataType)]
        public GenderType Gender { get; set; }

        [Required(ErrorMessage = ValidationErrorCodes.Required)]
        [RegularExpression(ValidationConfig.IntegerPattern, ErrorMessage = ValidationErrorCodes.NotValidDataType)]
        public int CityId { get; set; }

        [Required(ErrorMessage = ValidationErrorCodes.Required)]
        [MinLength(ValidationConfig.MinimumPhoneNumbers), MaxLength(ValidationConfig.MaximumPhoneNumbers)]
        public IEnumerable<AddPhoneNumberDTO> PhoneNumbers { get; set; }
    }
}
