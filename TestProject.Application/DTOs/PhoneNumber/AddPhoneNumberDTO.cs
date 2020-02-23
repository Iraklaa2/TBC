using System.ComponentModel.DataAnnotations;
using TestProject.Application.Validation;
using TestProject.Domain.Models;

namespace TestProject.Application.DTOs.PhoneNumber
{
    public class AddPhoneNumberDTO
    {
        [Required(ErrorMessage = ValidationErrorCodes.Required)]
        [EnumDataType(typeof(PhoneNumberType), ErrorMessage = ValidationErrorCodes.NotValidDataType)]
        public PhoneNumberType Type { get; set; }

        [Required(ErrorMessage = ValidationErrorCodes.Required)]
        [RegularExpression(ValidationConfig.PhoneNumberPattern, ErrorMessage = ValidationErrorCodes.NotValidFormat)]
        public string Number { get; set; }
    }
}
