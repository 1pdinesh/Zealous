﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zealous.Models;

namespace Zealous.Controllers
{
    public class SupplierController : ZealousController
    {
        // GET: Supplier
        [HttpGet]
        [Authorize]
        public ActionResult Status()
        {
            return View();
        }
        public ActionResult AddStatus(Add s)
        {
            return View();
        }
        public ActionResult UpdateStatus(Upd s)
        {
            return View();
        }
    }
}