using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static AspNetIdentity.ApplicationUserStore;
using static AspNetIdentity.Models.IdentityModels;

namespace AspNetIdentity.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Register()
        {
            ApplicationUser user = new ApplicationUser { UserName="Sumit",Email="Sumit@gmail.com"};
            ApplicationUserStore store = new ApplicationUserStore(new ApplicationDbContext());
            ApplicationUserManager manager = new ApplicationUserManager(store);

           var Result= await manager.CreateAsync(user);
            if(Result.Succeeded)
            {
                return Content("User Created Successfully");
            }
            AddErrors(Result);
            return View();
        }

        private void AddErrors(Microsoft.AspNet.Identity.IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}