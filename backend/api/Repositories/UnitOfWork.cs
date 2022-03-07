using api.DataContext;
using api.Interfaces;
using api.Models;

namespace api.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private readonly IGenericRepository<Person> _personsRepository;
        private readonly IGenericRepository<User> _usersRepository;
        private readonly IGenericRepository<Disease> _diseasesRepository;
        private readonly IGenericRepository<DiseasePerson> _diseasePersonRepository;
        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IGenericRepository<Person> PersonsRepository => _personsRepository ?? new GenericRepository<Person, AppDbContext>(_dbContext);
        public IGenericRepository<User> UsersRepository => _usersRepository ?? new GenericRepository<User, AppDbContext>(_dbContext);
        public IGenericRepository<Disease> DiseasesRepository => _diseasesRepository ?? new GenericRepository<Disease, AppDbContext>(_dbContext);
        public IGenericRepository<DiseasePerson> DiseasesPersonsRepository => _diseasePersonRepository ?? new GenericRepository<DiseasePerson, AppDbContext>(_dbContext);

        #region Methods       

        public void Dispose()
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
            }
        }
        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}
