﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Food.lib.Models;
using Food.lib.Objects;
namespace WebApplication.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {

        // GET: Admin/Admin
        public ActionResult Index()
        {
            return View();
        }
      
    }
}