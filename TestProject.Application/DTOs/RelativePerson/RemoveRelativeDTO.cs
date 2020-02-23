using System.ComponentModel.DataAnnotations;
using TestProject.Application.Validation;

namespace TestProject.Application.DTOs.RelativePerson
{
    public class RemoveRelativeDTO
    {
        [Required(ErrorMessage = ValidationErrorCodes.Required)]
        [RegularExpression(ValidationConfig.IntegerPattern, ErrorMessage = ValidationErrorCodes.NotValidDataType)]
        public int RelativeId { get; set; }
    }
}
