﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC___31._05._2023.Models;
using System.Diagnostics;

namespace MVC___31._05._2023.Controllers
{
    public class HomeController : Controller
    {
        private UserManager<AppUser> userManager;
        private readonly ILogger<HomeController> _logger;

        public HomeController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            AppUser loggedInUser= await userManager.GetUserAsync(HttpContext.User);
            string message = $"Hello {loggedInUser.UserName}";
            return View("Index",message);
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