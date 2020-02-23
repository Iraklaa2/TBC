using System.ComponentModel.DataAnnotations;
using TestProject.Application.Validation;
using TestProject.Domain.Models;

namespace TestProject.Application.DTOs.Filters
{
    public class PhoneNumberFilter
    {
        //[RegularExpression(ValidationConfig.PhoneNumberFilterPattern, ErrorMessage = ValidationErrorCodes.NotValidFormat)]
        //public string Number { get; set; }  // TODO: This works only == operation. not contains. need to debug

        [EnumDataType(typeof(PhoneNumberType), ErrorMessage = ValidationErrorCodes.NotValidDataType)]
        public PhoneNumberType? Type { get; set; }
    }
}
