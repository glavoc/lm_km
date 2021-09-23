using CsvHelper;
using CsvHelper.Configuration;
using FileHelpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace lm_km.core
{
    /// <summary>
    /// Helper class to read & write .CSV file.
    /// </summary>
    public static class CSV_Helper
    {
        public static void WriteCSVFile(List<Keynote> dataSource, string path)
        {
            try
            {
                //filehelper object
                FileHelperEngine engine = new FileHelperEngine(typeof(Keynote));
                //csv object
                List<Keynote> csv = new List<Keynote>();
                //convert any datasource to csv based object

                foreach (var item in dataSource)
                {
                    Keynote temp = new Keynote();
                    temp.Category = item.Category;
                    temp.Text = item.Text;
                    temp.Parent = item.Parent;
                    csv.Add(temp);
                }
                //save file locally
                engine.WriteFile(path, csv);
            }
            catch (Exception ex)
            {
            }
        }

        public static List<Keynote> ReadCSVFile(string path)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
                Delimiter = "\t",
                MissingFieldFound = null,
            };
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, config))
            {
                var records = csv.GetRecords<Keynote>();
                return records.ToList();
            }
        }
    }
}