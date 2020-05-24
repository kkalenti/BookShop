using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using BookStore.ViewModels.Roles;
using BookStore.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace BookStore.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [Authorize(Roles = "Admin")]
        // GET: User
        public ActionResult Index()
        {
            var users = _userManager.Users.Select(x => new UserViewModel()
            {
                Id = x.Id,
                LastName = x.LastName,
                FirstName = x.FirstName,
                Email = x.Email,
            });
            return View(users);
        }

        [Authorize(Roles = "Admin")]
        // GET: User/Details/5
        public async Task<ViewResult> Details(string id)
        {
            var user =  await _userManager.FindByIdAsync(id);
            var roles = _roleManager.Roles.ToList();
            var userRoles = (await _userManager.GetRolesAsync(user)).ToList();
            return View(new UserViewModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Phone = user.PhoneNumber,
                Id = user.Id,
                IsLockedOut = user.LockoutEnabled,
                UserInRole = roles.Select(x => new RolesViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Selected = userRoles.Exists(y => y == x.Name)
                }).ToList()
            });
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult> Details(string id, UserViewModel model)
        {
            var user = await _userManager.FindByIdAsync(id);
            var roles = _roleManager.Roles.ToList();
            var userRoles = (await _userManager.GetRolesAsync(user)).ToList();
            if (model.IsLockedOut)
            {
                user.LockoutEnabled = true;
                user.LockoutEnd = new DateTime(9999, 12, 30);
                await _userManager.UpdateAsync(user);
            }
            else
            {
                user.LockoutEnabled = false;
                await _userManager.UpdateAsync(user);
            }
            foreach (var role in model.UserInRole)
            {
                if (role.Selected)
                {
                    await _userManager.AddToRoleAsync(user, roles.First(x => x.Id.Equals(role.Id)).Name);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, roles.First(x => x.Id.Equals(role.Id)).Name);
                }
            }

            return RedirectToAction("Index","User");
        }

        // GET: User/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: User/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: User/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: User/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: User/Delete/5
        public async Task<ViewResult> Delete(string id)
        {
            //var user = await _userManager.FindByIdAsync(id);
            //await _userManager.SetLockoutEnabledAsync(user, false);
            //return ;
            return View();
        }

        // POST: User/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        [Authorize(Roles = "User")]
        [HttpGet]
        public async Task<ViewResult> Profile()
        {
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            return View(new UserViewModel()
            {
                Id = user.Id,
                LastName =  user.LastName,
                FirstName = user.FirstName,
                Email = user.Email,
                Phone = user.PhoneNumber
            });
        }

        [HttpPost]
        public async Task<ActionResult> Profile(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                var updatedUser = await _userManager.FindByEmailAsync(User.Identity.Name);
                updatedUser.LastName = user.LastName;
                updatedUser.FirstName = user.FirstName;
                updatedUser.Email = user.Email;
                updatedUser.NormalizedEmail = user.Email.ToUpper();
                updatedUser.UserName = user.Email;
                updatedUser.NormalizedUserName = user.Email.ToUpper();
                updatedUser.PhoneNumber = user.Phone;

                var result = await _userManager.UpdateAsync(updatedUser);
                if (result.Succeeded)
                {
                    ViewData["message"] = "Successfully updated profile";
                }
                else
                {
                    ViewData["message"] = "Profile update error";
                }

                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [Authorize(Roles = "User")]
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.FindByEmailAsync(User.Identity.Name);
                    var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }

                        return View();
                    }
                }
                ModelState.AddModelError("","Invalid data passed");
                return View();
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Password could not be changed!");
                return View();
            }
        }
    }
}