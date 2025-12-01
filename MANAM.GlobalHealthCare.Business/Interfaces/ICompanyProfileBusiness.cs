using MANAM.GlobalHealthCare.Model;

namespace MANAM.GlobalHealthCare.Business.Interfaces
{
    public interface ICompanyProfileBusiness
    {
        Task<CompanyProfileViewModel> GetCompanyProfileAsync();

        Task<bool> UpdateCompanyProfileAsync(CompanyProfileViewModel model);
    }
}
