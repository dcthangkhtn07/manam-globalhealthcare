using MANAM.GlobalHealthCare.Common.Db;
using MANAM.GlobalHealthCare.Common.Entities;
using MANAM.GlobalHealthCare.Repository.Interfaces;

namespace MANAM.GlobalHealthCare.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private AppDbContext _context;
        private GenericRepository<CompanyProfile>? _companyProfileRepository;
        private GenericRepository<MedicalEntity>? _medicalEntityRepository;
        private GenericRepository<User>? _userRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }


        public IGenericRepository<CompanyProfile> CompanyProfileRepository
        {
            get
            {
                _companyProfileRepository ??= new GenericRepository<CompanyProfile>(_context);
                return _companyProfileRepository;
            }
        }

        public IGenericRepository<MedicalEntity> MedicalEntityRepository
        {
            get
            {
                _medicalEntityRepository ??= new GenericRepository<MedicalEntity>(_context);
                return _medicalEntityRepository;
            }
        }

        public IGenericRepository<User> UserRepository
        {
            get
            {
                _userRepository ??= new GenericRepository<User>(_context);
                return _userRepository;
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
