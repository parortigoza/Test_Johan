using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager
{
    public class DataConnString
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ObtenerConexionEmpresaUno()
        {
            return ConfigurationManager.ConnectionStrings["ConnStringEmpresaUno"].ConnectionString;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ObtenerConexionEmpresaDos()
        {
            return ConfigurationManager.ConnectionStrings["ConnStringEmpresaDos"].ConnectionString;
        }
    }
}
