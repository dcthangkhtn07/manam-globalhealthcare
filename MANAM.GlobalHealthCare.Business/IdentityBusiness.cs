using MANAM.GlobalHealthCare.Business.Interfaces;
using MANAM.GlobalHealthCare.Common.Entities;
using MANAM.GlobalHealthCare.Repository.Interfaces;
using BC = BCrypt.Net.BCrypt;

namespace MANAM.GlobalHealthCare.Business
{
    public class IdentityBusiness : IIdentityBusiness
    {
        private readonly IUnitOfWork _unitOfWork;

        public IdentityBusiness(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User?> GetUserLogin(string username, string password)
        {
            var accountQueryable = await _unitOfWork.UserRepository.GetAllAsync(w => w.Username == username);
            var account = accountQueryable.FirstOrDefault();
            if (account != null && BC.Verify(password, account.PasswordHash))
            {
                return account;
            }

            return null;
        }
    }
}
