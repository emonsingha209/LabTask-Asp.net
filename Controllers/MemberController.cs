using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LoginLabTask.Models;

namespace LoginLabTask.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(MemberModel memberModel)
        {
            MemberRepo memberRepo = new MemberRepo();

            bool isAuth = memberRepo.MemberLogin(memberModel);
            if (isAuth)
            {
                FormsAuthentication.SetAuthCookie(memberModel.UserName, false);
                return RedirectToAction("ShowEmployee", "Employee");
            }
            ModelState.AddModelError("", "Invalid username or password");
            return RedirectToAction("Login");
        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(MemberModel memberModel)
        {
            MemberRepo memberRepo = new MemberRepo();

            if (ModelState.IsValid)
            {
                var id = memberRepo.AddMember(memberModel);

                if (id > 0)
                {
                    ModelState.Clear();
                    ViewBag.Okay = "Member Added";
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}