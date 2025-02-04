using ConfigurationAssignment.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ConfigurationAssignment.Controllers
{
    public class HomeController : Controller
    {
        private readonly SocialMediaLinksOptions _socialMedialLinksOptions;

        public HomeController(IOptions<SocialMediaLinksOptions> socialMedialLinksOptions)
        {
            _socialMedialLinksOptions = socialMedialLinksOptions.Value;
        }
        [Route("/")]
        public IActionResult Index()
        {
            return View(_socialMedialLinksOptions);
        }
    }
}
