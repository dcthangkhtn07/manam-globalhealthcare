using MANAM.GlobalHealthCare.Common.Entities;

namespace MANAM.GlobalHealthCare.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<CompanyProfile> CompanyProfileRepository { get; }

        IGenericRepository<MedicalEntity> MedicalEntityRepository { get; }

        IGenericRepository<User> UserRepository { get; }

        Task<bool> SaveChangesAsync();
    }
}
