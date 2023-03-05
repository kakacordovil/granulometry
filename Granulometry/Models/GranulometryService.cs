using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Granulometry.Models
{
    public class GranulometryService
    {
        private static List<GranulometryModel> ObjGranulometrysList;
        public GranulometryService()
        {
            ObjGranulometrysList = new List<GranulometryModel>()
            {
                new GranulometryModel{A=15.42, K=0.61, Q=73.42, RWS=115}
            };
        }

        public double CalculateX50(GranulometryModel objNewCalculationX50)
        {
            //Must have the A, K, Q and RWS 
            if (objNewCalculationX50.A == 0 ||
               objNewCalculationX50.K == 0 ||
               objNewCalculationX50.Q == 0 ||
               objNewCalculationX50.RWS == 0)
            {
                throw new ArgumentException("Insert the data for A, K, Q and RWS.");
            }
                        double A = objNewCalculationX50.A;
            double K = objNewCalculationX50.K;
            double Q = objNewCalculationX50.Q;
            double RWS = objNewCalculationX50.RWS;
            double X50 = 10 * A * Math.Pow(K, -0.8) * Math.Pow(Q, 1.0 / 6.0) * Math.Pow(115 / RWS, 19.0 / 30.0);

            objNewCalculationX50.X50 = X50;

            ObjGranulometrysList.Add(objNewCalculationX50);
            return X50;
        }
      

        //Method to get all the granulometry calculation results
        public List<GranulometryModel> GetAll()
        {
            return ObjGranulometrysList;
        }

        //Method to add the granulometry calculation
        public bool Add(GranulometryModel objNewCalculationX50)
        {
            //Must have the A, K, Q and RWS 
            if(objNewCalculationX50.A == 0 || 
               objNewCalculationX50.K == 0 || 
               objNewCalculationX50.Q == 0 || 
               objNewCalculationX50.RWS == 0)
            {
                throw new ArgumentException("Insert the data for A, K, Q and RWS.");
            }
            ObjGranulometrysList.Add(objNewCalculationX50);
            return true;
        }

        public bool Update(GranulometryModel objUpdateCalculationX50)
        {
            bool IsUpdated = false;
            for(int i = 0; i < ObjGranulometrysList.Count; i++)
            {
                if (ObjGranulometrysList[i].A == objUpdateCalculationX50.A) 
                {
                    ObjGranulometrysList[i].K = objUpdateCalculationX50.K;
                    ObjGranulometrysList[i].Q = objUpdateCalculationX50.Q;
                    ObjGranulometrysList[i].RWS = objUpdateCalculationX50.RWS;
                    IsUpdated= true;    
                    break;
                }
            }
            return IsUpdated;
        }

        public bool Delete(double a)
        {
            bool IsDeleted = false;
            for (int i = 0; i < ObjGranulometrysList.Count; i++)
            {
                if (ObjGranulometrysList[i].A == a)
                {
                    ObjGranulometrysList.RemoveAt(i);
                    IsDeleted = true;
                    break;
                }
            }
            return IsDeleted;
        }

        public GranulometryModel Search(double a)
        {
            return ObjGranulometrysList.FirstOrDefault(e => e.A == a);

        }

    }
}
