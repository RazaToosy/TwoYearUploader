using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoYearUploader.Core;
using TwoYearUploader.Properties;
using TwoYearUploader.Utilities.IO;
using TwoYearUploader.Utilities.Mapping;

namespace TwoYearUploader.Utilities.Data
{
    public class Repo
    {

        private List<ModelExeter> _exeterData;

        public Repo()
        {
            GetData();
        }

        public List<ModelExeter> ExeterData
        {
            get { return _exeterData; }
        }

        private void GetData()
        {
            IImportData<ModelEmis> importData = new ImportCSV();
            var _emisData = new List<ModelEmis>(importData.FetchList(Settings.Default.LocationOfEmisFile));

            _exeterData = new EmisToExeter().ConvertEmisToExeter(_emisData);

        }
    }
}
