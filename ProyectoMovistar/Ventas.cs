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
        int cant;
        int total = 0;
        int sub = 0;
        int cambio = 0;
        int recibo = 0;
        int folio = 2;
        int rowEscribir;
        clsValidaciones objValidaciones = new clsValidaciones();
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
            foreach (DataGridViewColumn c in dataGridView1.Columns)
            {
                if (c.Name != "Cantidad") c.ReadOnly = true;
            }
                
        }

        private void cmbProductos_KeyDown_1(object sender, KeyEventArgs e)
        {
                if (e.KeyData == Keys.Enter)
                {
                    clsDatosVenta ob = new clsDatosVenta();
                    List<clsInventario> pro;
                    pro = ob.getProductos(cmbProductos.Text);
                    rowEscribir = rowEscribir + dataGridView1.Rows.Count - 1;
                    dataGridView1.Rows.Add(1);

                    dataGridView1.Rows[rowEscribir].Cells[0].Value = pro[0].Nombre;
                    dataGridView1.Rows[rowEscribir].Cells[1].Value = pro[0].Precio;
                    dataGridView1.Rows[rowEscribir].Cells[2].Value = "1";
                    dataGridView1.Rows[rowEscribir].Cells[3].Value = pro[0].Descripcion;
                    productos.Add(cmbProductos.Text);
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
                cant = Int32.Parse(dataGridView2.Rows[iter].Cells[2].Value.ToString());
                if (cant>1)
                {
                    total = total * cant;
                }
                sub = total;
            }

            dataGridView1.DataSource = "";
            lblSubtotal.Text = sub.ToString();
            lbltotal.Text = total.ToString();
            rowEscribir = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Llenado de los campos del formulario para guardarlos en la Base de Datos
            try
            {
                clsDatosVenta objDao = new clsDatosVenta();
                clsVenta objSolicitud = new clsVenta();
                clsDVenta objDVenta = new clsDVenta();
                objSolicitud.Folio = folio;
                objSolicitud.IdUsuario = 1;
                objSolicitud.Subtotal = double.Parse(lblSubtotal.Text);
                objSolicitud.Total = double.Parse(lbltotal.Text);
                objSolicitud.Recibo = double.Parse(textBox1.Text);
                objSolicitud.Cambio = double.Parse(lblCambio.Text);
                objSolicitud.Fecha = dateTimePicker1.Text;
                int row = ((dataGridView2.Rows.Count)-1);
                MessageBox.Show(row.ToString());
                for (int iter = 0; iter < row; iter++)
                {
                    dataGridView2.Rows.Add(1);
                    objDVenta.Folio = folio;
                    objDVenta.Nombre = dataGridView2.Rows[iter].Cells[0].Value.ToString();
                    objDVenta.Precio = double.Parse(dataGridView2.Rows[iter].Cells[1].Value.ToString());
                    objDVenta.Cantidad = Int32.Parse(dataGridView2.Rows[iter].Cells[2].Value.ToString());
                    objDao.AgregarDVenta(objDVenta);
                }
                // Se insertan los datos de venta
                objDao.AgregarProducto(objSolicitud);

                // Muestra mensaje de satisfaccion
                MessageBox.Show("Solicitud Registrada", "Insertar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Muestra mensaje en caso de que haya errores
                MessageBox.Show("Error al llenar los campos, verifique sus datos", "Datos ingresados incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            objValidaciones.Numeros(e);
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

        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = "";
            lblCambio.Text = "0";
            lblSubtotal.Text = "0";
            lbltotal.Text = "0";
        }
    }
}

