using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;
using System.Windows.Forms;

namespace ProyectoMovistar
{
    public partial class Ventas : Form
    {
        public Ventas()
        {
            InitializeComponent();
        }

        private void Ventas_Load(object sender, EventArgs e)
        {
            clsDatosVenta o = new clsDatosVenta();
            var lista = o.getProducto();
            cmbProductos.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmbProductos.AutoCompleteMode = AutoCompleteMode.Suggest;
            AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
            for(int i = 0; i < o.getProducto()[0].Nombre.Length; i++)
            {
                datos.Add((o.getProducto())[i].Nombre);
            }
            cmbProductos.AutoCompleteCustomSource = datos;

        }

        private void cmbProductos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                clsDatosVenta ob = new clsDatosVenta();
                dataGridView1.DataSource = ob.getProductos(cmbProductos.Text);
            }
        }
    }
    }

