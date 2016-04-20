﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;




namespace WebApplication1.Controllers
{

    public class HomeController : Controller
    {

        public ActionResult Index()
        {
           /** using (var context = new ApplicationDbContext())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                roleManager.Create(new IdentityRole("Admin"));

                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);

                var user = userManager.FindByEmail("cikku@hotmail.com");
                userManager.AddToRole(user.Id, "Admin");
                context.SaveChanges();
            }**/
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


    }
}