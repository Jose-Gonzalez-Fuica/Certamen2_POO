using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmpleadoLibrarys; 

namespace WindowsFormsEmpleado
{
    public partial class FormEmpleado : Form
    {
        public string rut;
        public string nombre;
        public string apellido;
        public string mail;
        public string telefono;
        public FormEmpleado()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            rut = txtRut.Text;
            nombre = txtNombre.Text;
            apellido = txtApellido.Text;
            mail = txtMail.Text;
            telefono = txtTelefono.Text;

            if (rut != "") {
                empleadoEntity empleado = new empleadoEntity(rut, nombre, apellido, mail, telefono);

                DataSet existe = empleado.filtrarEmpleado(rut);
                int validar = existe.Tables[0].Rows.Count;

                if (validar == 0)
                {
                    empleado.guardar();
                    MessageBox.Show("El Empleado se ha ingresado con éxito","Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                    MessageBox.Show("Ya existe un Empleado en la Base de Datos con ese Rut","Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Debe ingresar a lo mínimo un Rut para ingresar un Empleado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtRut.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtMail.Text = "";
            txtTelefono.Text = "";
        }
    }
}
