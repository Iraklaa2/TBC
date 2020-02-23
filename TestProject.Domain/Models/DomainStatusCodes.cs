namespace TestProject.Domain.Models
{
    public enum DomainStatusCodes
    {
        Success = 10,

        GeneralError = 11,

        ValidationError = 12,

        UniqueViolation = 13,

        RecordNotFound = 14,

        RecordAlreadyExists = 15
    }
}
