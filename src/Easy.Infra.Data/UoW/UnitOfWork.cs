using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using Easy.Infra.Data.Contexts;

namespace Easy.Infra.Data.UoW
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly EfContext _db;
        private DbContextTransaction _transaction;

        public UnitOfWork(EfContext db)
        {
            _db = db;
        }

        public void Dispose()
        {
            _db?.Dispose();
            _transaction?.Dispose();
        }

        public void BeginTran()
        {
            _transaction = _db.Database.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public void Save()
        {
            
            try
            {
                _db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }
    }
}
