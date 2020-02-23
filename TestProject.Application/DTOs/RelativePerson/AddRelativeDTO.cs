using System.ComponentModel.DataAnnotations;
using TestProject.Application.Validation;
using TestProject.Domain.Models;

namespace TestProject.Application.DTOs.RelativePerson
{
    public class AddRelativeDTO
    {
        [Required(ErrorMessage = ValidationErrorCodes.Required)]
        [RegularExpression(ValidationConfig.IntegerPattern, ErrorMessage = ValidationErrorCodes.NotValidDataType)]
        public int RelativeId { get; set; }

        [Required(ErrorMessage = ValidationErrorCodes.Required)]
        [EnumDataType(typeof(RelatedPersonsType), ErrorMessage = ValidationErrorCodes.NotValidDataType)]
        public RelatedPersonsType RelativeType { get; set; }
    }
}