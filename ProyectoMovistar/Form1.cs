using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoMovistar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                int cant = Int32.Parse(cmbCantidad.Text);
                MessageBox.Show(cant.ToString());
            }
        }

        private void cmbCantidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cant = Int32.Parse(cmbCantidad.Text);
            Ventas o = new Ventas();
            this.Close();
        }
    }
}
