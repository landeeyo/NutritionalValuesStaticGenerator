﻿
namespace Web.Models
{
    public class DetailsModel
    {
        public string Name { get; set; }

        public double Calories { get; set; }

        public double? Protein { get; set; }

        public double? Carbohydrate { get; set; }

        public double? Fiber { get; set; }

        public double? Sugar { get; set; }

        public double? Fat { get; set; }

        public string NormalizedName { get { return NormalizeFilename(Name); } }

        private static string NormalizeFilename(string fileName)
        {
            return fileName.Replace("\\", "_").Replace("/", "_").Replace(",", "_");
        }
    }
}