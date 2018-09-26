using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaPojos
{
    public class clsDVenta
    {
        
        int folio;
        string nombre;
        int precio;
        int cantidad;
        double total;


        public int Folio { get => folio; set => folio = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Precio { get => precio; set => precio = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public double Total { get => total; set => total = value; }
    }
}
