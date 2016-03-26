using NutritionalValuesStaticGenerator.Logic;
using System;
using System.Collections.Generic;
using System.IO;
using Web.Controllers;
using Web.Models;

namespace NutritionalValuesStaticGenerator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            RenderingController c = new RenderingController();
            string destination = "C:\\Result\\";
            Directory.CreateDirectory(destination);
            string bootstrapCss = Path.Combine(Environment.CurrentDirectory, @"Data\css", "bootstrap.min.css");
            string bootstrapJs = Path.Combine(Environment.CurrentDirectory, @"Data\js", "bootstrap.min.js");
            string jqueryJs = Path.Combine(Environment.CurrentDirectory, @"Data\js", "jquery.min.js");
            File.Copy(bootstrapCss, destination + "bootstrap.min.css", true);
            File.Copy(bootstrapJs, destination + "bootstrap.min.js", true);
            File.Copy(jqueryJs, destination + "jquery.min.js", true);

            string path = Path.Combine(Environment.CurrentDirectory, @"Data\", "NutritionalData.csv");
            DataParser dp = new DataParser(path);

            #region Render index

            var listModel = new ListModel();
            listModel.Items = new List<DetailsModel>();

            int i = 0;
            foreach (var item in dp.Items)
            {
                i++;
                if (i > 10) { break; }
                DetailsModel detailsModel = new DetailsModel
                {
                    Name = item.Name,
                    Calories = item.Calories
                };
                listModel.Items.Add(detailsModel);
            }

            string index = c.Index(listModel);
            WriteToFile(index, "Index.html");

            #endregion
            #region Render  detail items

           
            i = 0;
            foreach (var item in dp.Items)
            {
                i++;
                if (i > 10) { break; }
                DetailsModel detailsModel = new DetailsModel
                {
                    Name = item.Name,
                    Calories = item.Calories
                };
                string details = c.Details(detailsModel);
                WriteToFile(details, string.Format("details_{0}.html", item.Name));
            }

            #endregion
        }

        private static string NormalizeFilename(string fileName)
        {
            return fileName.Replace("\\", "_").Replace("/", "_").Replace(",", "_");
        }

        private static void WriteToFile(string source, string fileName)
        {
            var file = File.Create("C:\\Result\\" + NormalizeFilename(fileName));
            var sw = new StreamWriter(file);
            sw.WriteLine(source);
            file.Close();
        }
    }
}