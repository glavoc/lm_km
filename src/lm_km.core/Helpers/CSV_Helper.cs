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
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = false,
                    Delimiter = "\t",
                };
                using (var writer = new StreamWriter(path))
                using (var csv = new CsvWriter(writer, config))
                {
                    csv.WriteRecords(dataSource);
                }
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