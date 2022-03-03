using api.Models;

namespace api.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<Person> PersonsRepository { get; }
        IGenericRepository<User> UsersRepository { get; }
        IGenericRepository<Disease> DiseasesRepository { get; }

        void Dispose();
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
