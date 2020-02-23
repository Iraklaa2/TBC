using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace TestProject.Application.Validation.Filters
{
    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] _Extensions;

        public AllowedExtensionsAttribute(string[] Extensions) : base($"This photo extension is not allowed!") => _Extensions = Extensions;

        public override bool IsValid(object value)
        {
            var file = value as IFormFile;
            var extension = Path.GetExtension(file.FileName);

            if (!(file == null))
            {
                if (!_Extensions.Contains(extension.ToLower()))
                    return false;
            }

            return true;
        }
    }
}
