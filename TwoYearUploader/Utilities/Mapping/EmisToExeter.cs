using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoYearUploader.Core;
using TwoYearUploader.Properties;

namespace TwoYearUploader.Utilities.Mapping
{
    public class EmisToExeter
    {

        public List<ModelExeter> ConvertEmisToExeter(List<ModelEmis> emisData)
        {
            string gpCode = Settings.Default.GPCode;
            string dataSource = Settings.Default.DataSource;
            string listDate = Settings.Default.ListDate;

            var exeterData = new List<ModelExeter>();

            emisData.ForEach(e =>
            {
                if (e.AsGMS5in1 != String.Empty)
                {
                    var exeterFiveInOne = new ModelExeter
                    {
                        GP_CODE = gpCode,
                        DATASOURCE = dataSource,
                        LIST_DATE = listDate,
                        IMMUNISATION_DATE = e.Date5in1.Value.ToString("dd" + "." + "MM" + "." + "yyyy"),
                        IMMUNISATION_TYPE = Enums.ImmunisationType.FIVE_IN_ONE.ToString(),
                        NHS_NUMBER = e.NHSNumber.Replace(" ",""),
                        IMMUNISATION_UNDER_GMS = e.AsGMS5in1 == "True" ? "Y" : "N"
                    };
                    exeterData.Add(exeterFiveInOne);
                }

                if (e.AsGMSMenC != String.Empty)
                {
                    var exeterMenC = new ModelExeter
                    {
                        GP_CODE = gpCode,
                        DATASOURCE = dataSource,
                        LIST_DATE = listDate,
                        IMMUNISATION_DATE = e.DateMenC.Value.ToString("dd" + "." + "MM" + "." + "yyyy"),
                        IMMUNISATION_TYPE = Enums.ImmunisationType.MENC.ToString(),
                        NHS_NUMBER = e.NHSNumber.Replace(" ", ""),
                        IMMUNISATION_UNDER_GMS = e.AsGMSMenC == "True" ? "Y" : "N"
                    };
                    exeterData.Add(exeterMenC);
                }

                if (e.AsGMSMMR != String.Empty)
                {
                    var exeterMMR = new ModelExeter
                    {
                        GP_CODE = gpCode,
                        DATASOURCE = dataSource,
                        LIST_DATE = listDate,
                        IMMUNISATION_DATE = e.DateMMR.Value.ToString("dd" + "." + "MM" + "." + "yyyy"),
                        IMMUNISATION_TYPE = Enums.ImmunisationType.MMR.ToString(),
                        NHS_NUMBER = e.NHSNumber.Replace(" ", ""),
                        IMMUNISATION_UNDER_GMS = e.AsGMSMMR == "True" ? "Y" : "N"
                    };
                    exeterData.Add(exeterMMR);
                }

            });

            return exeterData.Where(e=>e.IMMUNISATION_UNDER_GMS!=null).ToList();

        }
    }
}
