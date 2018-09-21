using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaDatos;

namespace ProyectoMovistar
{
    public partial class recuperarContrasenia : Form
    {
        public recuperarContrasenia()
        {
            InitializeComponent();
        }

        clsDatosLogin datosLogin = new clsDatosLogin();
        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            txtMensaje.Text = datosLogin.recuperarContrasenia(txtCorreo.Text);
        }
    }
}
