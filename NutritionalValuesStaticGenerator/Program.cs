using NutritionalValuesStaticGenerator.Logic;
using System;
using System.IO;

namespace NutritionalValuesStaticGenerator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string path = Path.Combine(Environment.CurrentDirectory, @"Data\", "NutritionalData.csv");
            DataParser parser = new DataParser(path);
        }
    }
}