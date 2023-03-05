using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using Granulometry.Models;
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
                LoadData();
            }
        }

        GranulometryService ObjGranulometryService;
        public GranulometryViewModel()
        {
            ObjGranulometryService = new GranulometryService();
        }

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
        private void CalculateX50(GranulometryModel objNewCalculationX50)
        {

        }
        //public double CalculateX50(GranulometryModel objNewCalculationX50)
    }
}
