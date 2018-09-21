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
using capaPojos;

namespace ProyectoMovistar
{
    public partial class Usuarios : Form
    {
        int poc;
        string id;
        clsDatosUsuarios consulta = new clsDatosUsuarios();
        List<clsUsuarios> tabla = new List<clsUsuarios>(); 

        public Usuarios()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            
        }
        private void Usuarios_Load(object sender, EventArgs e)
        {
            Actualizar();
            limpiar();
        }

        private void limpiar()
        {
            txtNombre.Clear();
            txtCorreo.Clear();
            txtContrasenia.Clear();
            cmbTipo.SelectedIndex = -1;
            btnModificar.Enabled = false;
            btnEliminar.Enabled = false;
            dataGridView1.ClearSelection();
        }

        private void habilitar()
        {
            txtNombre.Enabled = true;
            txtCorreo.Enabled = true;
            txtContrasenia.Enabled = true;
            cmbTipo.Enabled = true;
            btnAgregar.Enabled = true;
        }

        private void Actualizar()
        {
            dataGridView1.Rows.Clear();
            //dataGridView1.Refresh();
            tabla = consulta.Mostrar();
            foreach (clsUsuarios elemento in tabla)
            {
                dataGridView1.Rows.Add(elemento.Usuario, elemento.Correo, elemento.Tipo);
            }

        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                btnEliminar.Enabled = true;
                btnModificar.Enabled = true;

                poc = dataGridView1.CurrentRow.Index;
                clsUsuarios aux = tabla[poc];
                id = aux.IdUsuario.ToString();

                txtNombre.Text = dataGridView1[0, poc].Value.ToString();
                txtCorreo.Text = dataGridView1[1, poc].Value.ToString();

                txtContrasenia.Enabled = false;
                cmbTipo.Enabled = false;
                btnAgregar.Enabled = false;
            }
            catch
            {

            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            clsValidaciones obj = new clsValidaciones();
            if ((txtNombre.Text != "") && (txtCorreo.Text != "") && (txtContrasenia.Text != "") && (cmbTipo.Text != "") && obj.Nombre(txtNombre.Text) && obj.email_bien_escrito(txtCorreo.Text))
            {
                    clsUsuarios u = new clsUsuarios();
                    u.Usuario = txtNombre.Text;
                    u.Contrasenia = txtContrasenia.Text;
                    u.Correo = txtCorreo.Text;
                    u.Tipo = cmbTipo.Text;

                    try
                    {
                        consulta.AgregarUsuario(u);
                        MessageBox.Show("Usuario guardado correctamente", "Usuarios", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                        Actualizar();
                        limpiar();
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("Usuario no guardado", "Usuarios", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                    } 
            }
            else
            {
                MessageBox.Show("Verifique los datos ingresados", "Usuarios", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            habilitar();
            limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                consulta.Eliminar(id);
                MessageBox.Show("Usuario eliminado", "Usuarios", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                Actualizar();
                habilitar();
                limpiar();
            }
            catch(Exception exc)
            {
                MessageBox.Show("Usuario no eliminado", "Usuarios", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            }
            
        }

        

        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            clsValidaciones obj = new clsValidaciones();
            if (obj.Nombre(txtNombre.Text) && obj.email_bien_escrito(txtCorreo.Text))
            {
                try
                {
                    consulta.Modificar(txtNombre.Text, txtCorreo.Text, id);
                    MessageBox.Show("Usuario modificado correctamente", "Usuarios", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                    Actualizar();
                    limpiar();
                    habilitar();
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Usuario no modificado correctamente", "Usuarios", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                MessageBox.Show("Verifique los datos ingresados", "Usuarios", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            }
        }
    }
}
