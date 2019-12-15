using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration.Attributes;

namespace TwoYearUploader.Core
{
    public class ModelExeter
    {
        [Index(0)]
        public string GP_CODE { get; set; }

        [Index(1)]
        public string IMMUNISATION_TYPE { get; set; }

        [Index(2)]
        public string LIST_DATE { get; set; }

        [Index(3)]
        public string IMMUNISATION_DATE { get; set; }

        [Index(4)]
        public string DATASOURCE { get; set; }

        [Index(5)]
        public string NHS_NUMBER { get; set; }

        [Index(6)]
        public string IMMUNISATION_UNDER_GMS { get; set; }
    }
}
