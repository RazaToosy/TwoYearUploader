using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using TwoYearUploader.Core;
using TwoYearUploader.Properties;

namespace TwoYearUploader.Utilities.IO
{
    public class ImportCSV : IImportData<ModelEmis>
    {
        public IList<ModelEmis> FetchList(string FileName)
        {

            var emisData = new List<ModelEmis>();

            using (var reader = new StreamReader(Settings.Default.LocationOfEmisFile))
            using (var csv = new CsvReader(reader))
            {
                csv.Configuration.CultureInfo = new CultureInfo("en-GB");
                emisData = csv.GetRecords<ModelEmis>().Where(e => e.FullName != null).ToList();
            }

            return emisData;

        }
    }
}
