using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.Net;

namespace lab1.Controllers
{
    [Route("Cookies")]
    public class CookiesController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            //throw new NotImplementedException();
            ViewBag.CookieValue = Request.Cookies["CustomCookie"];
            return View("Views/Cookies/Index.cshtml");
        }

        [HttpPost("SetCookies")]
        public IActionResult SetCookies(string value, DateTime expiration)
        {
            CookieOptions option = new CookieOptions
            {
                Expires = expiration
            };

            Response.Cookies.Append("CustomCookie", value, option);

            return RedirectToAction("Index");
        }
    }
}