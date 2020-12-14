using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BestTimes.Models;
using BestTimes.Data.Repository;
using BestTimes.Data;
using BestTimes.Services;
using Microsoft.AspNetCore.Authorization;

namespace BestTimes.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBestTimesService bestTimesService;

        public HomeController(ILogger<HomeController> logger, IBestTimesService bestTimesService)
        {
            _logger = logger;
            this.bestTimesService = bestTimesService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = bestTimesService.GetList();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create([FromForm] BestTimeFormModel bestTime)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Error));
            }

            bestTimesService.CreateBestTime(bestTime);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Admin()
        {
            var model = bestTimesService.GetUnapproved();
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Approve(int id)
        {
            bestTimesService.ApproveBestTime(id);
            return RedirectToAction(nameof(Admin));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Reject(int id)
        {
            bestTimesService.DeleteBestTime(id);
            return RedirectToAction(nameof(Admin));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            bestTimesService.DeleteBestTime(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
