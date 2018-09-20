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
    public class clsDatosVenta
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

        public List<clsInventario> getProducto()
        {
            cone.conectar();
            List<clsInventario> lstUsuarios = new List<clsInventario>();
            string sql;
            MySqlCommand cm = new MySqlCommand();
            MySqlDataReader dr;
            sql = "select nombre from inventario;";
            cm.CommandText = sql;
            cm.CommandType = CommandType.Text;
            cm.Connection = cone.cn;
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                clsInventario objAl = new clsInventario();
                objAl.Nombre = dr.GetString("nombre");
                lstUsuarios.Add(objAl);
            }
            cone.cerrar();
            return lstUsuarios;
        }
        public List<clsInventario> getProductos(string producto)
        {
            cone.conectar();
            List<clsInventario> lstUsuarios = new List<clsInventario>();
            string sql;
            MySqlCommand cm = new MySqlCommand();
            MySqlDataReader dr;
            sql = "select nombre, precio, existencia, descripcion from inventario where nombre = '"+producto+"';";
            cm.CommandText = sql;
            cm.CommandType = CommandType.Text;
            cm.Connection = cone.cn;
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                clsInventario objAl = new clsInventario();
                objAl.Nombre = dr.GetString("nombre");
                objAl.Precio = dr.GetDouble("precio");
                objAl.Existencia = dr.GetInt32("existencia");
                objAl.Descripcion = dr.GetString("descripcion");
                lstUsuarios.Add(objAl);
            }
            cone.cerrar();
            return lstUsuarios;
        }
        public int cantidad(string producto)
        {
            cone.conectar();
            int numero = 0;
            string sql;
            MySqlCommand cm = new MySqlCommand();
            MySqlDataReader dr;
            sql = "select existencia from inventario where nombre = '" + producto + "';";
            cm.CommandText = sql;
            cm.CommandType = CommandType.Text;
            cm.Connection = cone.cn;
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                clsInventario objUs = new clsInventario();
                numero = objUs.Existencia = dr.GetInt32("existencia");
            }
            cone.cerrar();
            return numero;
        }
    }
}