using AutoMapper;
using System.Linq;
using TestProject.Application.Contracts;
using TestProject.Application.DTOs.RelativePerson;
using TestProject.Application.DTOs.Report;
using TestProject.Domain.Contracts;
using TestProject.Domain.Entities;
using TestProject.Domain.Models;

namespace TestProject.Application.Services
{
    public class RelatedPersonService : BasePersonService, IRelatedPersonService
    {
        private readonly IRelatedPersonRepository _relatedPersonRepository;

        public RelatedPersonService(IMapper mapper, IRelatedPersonRepository relatedPersonRepository, IPersonRepository personRepository, IUnitOfWork unitOfWork)
            : base(unitOfWork, mapper, personRepository)
        {
            _relatedPersonRepository = relatedPersonRepository;
        }

        public DomainStatusCodes AddRelative(int personId, AddRelativeDTO personRelativeData)
        {
            if (!CheckIfPersonExists(personId, out var _))
                return DomainStatusCodes.RecordNotFound;

            if (!CheckIfPersonExists(personRelativeData.RelativeId, out var _))
                return DomainStatusCodes.RecordNotFound;

            var existinRelation = _relatedPersonRepository.GetRelation(personId, personRelativeData.RelativeId);

            if (existinRelation != null)
                return DomainStatusCodes.RecordAlreadyExists;

            var relation = new RelatedPersonEntity 
            {
                PersonId = personId,
                RelatedPersonId = personRelativeData.RelativeId,
                RelationType = personRelativeData.RelativeType
            };

            _relatedPersonRepository.Add(relation);

            Commit();

            return DomainStatusCodes.Success;
        }

        public DomainStatusCodes RemoveRelative(int personId, RemoveRelativeDTO personRelativeData)
        {
            if (!CheckIfPersonExists(personId, out var _))
                return DomainStatusCodes.RecordNotFound;

            if (!CheckIfPersonExists(personRelativeData.RelativeId, out var _))
                return DomainStatusCodes.RecordNotFound;

            var existinRelation = _relatedPersonRepository.GetRelation(personId, personRelativeData.RelativeId);

            if (existinRelation == null)
                return DomainStatusCodes.RecordNotFound;

            _relatedPersonRepository.Remove(personId, personRelativeData.RelativeId);

            Commit();

            return DomainStatusCodes.Success;
        }

        public DomainStatusCodes GetPersonsRelativesAmountByType(int personId, RequestReportDTO reportData, out ReportDataDTO report)
        {
            report = null;

            if (!CheckIfPersonExists(personId, out _))
                return DomainStatusCodes.RecordNotFound;

            report = new ReportDataDTO { RelationsAmount = _relatedPersonRepository.PersonsRelativesAmountByType(personId, reportData.RelatedPersonsType) };

            return DomainStatusCodes.Success;
        }

        public void DeletePersonsAllRelations(int personId)
        {
            var relations = _relatedPersonRepository.GetPersonsAllRelations(personId);

            if (relations.Count() > 0)
                _relatedPersonRepository.RemovePersonsAllRelations(relations);
        }
    }
}