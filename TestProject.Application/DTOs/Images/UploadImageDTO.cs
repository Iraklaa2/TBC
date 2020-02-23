using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using TestProject.Application.Validation;
using TestProject.Application.Validation.Filters;

namespace TestProject.Application.DTOs.Requests
{
    public class UploadImageDTO
    {
        [Required(ErrorMessage = ValidationErrorCodes.Required)]
        [DataType(DataType.Upload, ErrorMessage = ValidationErrorCodes.NotValidDataType)]
        [AllowedExtensions(new string[] { ".jpg", ".png" }, ErrorMessage = ValidationErrorCodes.NotValidFileExtension)]
        [MaxFileSize(ValidationConfig.MaximumFileSize, ErrorMessageResourceName = ValidationErrorCodes.FileSizeIsToBig)]
        public IFormFile Image { get; set; }
    }
}
