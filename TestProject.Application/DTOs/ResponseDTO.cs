using TestProject.Domain.Models;

namespace TestProject.Application.DTOs
{
    public class ResponseDTO
    {
        public DomainStatusCodes StatusCode { get; set; } = DomainStatusCodes.Success;

        public object Result { get; set; }
    }
}
