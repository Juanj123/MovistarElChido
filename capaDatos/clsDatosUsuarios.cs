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
    public class clsDatosUsuarios
    {
        clsConexion conex = new clsConexion();
        public void AgregarUsuario(clsUsuarios obj)
        {
            string sql;
            MySqlCommand cm = new MySqlCommand();
            conex.conectar();

            cm.Parameters.AddWithValue("@idUsuario", obj.IdUsuario);
            cm.Parameters.AddWithValue("@nombre", obj.Usuario);
            cm.Parameters.AddWithValue("@correo", obj.Correo);
            cm.Parameters.AddWithValue("@tipo", obj.Tipo);
            cm.Parameters.AddWithValue("@contrasenia", obj.Contrasenia);

            sql = "INSERT INTO usuarios (nombre, correo, tipo, contrasenia) " +
            "VALUES (@nombre, @correo, @tipo, @contrasenia)";
            cm.CommandText = sql;
            cm.CommandType = CommandType.Text;
            cm.Connection = conex.cn;
            cm.ExecuteNonQuery();
            conex.cerrar();
        }

        public List<clsUsuarios> Mostrar()
        {
            List<clsUsuarios> lista = new List<clsUsuarios>();
            clsConexion conex = new clsConexion();
            conex.conectar();
            using (conex.cn)
            {
                string sql = "SELECT idUsuario, nombre, correo, tipo, contrasenia FROM usuarios";
                MySqlCommand cmd = new MySqlCommand(sql, conex.cn);
                MySqlDataReader lector = cmd.ExecuteReader();

                while (lector.Read())
                {
                    clsUsuarios u = new clsUsuarios();
                    u.IdUsuario = int.Parse(lector[0].ToString());
                    u.Usuario = lector[1].ToString();
                    u.Correo = lector[2].ToString();
                    u.Tipo = lector[3].ToString();
                    u.Contrasenia = lector[4].ToString();

                    lista.Add(u);
                }
            }
            conex.cerrar();
            return lista;
        }

        public void Eliminar(string id)
        {
            clsConexion conex = new clsConexion();
            int idUsuario = int.Parse(id);
            using (conex.cn)
            {
                conex.conectar();
                string sql = @"DELETE FROM usuarios WHERE idUsuario = @idUsuario";
                MySqlCommand cmd = new MySqlCommand(sql, conex.cn);
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                cmd.ExecuteNonQuery();
            }
            conex.cerrar();
        }

        public void Modificar(string nombre, string correo, string id)
        {
            clsConexion conex = new clsConexion();
            int idUsuario = int.Parse(id);

            using (conex.cn)
            {
                conex.conectar();
                string sql = @"UPDATE usuarios SET nombre = @nombre, correo = @correo WHERE idUsuario = @idUsuario";
                MySqlCommand cmd = new MySqlCommand(sql, conex.cn);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@correo", correo);
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                cmd.ExecuteNonQuery();
            }
            conex.cerrar();
        }
    }
}
