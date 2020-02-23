using System.ComponentModel.DataAnnotations;
using TestProject.Application.Validation;

namespace TestProject.Application.DTOs.Filters
{
    public class CityFilterDTO
    {
        [RegularExpression(ValidationConfig.CityNameFilterPattern, ErrorMessage = ValidationErrorCodes.NotValidFormat)]
        public string Name { get; set; }
    }
}
