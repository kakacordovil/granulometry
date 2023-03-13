using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using Granulometry.Models;
using Granulometry.Commands;
using System.Collections.ObjectModel;

namespace Granulometry.ViewModels
{
    public class GranulometryViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged_Implementation
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        GranulometryService ObjGranulometryService;
        public GranulometryViewModel()
        {
            ObjGranulometryService = new GranulometryService();               
            LoadData();
            GranulometryCurrentData = new GranulometryModel();
            saveCommand = new RelayCommand(Save);
        }

        #region Display
        private ObservableCollection<GranulometryModel> granulometriesList;

        public ObservableCollection<GranulometryModel> GranulometriesList
        {
            get { return granulometriesList; }
            set { granulometriesList = value; OnPropertyChanged("GranulometriesList"); }
        }


        private GranulometryModel granulometryCurrentData;
        public GranulometryModel GranulometryCurrentData
        {
            get { return granulometryCurrentData; }
            set { granulometryCurrentData = value; OnPropertyChanged("GranulometryCurrentData"); }
        }

        private void LoadData()
        {
            GranulometriesList = new ObservableCollection<GranulometryModel>(ObjGranulometryService.GetAll());

        }
        #endregion

        #region Operations
        //public double CalculateX50(double A, double K, double Q, double RWS)
        //{
        //    return ObjGranulometryService.CalculateX50(A, K, Q, RWS);
        //}

        //public double CalculateX20(double A, double K, double Q, double RWS)
        //{
        //    return ObjGranulometryService.CalculateX50(A, K, Q, RWS);
        //}
        


        private string message;
        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message");}
        }

        private double x50;
        public double X50
        {
            get { return x50; }
            set { x50 = value; OnPropertyChanged("X50"); }
        }

        private double xmax;
        public double Xmax
        {
            get { return xmax; }
            set { xmax = value; OnPropertyChanged("Xmax"); }
        }

        private double n;
        public double N
        {
            get { return n; }
            set { n = value; OnPropertyChanged("N"); }
        }

        private double bRippleFactor;
        public double BRippleFactor
        {
            get { return bRippleFactor; }
            set { bRippleFactor = value; OnPropertyChanged("BRippleFactor"); }
        }

        //private List<double> granulometricCurve;
        //public List<double> GranulometricCurve
        //{
        //    get { return granulometricCurve; }
        //    set { granulometricCurve = value; OnPropertyChanged("GranulometricCurve"); }
        //}

        private double[] sx;
        public double[] Sx
        {
            get { return sx; }
            set { sx = value; OnPropertyChanged("Sx"); }
        }
        private double[] x;
        public double[] X
        {
            get { return x; }
            set { x = value; OnPropertyChanged("X"); }
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
                var IsSaved = ObjGranulometryService.Add(GranulometryCurrentData);
                LoadData();
                if (IsSaved)
                {
                    Message = "Saved";
                    X50 = GranulometryCurrentData.X50;
                    Xmax = GranulometryCurrentData.Xmax;
                    N = GranulometryCurrentData.N;
                    BRippleFactor = granulometryCurrentData.BRippleFactor;
                    Sx = granulometryCurrentData.Sx;
                    X = granulometryCurrentData.X;

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
        #endregion


    }
}
