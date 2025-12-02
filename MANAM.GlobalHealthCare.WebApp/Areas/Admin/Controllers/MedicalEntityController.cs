using MANAM.GlobalHealthCare.Business.Interfaces;
using MANAM.GlobalHealthCare.Model;
using Microsoft.AspNetCore.Mvc;

namespace MANAM.GlobalHealthCare.WebApp.Areas.Admin.Controllers
{
    public class MedicalEntityController : BaseController
    {
        private readonly IMedicalEntityBusiness _medicalEntityBusiness;

        public MedicalEntityController(IMedicalEntityBusiness medicalEntityBusiness)
        {
            _medicalEntityBusiness = medicalEntityBusiness;
        }

        [HttpGet]
        public async Task<IActionResult> List(string category, int page = 1)
        {
            var model = await _medicalEntityBusiness.GetMedicalEntityPagedAsync(category, page, 1000);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Index(string category, int? id)
        {
            var model = new MedicalEntityViewModel();
            model.Category = category;
            if (id != null && id.HasValue)
            {
                model = await _medicalEntityBusiness.GetDetailAsync(id.Value);
                model.Category = model.Category;
            }

            if (string.IsNullOrEmpty(model.AvatarUrl))
            {
                model.AvatarUrl = "default.jpg";
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(MedicalEntityViewModel model)
        {
            var result = false;
            if (model.Avatar != null)
            {
                string folder = "medical-services";
                switch (model.Category.ToLower())
                {
                    case "hospitals":
                        folder = "hospitals";
                        break;
                    case "medicalinformation":
                        folder = "medical-information";
                        break;
                    case "keyservices":
                        folder = "key-services";
                        break;
                    case "advancedtherapies":
                        folder = "advanced-therapies";
                        break;
                }
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/user/images/" + folder);
                FileInfo fileInfo = new FileInfo(model.Avatar.FileName);
                string fileName = Guid.NewGuid().ToString() + fileInfo.Extension;
                string fileNameWithPath = Path.Combine(path, fileName);
                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    model.Avatar.CopyTo(stream);
                }
                model.AvatarUrl = fileName;
            }

            if (model.Id == 0)
            {
                result = await _medicalEntityBusiness.InsertNewMedicalEntityAsync(model);
            }
            else
            {
                result = await _medicalEntityBusiness.UpdateMedicalEntityAsync(model);
            }

            return Json(new
            {
                Status = GetResponseStatus(result)
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _medicalEntityBusiness.DeleteMedicalEntityAsync(id);

            return Json(new
            {
                Status = GetResponseStatus(result)
            });
        }
    }
}
