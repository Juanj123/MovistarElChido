using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaPojos
{
    public class clsLogin
    {
        private string nombre, tipo, contrasenia;

        public clsLogin(string nombre, string tipo, string contrasenia)
        {
            this.nombre = nombre;
            this.tipo = tipo;
            this.contrasenia = contrasenia;
        }

        public clsLogin()
        {
        }

        public string Nombre
        {
            get => nombre;
            set { if (value == "USUARIO") { nombre = "No ha ingresado usuario"; } else { nombre = value; } }
        }
        public string Tipo { get => tipo; set => tipo = value; }
        public string Contrasenia { get => contrasenia; set { if (value == "CONTRASEÑA") { contrasenia = "No ha ingresado contraseña"; } else { contrasenia = value; } } }
    }
}
