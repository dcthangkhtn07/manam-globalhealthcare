using MANAM.GlobalHealthCare.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MANAM.GlobalHealthCare.WebApp.Areas.User.ViewComponents
{
    [ViewComponent(Name = "Menu")]
    public class MenuViewComponent : ViewComponent
    {
        private readonly IMedicalEntityBusiness _medicalEntityBusiness;

        public MenuViewComponent(IMedicalEntityBusiness medicalEntityBusiness)
        {
            _medicalEntityBusiness = medicalEntityBusiness;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await _medicalEntityBusiness.GetMenuListAsync();
            return View("Index", data);
        }
    }
}
