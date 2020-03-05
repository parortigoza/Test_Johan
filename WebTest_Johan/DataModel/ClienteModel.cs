using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class ClienteModel
    {
        public string Identidad { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Ciudad { get; set; }
        public int ComprasRealizadas { get; set; }
        public string Empresa { get; set; }
        public int indiceBD { get; set; }
        public string FechaUltimaCompra { get; set; }
        public string Estado { get; set; }
    }
}
