using System;

namespace TestProject.Domain.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
