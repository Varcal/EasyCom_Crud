using System;

namespace Easy.Infra.Data.UoW
{
    public interface IUnitOfWork: IDisposable
    {
        void BeginTran();
        void Commit();
        void Rollback();
        void Save();
    }
}
