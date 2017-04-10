using Microsoft.AspNet.Identity;
using PHT.Models.PhtModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PHT.Controllers
{
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult CreateTeam()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateTeam(PloegViewModel model)
        {
            if (ModelState.IsValid)
            {
                var ploeg = new Ploeg { Naam = model.Naam, PintenAantal = model.PintenAantal };
   
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}