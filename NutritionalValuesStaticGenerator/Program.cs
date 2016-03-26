using NutritionalValuesStaticGenerator.Logic;
using System;
using System.IO;
using Web.Controllers;

namespace NutritionalValuesStaticGenerator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //string path = Path.Combine(Environment.CurrentDirectory, @"Data\", "NutritionalData.csv");
            //DataParser parser = new DataParser(path);
            //DetailsGenerator dg = new DetailsGenerator();
            //dg.Foo();

            RenderingController c = new RenderingController();
            c.Index();
        }
    }
}