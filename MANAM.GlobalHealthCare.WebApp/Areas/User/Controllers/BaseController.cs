using Microsoft.AspNetCore.Mvc;

namespace MANAM.GlobalHealthCare.WebApp.Areas.User.Controllers
{
    [Area("User")]
    public abstract class BaseController : Microsoft.AspNetCore.Mvc.Controller
    {
        public string GetResponseStatus(bool isSuccess)
        {
            return isSuccess ? "OK" : "Error";
        }
    }
}
