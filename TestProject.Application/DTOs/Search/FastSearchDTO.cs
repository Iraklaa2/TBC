using System.ComponentModel.DataAnnotations;
using TestProject.Application.Validation;

namespace TestProject.Application.DTOs.Search
{
    public class FastSearchDTO
    {
        [Required]
        [RegularExpression(ValidationConfig.FastSearchValuePattern, ErrorMessage = ValidationErrorCodes.NotValidFormat)]
        public string Value { get; set; }
    }
}
