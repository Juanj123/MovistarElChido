using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaPojos;
using System.Data;
using MySql.Data.MySqlClient;

namespace capaDatos
{
    class clsDatosVenta
    {
        clsConexion cone = new clsConexion();
        public void AgregarProducto(clsVenta objProducto)
        {
            string sql;
            MySqlCommand cm;
            cone.conectar();
            cm = new MySqlCommand();
            cm.Parameters.AddWithValue("@Folio", objProducto.Folio);
            cm.Parameters.AddWithValue("@IdUsuario", objProducto.IdUsuario);
            cm.Parameters.AddWithValue("@Subtotal", objProducto.Subtotal);
            cm.Parameters.AddWithValue("@Total", objProducto.Total);
            cm.Parameters.AddWithValue("@Recibo", objProducto.Recibo);
            cm.Parameters.AddWithValue("@Cambio", objProducto.Cambio);
            cm.Parameters.AddWithValue("@Fecha", objProducto.Fecha);

            sql = "insert into ventas value(null, @IdUsuario, @Subtotal, @Total, @Recibo, @Cambio, @Fecha);";
            cm.CommandText = sql;
            cm.CommandType = CommandType.Text;
            cm.Connection = cone.cn;
            cm.ExecuteNonQuery();
            cone.cerrar();
        }
    }
}
