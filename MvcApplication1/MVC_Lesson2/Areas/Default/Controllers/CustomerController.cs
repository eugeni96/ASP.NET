﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Lesson2.Models.Info;

namespace MVC_Lesson2.Areas.Default.Controllers
{
    public class CustomerController : DefaultController
    {
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(new Customer()
            {
                Ownerships = new Dictionary<string, Ownership>()
            });
        }
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
            }
            return View(customer);
        }

        public ActionResult AddOwnership()
        {
            return View("OwnershipItem", new KeyValuePair<string, Ownership>(
                Guid.NewGuid().ToString("N"),
                new Ownership()));
        }
    }
}
