using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaDatos;
using capaPojos;
using System.Windows.Forms;

namespace ProyectoMovistar
{
    public partial class Ventas : Form
    {
        public int cant;
        int total = 0;
        int sub = 0;
        int cambio = 0;
        int recibo = 0;
        List<String> productos = new List<string>();
        public Ventas()
        {
            InitializeComponent();
        }

        private void Ventas_Load_1(object sender, EventArgs e)
        {
            clsDatosVenta o = new clsDatosVenta();
            var lista = o.getProducto();
            cmbProductos.AutoCompleteSource = AutoCompleteSource.CustomSource;
            cmbProductos.AutoCompleteMode = AutoCompleteMode.Suggest;
            AutoCompleteStringCollection datos = new AutoCompleteStringCollection();
            for (int i = 0; i < o.getProducto()[0].Nombre.Length; i++)
            {
                cmbProductos.Items.Insert(i, o.getProducto()[i].Nombre);
                datos.Add((o.getProducto())[i].Nombre);
            }
            cmbProductos.AutoCompleteCustomSource = datos;

        }

        private void cmbProductos_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                clsDatosVenta ob = new clsDatosVenta();
                List<clsInventario> pro;
                pro = ob.getProductos(cmbProductos.Text);
                int rowEscribir = dataGridView1.Rows.Count - 1;
                dataGridView1.Rows.Add(1);

                dataGridView1.Rows[rowEscribir].Cells[0].Value = pro[0].Nombre;
                dataGridView1.Rows[rowEscribir].Cells[1].Value = pro[0].Precio;
                dataGridView1.Rows[rowEscribir].Cells[2].Value = "1";
                dataGridView1.Rows[rowEscribir].Cells[3].Value = pro[0].Descripcion;
                productos.Add(cmbProductos.Text);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                clsDatosVenta ob = new clsDatosVenta();
                Form1 obj = new Form1();
                obj.ShowDialog();
                List<clsInventario> pro;
                pro = ob.getProductos(cmbProductos.Text);
                for (int i = 0; i < pro.Count(); i++)
                {
                    dataGridView1.RowCount = pro.Count();
                    dataGridView1.Rows[i].Cells[2].Value = cant;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for(int iter = 0; iter<(dataGridView1.Rows.Count)-1; iter++)
            {
                dataGridView2.Rows.Add(1);
                dataGridView2.Rows[iter].Cells[0].Value = dataGridView1.Rows[iter].Cells[0].Value.ToString();
                dataGridView2.Rows[iter].Cells[1].Value = dataGridView1.Rows[iter].Cells[1].Value.ToString();
                dataGridView2.Rows[iter].Cells[2].Value = dataGridView1.Rows[iter].Cells[2].Value.ToString();
                dataGridView2.Rows[iter].Cells[3].Value = dataGridView1.Rows[iter].Cells[3].Value.ToString();
                total = Int32.Parse(dataGridView2.Rows[iter].Cells[1].Value.ToString()) + total;
                sub = Int32.Parse(dataGridView2.Rows[iter].Cells[1].Value.ToString());
            }

            dataGridView1.DataSource = "";
            lblSubtotal.Text = sub.ToString();
            lbltotal.Text = total.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < productos.Count; i++)
            {
                MessageBox.Show(productos[i]);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                recibo = Int32.Parse(textBox1.Text);
                if (recibo == total)
                {
                    cambio = 0;
                }
                else if (recibo > total)
                {
                    cambio = recibo - total;
                }
                else if (recibo < total)
                {
                    cambio = total - recibo;
                    lblCambio.BackColor = Color.Red;

                }
                lblCambio.Text = cambio.ToString();
            }

            {

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = "";
        }
    }
}

