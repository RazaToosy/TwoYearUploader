using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration.Attributes;

namespace TwoYearUploader.Core
{
    public class ModelEmis
    {
        [Index(0)]
        public string FullName { get; set; }
        [Index(1)]
        public DateTime? DOB { get; set; }
        [Index(2)]
        public string NHSNumber { get; set; }
        [Index(3)]
        public string UsualGP { get; set; }
        [Index(4)]
        public DateTime? Date5in1 { get; set; }
        [Index(5)]
        public string AsGMS5in1 { get; set; }
        [Index(6)]
        public DateTime? DateMenC { get; set; }
        [Index(7)]
        public string AsGMSMenC { get; set; }
        [Index(8)]
        public DateTime? DateMMR { get; set; }
        [Index(9)]
        public string AsGMSMMR { get; set; }
    }
}
