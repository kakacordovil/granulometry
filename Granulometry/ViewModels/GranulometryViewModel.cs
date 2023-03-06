using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using Granulometry.Models;
using Granulometry.Commands;

namespace Granulometry.ViewModels
{
    public class GranulometryViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        GranulometryService ObjGranulometryService;
        public GranulometryViewModel()
        {
            ObjGranulometryService = new GranulometryService();               
            LoadData();
            GranulometryData = new GranulometryModel();
            saveCommand = new RelayCommand(Save);
        }

        #region Display
        private List<GranulometryModel> granulometriesList;

        public List<GranulometryModel> GranulometriesList 
        {
            get { return granulometriesList; }
            set { granulometriesList = value; OnPropertyChanged("GranulometriesList"); }
        }

        private void LoadData()
        {
            GranulometriesList = ObjGranulometryService.GetAll();

        }
        #endregion

        #region Operations
        public double CalculateX50(GranulometryModel objNewCalculationX50)
        {
            return ObjGranulometryService.CalculateX50(objNewCalculationX50);
        }

        public double CalculateX20(GranulometryModel objNewCalculationX20)
        {
            return ObjGranulometryService.CalculateX50(objNewCalculationX20);
        }
        #endregion

        private GranulometryModel granulometryData;
        public GranulometryModel GranulometryData
        {
            get { return granulometryData; }
            set { granulometryData = value; OnPropertyChanged("GranulometryData"); }
        }

        private string message;
        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message");}
        }
        private RelayCommand saveCommand;

        public RelayCommand SaveCommand
        {
            get { return saveCommand; }
        }

        public void Save()
        {
            try
            {
                var IsSaved = ObjGranulometryService.Add(GranulometryData);
                LoadData();
                if (IsSaved)
                {
                    Message = "Saved";
                } else
                {
                    Message = "Save Failed";
                }
            }
            catch (Exception ex)
            {
                Message= ex.Message;
            }
        }
        


    }
}
