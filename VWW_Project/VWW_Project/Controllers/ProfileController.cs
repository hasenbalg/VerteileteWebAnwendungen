using DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VWW_Project;
using VWW_Project.Controllers;
using VWW_Project.Models;

namespace VWW_Project.Controllers
{
    [Authorize]
    public class ProfileController : BaseDatabaseController
    {
        private UsersManager usersManager;
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public ProfileController()
        {
            this.usersManager = new UsersManager(this.Db);
        }

        public ProfileController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
            this.usersManager = new UsersManager(this.Db);
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }


        // GET: Profile
        public ActionResult Index(bool? changePasswordSuccess)
        {
            
            if (changePasswordSuccess != null)
            {
                if (changePasswordSuccess.Value)
                {
                    ViewBag.StatusMessage = "Passwort wurde erfolgreich geändert.";
                }
            }

            User user = this.usersManager.GetUserById(User.Identity.GetUserId());
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: /Manage/ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Manage/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = await UserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                return RedirectToAction("Index", "Profile", new { changePasswordSuccess = true });
            }
            AddErrors(result);
            return View(model);
        }

        //Helper
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}