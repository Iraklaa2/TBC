using System.ComponentModel.DataAnnotations;
using TestProject.Application.Validation;
using TestProject.Domain.Models;

namespace TestProject.Application.DTOs.Report
{
    public class RequestReportDTO
    {
        [EnumDataType(typeof(RelatedPersonsType), ErrorMessage = ValidationErrorCodes.NotValidDataType)]
        public RelatedPersonsType RelatedPersonsType { get; set; }
    }
}
