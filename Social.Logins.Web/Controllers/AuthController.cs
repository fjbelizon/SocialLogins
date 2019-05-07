namespace Social.Logins.Web.Controllers
{
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("auth")]
    public class AuthController : Controller
    {
        #region Actions

        [Route("login")]
        public IActionResult LogIn()
        {
            return View();
        }

        [Route("login/{provider}")]
        public IActionResult LogIn(string provider, string returnUrl = null)
        {
            return Challenge(new AuthenticationProperties { RedirectUri = returnUrl ?? "/" }, provider);
        }

        [Route("logout")]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        #endregion
    }
}