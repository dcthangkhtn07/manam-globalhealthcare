using MANAM.GlobalHealthCare.Business.Interfaces;
using MANAM.GlobalHealthCare.Model;
using MANAM.GlobalHealthCare.Repository.Interfaces;
using System.Net;

namespace MANAM.GlobalHealthCare.Business
{
    public class CompanyProfileBusiness : ICompanyProfileBusiness
    {
        private const string PRIMARY_CODE = "Primary";

        private readonly IUnitOfWork _unitOfWork;

        public CompanyProfileBusiness(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CompanyProfileViewModel> GetCompanyProfileAsync()
        {
            var queryable = await _unitOfWork.CompanyProfileRepository.GetAllAsync(f => f.Code == PRIMARY_CODE);
            var companyProfile = queryable.FirstOrDefault();
            if (companyProfile != null)
            {
                return new CompanyProfileViewModel
                {
                    Id = companyProfile.Id,
                    HeadquarterAddress = companyProfile.HeadquarterAddress,
                    Hotline1 = companyProfile.Hotline1,
                    Hotline2 = companyProfile.Hotline2,
                    Email = companyProfile.Email,
                    Address = companyProfile.Address,
                    FacebookAddress = companyProfile.FacebookAddress,
                    YoutubeAddress = companyProfile.YoutubeAddress,
                    ZaloAddress = companyProfile.ZaloAddress,
                    MessengerAddress = companyProfile.MessengerAddress
                };
            }
            return new CompanyProfileViewModel();
        }

        public async Task<bool> UpdateCompanyProfileAsync(CompanyProfileViewModel model)
        {
            var queryable = await _unitOfWork.CompanyProfileRepository.GetAllAsync(f => f.Code == PRIMARY_CODE);
            var companyProfile = queryable.FirstOrDefault();
            if (companyProfile != null)
            {
                companyProfile.HeadquarterAddress = model.HeadquarterAddress;
                companyProfile.Hotline1 = model.Hotline1;
                companyProfile.Hotline2 = model.Hotline2;
                companyProfile.Email = model.Email;
                companyProfile.Address = model.Address;
                companyProfile.FacebookAddress = model.FacebookAddress;
                companyProfile.YoutubeAddress = model.YoutubeAddress;
                companyProfile.ZaloAddress = model.ZaloAddress;
                companyProfile.MessengerAddress = model.MessengerAddress;

                _unitOfWork.CompanyProfileRepository.Update(companyProfile);
                return await _unitOfWork.SaveChangesAsync();
            }

            return false;
        }
    }
}
