using MANAM.GlobalHealthCare.Common.Entities;

namespace MANAM.GlobalHealthCare.Business.Interfaces
{
    public interface IIdentityBusiness
    {
        Task<User?> GetUserLogin(string username, string password);
    }
}
