using RazorEngine;
using System;
using System.IO;
using System.Text;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class RenderingController : Controller
    {
        public string Index(ListModel listModel)
        {
            var view = GetView("Index.cshtml");
            var result = Razor.Parse(view, listModel);
            return result;
        }

        public string Details(DetailsModel model)
        {
            var result = Razor.Parse(GetView("Details.cshtml"), model);
            return result;
        }

        private string GetView(string viewName)
        {
            string path = Path.Combine(Environment.CurrentDirectory, @"Views\", viewName);

            FileStream fileStream = System.IO.File.OpenRead(path);
            StreamReader streamReader = new StreamReader(fileStream);
            StringBuilder sb = new StringBuilder();
            while (!streamReader.EndOfStream)
            {
                sb.Append(streamReader.ReadLine() + "\n");
            }
            return sb.ToString();
        }
    }
}