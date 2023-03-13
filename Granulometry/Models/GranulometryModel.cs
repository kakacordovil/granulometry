using Syncfusion.Windows.Controls.RichTextBoxAdv;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

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
        /// Calculation of average granulometry
        /// (Cálculo da granulometria média)
        /// </summary>
        private double x50;
        public double X50
        {
            get { return x50; }
            set { x50 = value; OnPropertyChanged("X50"); }
        }
        #endregion

        #region double Xmax
        /// <summary>
        /// Maximum granulometry calculation
        /// (Cálculo da granulometria máxima)
        /// </summary>
        private double xmax;
        public double Xmax
        {
            get { return xmax; }
            set { xmax = value; OnPropertyChanged("Xmax"); }
        }
        #endregion

        #region double n
        /// <summary>
        /// The uniformity index calculation
        /// (Cálculo do índice de uniformidade)
        /// </summary>
        private double n;
        public double N
        {
            get { return n; }
            set { n = value; OnPropertyChanged("N"); }
        }
        #endregion

        #region double BRippleFactor
        /// <summary>
        /// The ripple factor calculation
        /// (Cálculo do fator de ondulação)
        /// </summary>
        private double bRippleFactor;
        public double BRippleFactor
        {
            get { return bRippleFactor; }
            set { bRippleFactor = value; OnPropertyChanged("BRippleFactor"); }
        }
        #endregion


        #region double GranulometricCurve
        /// <summary>
        /// The Granulometric Curve calculation, Swebrec
        /// (Cálculo da Curva Granolométrica, Swebrec
        /// </summary>
        /// 
        private List<double> granulometricCurve;
        public List<double> GranulometricCurve
        {
            get { return granulometricCurve;}           
            set { granulometricCurve = value; OnPropertyChanged("GranulometricCurve"); }
        }
        private double[] x;
        public double[] X
        {
            get { return x; }
            set { x = value; OnPropertyChanged("X"); }
        }

        private double[] sx;
        public double[] Sx
        {
            get { return sx; }  
            set { sx = value; OnPropertyChanged("Sx"); }
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

        #region double B
        /// <summary>
        /// Burden meter
        /// (Burden metro)
        /// </summary>
        private double b;
        public double B
        {
            get { return b; }
            set { b = value; OnPropertyChanged("B"); }
        }
        #endregion

        #region double S
        /// <summary>
        /// Spacing meters
        /// (Espaçamento metros)
        /// </summary>
        private double s;
        public double S
        {
            get { return s; }
            set { s = value; OnPropertyChanged("S"); }
        }
        #endregion

        #region double Density
        /// <summary>
        /// Density kg/m3
        /// (Densidade kg/m3)
        /// </summary>
        private double density;
        public double Density
        {
            get { return density; }
            set { density = value; OnPropertyChanged("Density"); }
        }
        #endregion

        #region double H
        /// <summary>
        /// Bench height meters
        /// (Altura da bancada metros)
        /// </summary>
        private double h;
        public double H
        {
            get { return h; }
            set { h = value; OnPropertyChanged("H"); }
        }
        #endregion

        #region double J
        /// <summary>
        /// Subdrilling meters
        /// ("Subperfuração" metros)
        /// </summary>
        private double j;
        public double J
        {
            get { return j; }
            set { j = value; OnPropertyChanged("J"); }
        }
        #endregion

        #region double T
        /// <summary>
        /// Stemming meters
        /// (Stemming of metros)
        /// </summary>
        private double t;
        public double T
        {
            get { return t; }
            set { t = value; OnPropertyChanged("T"); }
        }
        #endregion

        #region double d
        /// <summary>
        /// Diameter millimeters
        /// (Diametro milímetros)
        /// </summary>
        private double d;
        public double D
        {
            get { return d; }
            set { d = value; OnPropertyChanged("D"); }
        }
        #endregion

        #region double W
        /// <summary>
        /// Population standard deviation of drilling accuracy in toe meters
        /// (Desvio padrão populacional da precisão de perfuração no toe metros)
        /// </summary>
        private double w;
        public double W
        {
            get { return w; }
            set { w = value; OnPropertyChanged("W"); }
        }
        #endregion
        #endregion


    }
}
