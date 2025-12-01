using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MANAM.GlobalHealthCare.WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public abstract class BaseController : Controller
    {
        public string GetResponseStatus(bool isSuccess)
        {
            return isSuccess ? "OK" : "Error";
        }
    }
}
