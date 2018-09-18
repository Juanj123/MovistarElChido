using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaPojos
{
    public class clsVenta
    {
        int folio;
        int idUsuario;
        double subtotal;
        double total;
        double recibo;
        double cambio;
        string fecha;

        public int Folio { get => folio; set => folio = value; }
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public double Subtotal { get => subtotal; set => subtotal = value; }
        public double Total { get => total; set => total = value; }
        public double Recibo { get => recibo; set => recibo = value; }
        public double Cambio { get => cambio; set => cambio = value; }
        public string Fecha { get => fecha; set => fecha = value; }
    }
}
