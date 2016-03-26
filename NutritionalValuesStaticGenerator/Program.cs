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
            //YES
            //I know this code is ugly as fuck
            //But I'm angry because I need to write it
            //because google crawler is so stuped
            //it can't by default index properly angular pages
            //and my whole pretty and posh angular web is now worth shit
            //and I'm in a big rush to make this work so
            //it's not clean code
            //it's big ball of mud
            //it's spaghetti
            //and it's not my last word! ;-)

            RenderingController c = new RenderingController();
            string destination = "C:\\Result\\";
            Directory.CreateDirectory(destination);

            string bannerCss = Path.Combine(Environment.CurrentDirectory, @"Data\css", "basic-js-cookie-banner.min.css");
            string bootstrapCss = Path.Combine(Environment.CurrentDirectory, @"Data\css", "bootstrap.min.css");
            string bootstrapJs = Path.Combine(Environment.CurrentDirectory, @"Data\js", "bootstrap.min.js");
            string jqueryJs = Path.Combine(Environment.CurrentDirectory, @"Data\js", "jquery.min.js");
            string bannerJs = Path.Combine(Environment.CurrentDirectory, @"Data\js", "basic-js-cookie-banner.js");
            File.Copy(bannerCss, destination + "basic-js-cookie-banner.min.css", true);
            File.Copy(bootstrapCss, destination + "bootstrap.min.css", true);
            File.Copy(bootstrapJs, destination + "bootstrap.min.js", true);
            File.Copy(jqueryJs, destination + "jquery.min.js", true);
            File.Copy(bannerJs, destination + "basic-js-cookie-banner.js", true);

            string path = Path.Combine(Environment.CurrentDirectory, @"Data\", "NutritionalData.csv");
            DataParser dp = new DataParser(path);

            #region Render index

            var listModel = new ListModel();
            listModel.Items = new List<DetailsModel>();

            //int i = 0;
            foreach (var item in dp.Items)
            {
                //i++;
                //if (i > 10) { break; }
                DetailsModel detailsModel = new DetailsModel
                {
                    Name = item.Name,
                    Calories = item.Calories,
                    Carbohydrate = item.Carbohydrate,
                    Fat = item.Fat,
                    Fiber = item.Fiber,
                    Protein = item.Protein,
                    Sugar = item.Sugar

                };
                listModel.Items.Add(detailsModel);
            }

            string index = c.Index(listModel);
            WriteToFile(index, "Index.html");

            #endregion

            #region Render about

            string about = c.About();
            WriteToFile(about, "About.html");

            #endregion

            #region Render  detail items
           
            //i = 0;
            foreach (var item in dp.Items)
            {
                //i++;
                //if (i > 10) { break; }
                DetailsModel detailsModel = new DetailsModel
                {
                    Name = item.Name,
                    Calories = item.Calories,
                    Carbohydrate = item.Carbohydrate,
                    Fat = item.Fat,
                    Fiber = item.Fiber,
                    Protein = item.Protein,
                    Sugar = item.Sugar
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