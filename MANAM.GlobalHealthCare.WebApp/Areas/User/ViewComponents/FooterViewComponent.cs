using MANAM.GlobalHealthCare.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MANAM.GlobalHealthCare.WebApp.Areas.User.ViewComponents
{
    [ViewComponent(Name = "Footer")]
    public class FooterViewComponent : ViewComponent
    {
        private readonly ICompanyProfileBusiness _companyProfileBusiness;

        public FooterViewComponent(ICompanyProfileBusiness companyProfileBusiness)
        {
            _companyProfileBusiness = companyProfileBusiness;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await _companyProfileBusiness.GetCompanyProfileAsync();
            return View("Index", data);
        }
    }
}
