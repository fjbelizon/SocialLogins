namespace Social.Logins.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Social.Logins.Web.Models;

    [Route("profile")]
    public class ProfileController : Controller
    {
        [Route("")]
        [Authorize]
        public IActionResult Index()
        {
            var vm = new ProfileViewModel
            {
                Claims = User.Claims,
                Name = User.Identity.Name
            };

            return View(vm);
        }
    }
}
