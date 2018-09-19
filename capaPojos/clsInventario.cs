using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaPojos
{
   public class clsInventario
    {
        string clave;
        int idusuario;
        string nombre;
        string rutaImg;
        double precio;
        string proovedor;
        int existencia;
        string descripcion;

        public string Clave { get => clave; set => clave = value; }
        public int Idusuario { get => idusuario; set => idusuario = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string RutaImg { get => rutaImg; set => rutaImg = value; }
        public double Precio { get => precio; set => precio = value; }
        public string Proovedor { get => proovedor; set => proovedor = value; }
        public int Existencia { get => existencia; set => existencia = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
