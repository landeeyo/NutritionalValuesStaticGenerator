using RazorEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalValuesStaticGenerator.Logic
{
    public class DetailsGenerator
    {
        public void Foo()
        {
            string path = Path.Combine(Environment.CurrentDirectory, @"Data\", "details.cshtml");
            
            FileStream fileStream = File.OpenRead(path);
            StreamReader streamReader = new StreamReader(fileStream);
            StringBuilder sb = new StringBuilder();
            while (!streamReader.EndOfStream)
            {
                sb.Append(streamReader.ReadLine());
            }
            //var result = Razor.Parse(sb.ToString(), new DetailsModel());
        }
    }
}
