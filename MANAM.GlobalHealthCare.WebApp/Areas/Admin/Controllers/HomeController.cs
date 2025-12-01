using MANAM.GlobalHealthCare.Business.Interfaces;
using MANAM.GlobalHealthCare.Model;
using Microsoft.AspNetCore.Mvc;

namespace MANAM.GlobalHealthCare.WebApp.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ICompanyProfileBusiness _companyProfileBusiness;

        public HomeController(ICompanyProfileBusiness companyProfileBusiness)
        {
            _companyProfileBusiness = companyProfileBusiness;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var companyProfile = await _companyProfileBusiness.GetCompanyProfileAsync();
            return View(companyProfile);
        }

        [HttpPost]
        public async Task<IActionResult> Index(CompanyProfileViewModel model)
        {
            await _companyProfileBusiness.UpdateCompanyProfileAsync(model);
            return Json(new
            {
                Status = "OK"
            });
        }
    }
}
