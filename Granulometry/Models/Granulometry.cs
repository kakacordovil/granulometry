using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Granulometry.Models
{
    class Granulometry
    {
        #region double A
        /// <summary>
        /// Rock Factor. 
        /// (Fator de Rocha)
        /// </summary>
        public double A { get; set; }
        #endregion

        #region double K
        /// <summary>
        /// Powder Factor (kg/m3).
        /// </summary>
        public double K { get; set; }
        #endregion

        #region double Q
        /// <summary>
        /// Mass corresponding to the amount of explosive per hole (kg).
        /// (Massa correspondente à quantidade de explosivo por furo (kg) )
        /// </summary>
        public double Q { get; set; }
        #endregion

        #region double RWS
        /// <summary>
        /// Relative mass energy of explosive compared to pure ANFO(explosive).
        /// (Energia relativa em massa do explosivo em comparação com o ANFO(explosivo) puro)
        /// </summary>
        public double RWS { get; set; }
        #endregion


        #region double CalculateX50()
        /// <summary>
        /// Method for calculating the average granulometry
        /// </summary>
        public double CalculateX50()
        {
            return 10 * A * Math.Pow(K, -0.8) * Math.Pow(Q, 1.0 / 6.0) * Math.Pow(115 / RWS, 19.0 / 30.0);
        }
        #endregion
    }
}
