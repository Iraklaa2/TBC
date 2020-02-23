using TestProject.Application.DTOs.RelativePerson;
using TestProject.Application.DTOs.Report;
using TestProject.Domain.Models;

namespace TestProject.Application.Contracts
{
    public interface IRelatedPersonService
    {
        DomainStatusCodes AddRelative(int personId, AddRelativeDTO relativeData);

        DomainStatusCodes RemoveRelative(int personId, RemoveRelativeDTO relativeData);

        DomainStatusCodes GetPersonsRelativesAmountByType(int personId, RequestReportDTO reportData, out ReportDataDTO report);

        void DeletePersonsAllRelations(int personId);
    }
}
