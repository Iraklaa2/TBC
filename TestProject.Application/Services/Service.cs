using AutoMapper;
using System;
using TestProject.Domain.Contracts;

namespace TestProject.Application.Services
{
    public class Service
    {
        protected readonly IUnitOfWork UnitOfWork;

        protected readonly IMapper Mapper;

        public Service(IUnitOfWork unitOfWork, IMapper mapper)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        protected bool Commit()
        {
            return UnitOfWork.Commit();
        }

        public void Dispose() => GC.SuppressFinalize(this);
    }
}
