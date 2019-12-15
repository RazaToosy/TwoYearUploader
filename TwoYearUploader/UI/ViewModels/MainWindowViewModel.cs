using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Animation;
using Microsoft.Win32;
using TwoYearUploader.Annotations;
using TwoYearUploader.Properties;
using TwoYearUploader.Utilities.Commands;
using TwoYearUploader.Utilities.Data;
using TwoYearUploader.Utilities.IO;
using TwoYearUploader.Utilities.Mapping;

namespace TwoYearUploader.UI.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _gPCode;
        private string _dataSource;
        private string _locationOfExportFile;
        private bool _enableButton;
        private string _listDate;

        public ICommand ExportCommand { get; set; }
        public ICommand FindCommand { get; set; }

        public MainWindowViewModel()
        {
            ExportCommand = new ButtonCommand(exportData, canExportData);
            FindCommand = new ButtonCommand(findFile, canFindFile);
            GPCode = Settings.Default.GPCode;
            DataSource = Settings.Default.DataSource;
            LocationOfExportFile = Settings.Default.LocationOfEmisFile;
            ListDate = Settings.Default.ListDate;
            EnableButton = false;
        }

        public string GPCode
        {
            get { return _gPCode; }
            set
            {
                _gPCode = value;
                RaisePropertyChanged("GPCode");
            }
        }

        public string DataSource
        {
            get { return _dataSource; }
            set
            {
                _dataSource = value;
                RaisePropertyChanged("DataSource");
            }
        }

        public string LocationOfExportFile
        {
            get { return _locationOfExportFile; }
            set
            {
                _locationOfExportFile = value;
                RaisePropertyChanged("LocationOfExportFile");
            }
        }

        public string ListDate
        {
            get { return _listDate; }
            set
            {
                _listDate = value;
                RaisePropertyChanged("ListDate");
            }
        }

        public bool EnableButton
        {
            get { return _enableButton; }
            set
            {
                _enableButton = value;
                RaisePropertyChanged("EnableButton");
            }
        }


        private bool canExportData(object obj)
        {
            return true;
        }

        private async void exportData(object data)
        {
            Settings.Default.GPCode = _gPCode;
            Settings.Default.DataSource = _dataSource;
            Settings.Default.ListDate = _listDate;
            await Task.Run(() =>
            {
                var repo = new Repo();
                new ExportCSV(repo.ExeterData);
            });
        }

        private bool canFindFile(object obj)
        {
            return true;
        }

        private void findFile(object data)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.DefaultExt = ".csv";
            openDialog.Filter = "Csv Files (.csv)|*.csv";
            Nullable<bool> result = openDialog.ShowDialog();
            if (result == true)
            {
                LocationOfExportFile = openDialog.FileName;
                Settings.Default.LocationOfEmisFile = openDialog.FileName;
                if (GPCode != string.Empty) EnableButton = true;

            }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }



    }
}
