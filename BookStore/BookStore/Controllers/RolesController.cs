using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.ViewModels.Roles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        // GET: Roles
        public ActionResult Index()
        {
            var roles = _roleManager.Roles.Select(x => new RolesViewModel()
            {
                Id = x.Id,
                Name = x.Name,
            });
            return View(roles);
        }

        // GET: Roles/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RolesViewModel role)
        {
            try
            {
                await _roleManager.CreateAsync(new IdentityRole()
                {
                    Name = role.Name
                });
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Roles/Edit/5
         async public Task<ViewResult> Edit(string name)
        {
            var result = await _roleManager.FindByNameAsync(name);
            return View(new RolesViewModel()
            {
                Id = result.Id,
                Name = result.Name
            });
        }

        // POST: Roles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, string name)
        {
            try
            {
                if (await _roleManager.RoleExistsAsync(name))
                {
                    ModelState.AddModelError("","Same role already exist.");
                    return View();
                }
                else
                {
                    var role = await _roleManager.FindByIdAsync(id);
                    role.Name = name;
                    role.NormalizedName = name.ToUpper();
                    var result = await _roleManager.UpdateAsync(role);
                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError("", "The role couldn't be updated.");
                        return View();
                    }
                }

            }
            catch
            {
                return View();
            }
        }

        // GET: Roles/Delete/5
        public async Task<ActionResult> Delete(string id, string name)
        {
            try
            {
                if (!await _roleManager.RoleExistsAsync(name))
                {
                    ModelState.AddModelError("", "This role doesn't exist.");
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    var result = await _roleManager.FindByNameAsync(name);
                    return View(new RolesViewModel()
                    {
                        Id = result.Id,
                        Name = result.Name
                    });
                }
            }
            catch
            {
                //LoggIt
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: Roles/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var role = await _roleManager.FindByIdAsync(id);
                if (role != null)
                {
                    var result = await _roleManager.DeleteAsync(role);
                    if (result.Succeeded)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError("", $"{role.Name} couldn't be delete the role.");
                        return View();
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}