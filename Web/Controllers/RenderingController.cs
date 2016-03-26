using RazorEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class RenderingController : Controller
    {
        //
        // GET: /Rendering/

        public void Index()
        {
            string path = Path.Combine(Environment.CurrentDirectory, @"Views\", "Details.cshtml");

            FileStream fileStream = System.IO.File.OpenRead(path);
            StreamReader streamReader = new StreamReader(fileStream);
            StringBuilder sb = new StringBuilder();
            while (!streamReader.EndOfStream)
            {
                sb.Append(streamReader.ReadLine()+"\n");
            }
            var result = Razor.Parse(sb.ToString(), new Web.Models.DetailsModel { Name = "Test", Calories = 666 } );

        }

    }
}
