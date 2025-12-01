using MANAM.GlobalHealthCare.Business.Interfaces;
using MANAM.GlobalHealthCare.WebApp.Areas.User.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace KaMANAM.GlobalHealthCaremakura.WebApp.Areas.User.Controller
{
    public class MedicalEntityController : BaseController
    {
        private readonly IMedicalEntityBusiness _medicalEntityBusiness;

        public MedicalEntityController(IMedicalEntityBusiness medicalEntityBusiness)
        {
            _medicalEntityBusiness = medicalEntityBusiness;
        }

        public async Task<IActionResult> Index(string slug)
        {
            var data = await _medicalEntityBusiness.GetMedicalEntityDetailBySlugAsync(slug);
            return View("Index", data);
        }

        public async Task<IActionResult> List(string category, int page = 1)
        {
            var data = await _medicalEntityBusiness.GetMedicalEntityPagedAsync(category, page, 10);
            data.Category = category;
            return View("List", data);
        }
    }
}
