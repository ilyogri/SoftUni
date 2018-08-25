using AutoMapper;
using ChameleonStore.Common.Areas.Admin.Users.BindingModels;
using ChameleonStore.Models;
using ChameleonStore.Services.Admin.Interfaces;
using ChameleonStore.Services.Interfaces;
using ChameleonStore.Web.Data;
using ChameleonStore.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChameleonStore.Web.Areas.Admin.Controllers
{
    public class UsersController : AdminController
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> userManager;
        private readonly IUserService users;
        private readonly IRoleService roles;

        public UsersController(
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            IUserService users,
            IRoleService roles)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.users = users;
            this.roles = roles;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var currentUserId = this.userManager.GetUserId(User);

            var users = await this.users.GetAllAsync(currentUserId);

            foreach (var user in users)
            {
                user.IsAdmin = this.User.IsInRole("Admin");
            }

            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> AddToRole(string id)
        {
            var user = await this.userManager
                .FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            var currentUserRoles = await this.GetUserRoles(user);

            var result = await this.roles.GetByUserIdAsync(user.Id, currentUserRoles);

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddToRole(AddToRoleFormModel model)
        {
            var user = await this.userManager.FindByIdAsync(model.Id);
            var userExists = user != null;
            var role = await this.roles.GetByIdAsync(model.RoleId);

            if (!userExists || role == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid identity details.");
                var currentUserRoles = await this.GetUserRoles(user);
                return View(await roles.GetByUserIdAsync(model.Id, currentUserRoles));
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }

            await this.userManager.AddToRoleAsync(user, role.Name);

            TempData.AddSuccessMessage($"User '{user.UserName}' has been successfully added to '{role.Name}' role!");
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await userManager.FindByIdAsync(id);

            await this.userManager.DeleteAsync(user);

            TempData.AddSuccessMessage($"User '{user.UserName}' has been successfully deleted!");

            return RedirectToAction(nameof(Index));
        }

        private async Task<IList<string>> GetUserRoles(User user)
            => await this.userManager
                .GetRolesAsync(user);
    }
}
