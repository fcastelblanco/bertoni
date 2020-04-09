using System.Threading.Tasks;
using Fgcm.ApplicationService.Definitions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Fgcm.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGeneralApplicationService _generalApplicationService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IGeneralApplicationService generalApplicationService)
        {
            _logger = logger;
            _generalApplicationService = generalApplicationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetResources()
        {
            var photosList = await _generalApplicationService.GetAllPhotos();
            var albumsList = await _generalApplicationService.GetAllAlbums();
            var postList = await _generalApplicationService.GetAllComments();

            return Json(new {photos = photosList, albums = albumsList, post = postList});
        }
    }
}