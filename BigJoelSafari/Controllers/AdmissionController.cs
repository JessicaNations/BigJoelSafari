﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BigJoelSafari.Models;
using System;

namespace BigJoelSafari.Controllers
{
    public class AdmissionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Single()
        {
            return View();
        }

        public IActionResult ThreeGroup()
        {
            return View();
        }

        public IActionResult FourGroup()
        {
            return View();
        }
    }
}
