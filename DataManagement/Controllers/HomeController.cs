using DataManagement.Models;
using DomainLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DataManagement.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IFactoryService _factoryService;

        public HomeController(ILogger<HomeController> logger, IFactoryService factoryService)
        {
            _logger = logger;
            _factoryService = factoryService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFactory([FromForm]FactoryModel model)
        {
            try
            {
                await _factoryService.AddFactoryAsync(model);

                return Json("Success adding data!");

            }catch(Exception e)
            {
                return Json(e.Message);
            }

        }


        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<JsonResult> GetAllData()
        {
            var data = await _factoryService.GetAllFactoriesAsync();
 
            return Json(data.ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}