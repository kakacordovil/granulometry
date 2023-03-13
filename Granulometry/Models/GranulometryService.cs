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
    public class GranulometryService
    {
        private static List<GranulometryModel> ?ObjGranulometrysList;
        public GranulometryService()
        {
            ObjGranulometrysList = new List<GranulometryModel>()
            {
                new GranulometryModel{A=15.42, K=0.61, Q=73.42, RWS=115},
                new GranulometryModel{}
            };
        }

        #region CalculateX50(double A, double K, double Q, double RWS)
        public double CalculateX50(double A, double K, double Q, double RWS)
        {
            //Must have the A, K, Q and RWS 
            if (A == 0 ||
                K == 0 ||
                Q == 0 ||
                RWS == 0)
            {
                throw new ArgumentException("Insert the data for A, K, Q and RWS.");
            }
            GranulometryModel objNewCalculationX50 = new GranulometryModel { A = A, K = K, Q = Q, RWS = RWS };

            double X50 = 10 * A * Math.Pow(K, -0.8) * Math.Pow(Q, 1.0 / 6.0) * Math.Pow(115 / RWS, 19.0 / 30.0);

           
            objNewCalculationX50.X50= X50;

            ObjGranulometrysList.Add(objNewCalculationX50);
            return X50;
        }
        #endregion

        #region CalculateXmax(double B, double S)
        public double CalculateXmax(double B, double S)
        {
            //Must have B and S 
            if (B == 0 || S == 0 )
            {
                throw new ArgumentException("Insert the data for B and S.");
            }
            GranulometryModel objNewCalculationXMAX = new GranulometryModel { B = B, S = S };
 
            double Xmax = (B + S) / 2;
            Xmax = Xmax * 1000; //xmax meters to millimeters converter

            objNewCalculationXMAX.Xmax = Xmax;
            ObjGranulometrysList.Add(objNewCalculationXMAX);
            return Xmax;
        }
        #endregion

        #region CalculateN(double B, double S)
        public double CalculateN(double H, double J, double T, double B, double D, double S, double W)
        {
            
            GranulometryModel objNewCalculationN = new GranulometryModel { H = H, J = J, T = T };

            double L = H + J - T;
            double LB = L * 0.7;
            double LC = L * 0.3;
            double n = (2.2 - 14 * (B / D)) * Math.Sqrt((1 + (S / B)) / 2) * (1 - (W / B)) * Math.Pow((Math.Abs(LB - LC) / L + 0.1), 0.1) * L / H;

            objNewCalculationN.N = n;
            ObjGranulometrysList.Add(objNewCalculationN);
            return n;
        }
        #endregion

        #region CalculatebRippleFactor(double xmax, double x50, double n)
        public double CalculatebRippleFactor(double xmax, double x50, double n)
        {
            //Must have xmax, x50 and n
            if (xmax == 0 || x50 == 0 || n == 0)
            {
                throw new ArgumentException("Insert the data for Xmax, X50 and W.");
            }
            GranulometryModel objNewCalculationbRippleFactor = new GranulometryModel { Xmax = xmax, X50 = x50, N = n };

            double b = (2 * Math.Log(2) * Math.Log(xmax / x50)) * n;

            objNewCalculationbRippleFactor.BRippleFactor = b;
            ObjGranulometrysList.Add(objNewCalculationbRippleFactor);
            return n;
        }
        #endregion


        #region CalculateGranulometricCurve(double xmax, double x50, double bRippleFactor)
        public (double[],double[]) CalculateGranulometricCurve(double xmax, double x50, double bRippleFactor)
        {

            GranulometryModel objNewCalculationGranulometricCurve = new GranulometryModel { Xmax = xmax, X50 = x50, BRippleFactor = bRippleFactor };

            //List<double> data = new List<double>();
            //for (double sx = 0.01; sx <= 1; sx += 0.01)
            //{
            //    objNewCalculationGranulometricCurve.Sx= sx;
            //    double x = Math.Pow(x50, 1 / (1 - 1 / sx)) * Math.Pow(xmax, 1 - 1 / (1 - 1 / sx));
            //    objNewCalculationGranulometricCurve.X= x;
            //    data.Add(x);
            //}
            double[] Sx = Enumerable.Range(1, 100).Select(p => p / 100.0).ToArray();

            double[] X = Sx.Select(p => Math.Pow(x50, 1 / Math.Pow(1 / p - 1, bRippleFactor)) * Math.Pow(xmax, 1 - 1 / Math.Pow(1 / p - 1, bRippleFactor))).ToArray();
            var data = Sx.Zip(X, (s, x) => new { Sx = s, X = x });
            objNewCalculationGranulometricCurve.Sx = Sx;
            objNewCalculationGranulometricCurve.X= X;   
            ObjGranulometrysList.Add(objNewCalculationGranulometricCurve);
            return (Sx, X);
           
        }
        #endregion

        #region Method to get all the granulometry calculation results
        public List<GranulometryModel> GetAll()
        {
            return ObjGranulometrysList;
        }
        #endregion

        #region Method to add the granulometry calculation
        public bool Add(GranulometryModel objNewCalculation)
        {
            //Must have the A, K, Q and RWS 
            if(objNewCalculation.A == 0 || 
               objNewCalculation.K == 0 || 
               objNewCalculation.Q == 0 || 
               objNewCalculation.RWS == 0)
            {
                throw new ArgumentException("Insert the data for A, K, Q and RWS.");
            }
            double a = objNewCalculation.A;
            double k = objNewCalculation.K;
            double q = objNewCalculation.Q;
            double rws = objNewCalculation.RWS;
            double s = objNewCalculation.S;  
            double b = objNewCalculation.B;
            double h = objNewCalculation.H;
            double j = objNewCalculation.J;
            double t = objNewCalculation.T;
            double d = objNewCalculation.D;
            double w = objNewCalculation.W;



            objNewCalculation.X50 = CalculateX50(a, k, q, rws);
            objNewCalculation.Xmax = CalculateXmax(s, b);
            objNewCalculation.N = CalculateN(h, j, t, b, d, s, w);

            double x50 = objNewCalculation.X50;
            double xmax = objNewCalculation.Xmax;
            double n = objNewCalculation.N;

            objNewCalculation.BRippleFactor = CalculatebRippleFactor(x50, xmax, n);

            double bRippleFactor = objNewCalculation.BRippleFactor;

            CalculateGranulometricCurve(xmax, x50, bRippleFactor);

            ObjGranulometrysList.Add(objNewCalculation);

            return true;
        }
        #endregion


    }
}
