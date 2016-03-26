using NutritionalValuesStaticGenerator.Data;
using System;
using System.Collections.Generic;
using System.IO;

namespace NutritionalValuesStaticGenerator.Logic
{
    public class DataParser
    {
        public List<NutritionalDataItem> Items;

        public DataParser(string path)
        {
            Items = new List<NutritionalDataItem>();
            FileStream fileStream = File.OpenRead(path);
            StreamReader streamReader = new StreamReader(fileStream);
            while (!streamReader.EndOfStream)
            {
                var line = streamReader.ReadLine();
                var firstSplit = line.Split('"');
                var secondSplit = firstSplit[firstSplit.Length - 1].Split(';');
                var item = new NutritionalDataItem
                {
                    //Name = csv[0],//.Remove('\\'),
                    Name = firstSplit[1][0] + firstSplit[1].ToLower().Substring(1),
                    Calories = Convert.ToDouble(secondSplit[1].Replace('.', ',')),

                };
                if (secondSplit[2].Length > 0)
                {
                    item.Protein = Convert.ToDouble(secondSplit[2].Replace('.', ','));
                }
                if (secondSplit[3].Length > 0)
                {
                    item.Carbohydrate = Convert.ToDouble(secondSplit[3].Replace('.', ','));
                }
                if (secondSplit[4].Length > 0)
                {
                    item.Fiber = Convert.ToDouble(secondSplit[4].Replace('.', ','));
                }
                if (secondSplit[5].Length > 0)
                {
                    item.Sugar = Convert.ToDouble(secondSplit[5].Replace('.', ','));
                }
                if (secondSplit[6].Length > 0)
                {
                    item.Fat = Convert.ToDouble(secondSplit[6].Replace('.', ','));
                }
                Items.Add(item);
            }
        }
    }
}