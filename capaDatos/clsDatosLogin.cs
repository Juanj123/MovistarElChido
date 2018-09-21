using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using capaPojos;
using System.Net;
using System.Net.Mail;

namespace capaDatos
{
    public class clsDatosLogin
    {
        private clsConexion conexion = new clsConexion();
        private string email, nombre, contrasenia, mensaje;
        MySqlCommand com = new MySqlCommand();

        public String recuperarContrasenia(string id)
        {
            MySqlDataReader dr;
            conexion.conectar();
            com.Connection = conexion.cn;
            com.CommandText = "select  * from usuarios where correo = '" + id + "'";
            dr = com.ExecuteReader();
            if (dr.Read() == true)
            {
                email = dr["correo"].ToString();
                nombre = dr["nombre"].ToString();
                contrasenia = dr["contrasenia"].ToString();
                //Email
                enviarCorreo();
                mensaje = "Estimado " + nombre + ", se ha enviado su contraseña a su correo: " + email + ". Verifique su bandeja de entrada";
                dr.Close();

            }
            else
            {
                mensaje = "No existe dato ...";
            }

            return mensaje;
        }

        public void enviarCorreo()
        {
            // se configura el mensaje del correo
            MailMessage correo = new MailMessage();
            correo.From = new MailAddress("generalsolutionsti@gmail.com");
            correo.To.Add(email);
            correo.Subject = ("Recuperar contraseña");
            correo.Body = "Hola, " + nombre + " Usted solicito recuperar contreseña. \n Su contraseña es: " + contrasenia;
            correo.Priority = MailPriority.High;

            // configuracion protoculo SMTP
            SmtpClient serverMail = new SmtpClient();
            serverMail.Credentials = new NetworkCredential("generalsolutionsti@gmail.com", "solutions123");
            serverMail.Host = "smtp.gmail.com";
            serverMail.Port = 587;
            serverMail.EnableSsl = true;
            try
            {
                serverMail.Send(correo);
            }
            catch { }
            correo.Dispose();
        }


        public MySqlDataReader iniciarSesionAd(clsLogin login)
        {
            try
            {
                string mysql = "select * from usuarios where nombre='" + login.Nombre + "'and contrasenia='" + login.Contrasenia + "'and tipo= '" + login.Tipo + "'";
                MySqlCommand cm = new MySqlCommand();
                MySqlDataReader dr;
                conexion.conectar();
                cm.CommandText = mysql;
                cm.CommandType = CommandType.Text;
                cm.Connection = conexion.cn;
                dr = cm.ExecuteReader();
                return dr;
            }
            catch
            {
                return null;
            }
            finally
            {
                //conexion.cerrar();
            }


        }

        public MySqlDataReader iniciarSesionEm(clsLogin login)
        {
            try
            {
                string mysql = "select * from usuarios where nombre='" + login.Nombre + "'and contrasenia='" + login.Contrasenia + "'and tipo= '" + login.Tipo + "'";
                MySqlCommand cm = new MySqlCommand();
                MySqlDataReader dr;
                conexion.conectar();
                cm.CommandText = mysql;
                cm.CommandType = CommandType.Text;
                cm.Connection = conexion.cn;
                dr = cm.ExecuteReader();
                return dr;
            }
            catch
            {
                return null;
            }
            finally
            {
                //conexion.cerrar();
            }

        }
    }
}
