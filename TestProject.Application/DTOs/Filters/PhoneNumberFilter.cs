using TestProject.Domain.Models;

namespace TestProject.Application.DTOs.Filters
{
    public class PhoneNumberFilter
    {
        public string Number { get; set; }

        public PhoneNumberType Type { get; set; }
    }
}
