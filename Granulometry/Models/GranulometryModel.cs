using System.ComponentModel;

namespace Granulometry.Models
{
    public class GranulometryModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler ?PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #region Prediction
        #region double X50
        /// <summary>
        /// Rock Factor. 
        /// (Fator de Rocha)
        /// </summary>
        private double x50;
        public double X50
        {
            get { return x50; }
            set { x50 = value; OnPropertyChanged("X50"); }
        }
        #endregion
        #endregion

        #region Calculation
        #region double A
        /// <summary>
        /// Rock Factor. 
        /// (Fator de Rocha)
        /// </summary>
        private double a;
        public double A 
        { 
            get { return a; } 
            set { a = value; OnPropertyChanged("A"); } 
        }
        #endregion

        #region double K
        /// <summary>
        /// Powder Factor (kg/m3).
        /// </summary>
        private double k;
        public double K
        {
            get { return k; }
            set { k = value; OnPropertyChanged("K"); }
        }
        #endregion

        #region double Q
        /// <summary>
        /// Mass corresponding to the amount of explosive per hole (kg).
        /// (Massa correspondente à quantidade de explosivo por furo (kg) )
        /// </summary>
        private double q;
        public double Q
        {
            get { return q; }
            set { q = value; OnPropertyChanged("Q"); }
        }
        #endregion

        #region double RWS
        /// <summary>
        /// Relative mass energy of explosive compared to pure ANFO(explosive).
        /// (Energia relativa em massa do explosivo em comparação com o ANFO(explosivo) puro)
        /// </summary>
        private double rws;
        public double RWS
        {
            get { return rws; }
            set { rws = value; OnPropertyChanged("RWS"); }
        }
        #endregion
        #endregion

        #region Geometrical Parameters
        #region double A
        /// <summary>
        /// Rock Factor. 
        /// (Fator de Rocha)
        /// </summary>
        //private double ex1;
        //public double Ex1
        //{
        //    get { return a; }
        //    set { a = value; OnPropertyChanged("A"); }
        //}
        #endregion

        #region double K
        /// <summary>
        /// Powder Factor (kg/m3).
        /// </summary>
        //private double ex2;
        //public double Ex2
        //{
        //    get { return k; }
        //    set { k = value; OnPropertyChanged("K"); }
        //}              
        #endregion
        #endregion
    }
}
