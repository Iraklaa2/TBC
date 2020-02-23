using System;
using System.ComponentModel.DataAnnotations;

namespace TestProject.Application.Validation.Filters
{
    class MinimumAgeAttribute : ValidationAttribute
    {
        private readonly int _minimumAge;

        public MinimumAgeAttribute(int minimumAge) : base($"Minimum age must be: {minimumAge}") => _minimumAge = minimumAge;

        public override bool IsValid(object value)
        {
            if (value == null)
                return true;

            if (DateTime.TryParse(value.ToString(), out DateTime date))
                return date.AddYears(_minimumAge) < DateTime.Now;
            
            return false;
        }
    }
}
