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
using ChuiEeeJeek.Models.Resume;

namespace ChuiEeeJeek.Controllers
{
    public class ResumeController : Controller
    {
        public IActionResult Resume()
        {
            //ViewData["Message"] = "Your application description page.";
            ViewData["Message"] = "Submit Your Resume. Try!!";
            return View();
        }
        
        [HttpPost]
        public IActionResult Resume(FullResume model, char Separator)
        {
            //ViewData["Message"] = "Your application description page.";
            ViewData["Message"] = "Submitted!! You can get a result in Analysis Tab";
            int splitUnit = 5;
            if ( Separator.Equals(".")) {
                Separator = '.';
                splitUnit = 5;
            } else if ( Separator.Equals("blank")) {
                Separator = ' ';
                splitUnit = 30;
            } else {
                Separator = '\n';
                splitUnit = 5;
            }
            // int splitUnit = 30;
            String[] word = model.Context.Split(Separator);
            int wordLen = word.Length;
            int arrSize = wordLen/splitUnit+1;
            PartialResume[] wordArr = new PartialResume[arrSize];
            StringBuilder sb = null;
            for ( int i = 0 ; i < arrSize-1 ; i++ ) 
            {
                sb = new StringBuilder();
                for ( int j = i*splitUnit ; j < (i+1)*splitUnit ; j++ )
                {
                    sb.AppendLine(word[j]);
                }
                wordArr[i] = new PartialResume();
                wordArr[i].Context = sb.ToString();
                sb=null;
            }
            sb = new StringBuilder();
            for ( int i = (arrSize-1)*splitUnit ; i < wordLen ; i++ )
            {
                sb.AppendLine(word[i]);
            }
            wordArr[arrSize - 1] = new PartialResume();
            wordArr[arrSize - 1].Context = sb.ToString();
            sb=null;
            ViewBag.partialContext = wordArr;
            
            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
