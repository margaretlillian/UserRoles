using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using UserRoles.Data;
using UserRoles.Models;
using UserRoles.Models.AccountViewModels;

namespace UserRoles.Controllers
{
    public class AdminController : Controller
    {

        private readonly ApplicationDbContext context;

        public AdminController(ApplicationDbContext applicationDbContext)
        {
            context = applicationDbContext;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }


        public IActionResult Thing(string roleId)
        {
            return View();
        }
        }
}