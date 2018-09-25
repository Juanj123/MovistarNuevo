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
        int idUusario;
        string fecha;
        double recibo;
        double cambio;


        public int Folio { get => folio; set => folio = value; }
        public int IdUusario { get => idUusario; set => idUusario = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public double Recibo { get => recibo; set => recibo = value; }
        public double Cambio { get => cambio; set => cambio = value; }
    }
}
