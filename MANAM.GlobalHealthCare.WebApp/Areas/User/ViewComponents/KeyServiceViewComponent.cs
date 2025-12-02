using MANAM.GlobalHealthCare.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MANAM.GlobalHealthCare.WebApp.Areas.User.ViewComponents
{
    [ViewComponent(Name = "KeyService")]
    public class KeyServiceViewComponent : ViewComponent
    {
        private readonly IMedicalEntityBusiness _medicalEntityBusiness;

        public KeyServiceViewComponent(IMedicalEntityBusiness medicalEntityBusiness)
        {
            _medicalEntityBusiness = medicalEntityBusiness;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await _medicalEntityBusiness.GetMedicalEntityPagedAsync("MedicalServices", 0, 100);
            return View("Index", data);
        }
    }
}
