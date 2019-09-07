using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChuiEeeJeek.Models;
using System.Net.Http;
using System.Text;
// Install Newtonsoft.Json with NuGet
using Newtonsoft.Json;

namespace ChuiEeeJeek.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Resume()
        {
            //ViewData["Message"] = "Your application description page.";
            ViewData["Message"] = "Submit Your Resume. Try!!";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
