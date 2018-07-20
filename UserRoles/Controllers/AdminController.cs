using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserRoles.Data;
using UserRoles.Models;
using UserRoles.Models.AccountViewModels;
using UserRoles.Models.AdminViewModels;

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


        public IActionResult ManageUsers(string roleId)
        {
            var roles = context.Roles.ToList();
            return View(roles);
        }

        public IActionResult Thing(string roleId)
        {
            var thing = (from ur in context.UserRoles
                         join u in context.Users on ur.UserId equals u.Id
                         where ur.RoleId == roleId
                         select new ViewUsersViewModel() {
                             Email = u.Email,
                             Username = u.UserName,
                             UserId = u.Id

                         }).ToList();
            return View(thing);

        }
    }
}