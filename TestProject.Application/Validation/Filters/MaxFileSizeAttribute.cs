using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace TestProject.Application.Validation.Filters
{
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly int _maxFileSize;
        
        public MaxFileSizeAttribute(int maxFileSize) : base($"Maximum allowed file size is { maxFileSize} bytes") => _maxFileSize = maxFileSize;

        public override bool IsValid(object value)
        {
            var file = value as IFormFile;
            
            if (file != null)
            {
                if (file.Length > _maxFileSize)
                    return false;
            }

            return true;
        }
    }
}
