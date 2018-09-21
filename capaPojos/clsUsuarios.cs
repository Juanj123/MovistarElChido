using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaPojos
{
    public class clsUsuarios
    {
        int idUsuario;
        string usuario;
        string correo;
        string tipo;
        string contrasenia;

        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public string Contrasenia { get => contrasenia; set => contrasenia = value; }
    }
}
