using MANAM.GlobalHealthCare.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MANAM.GlobalHealthCare.WebApp.Areas.User.ViewComponents
{
    [ViewComponent(Name = "Menu")]
    public class MenuViewComponent : ViewComponent
    {
        private readonly IMedicalEntityBusiness _medicalEntityBusiness;
        private readonly ICompanyProfileBusiness _companyProfileBusiness;

        public MenuViewComponent(IMedicalEntityBusiness medicalEntityBusiness, ICompanyProfileBusiness companyProfileBusiness)
        {
            _medicalEntityBusiness = medicalEntityBusiness;
            _companyProfileBusiness = companyProfileBusiness;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await _medicalEntityBusiness.GetMenuListAsync();
            var companyProfile = await _companyProfileBusiness.GetCompanyProfileAsync();
            data.PhoneNumber = companyProfile?.Hotline1;
            return View("Index", data);
        }
    }
}
