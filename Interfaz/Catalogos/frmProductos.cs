using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;

namespace Interfaz
{
    public partial class frmProductos : Form
    {
        
        Producto rep = new Producto();
        public ProductosVM ent = new ProductosVM();
        public frmProductos()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            txtCodigo.Text = "";
            txtCosto.Text = "";
            txtDescripcion.Text = "";
            txtExistencia.Text = "";
            txtPorcentaje.Text = "";
        }
       
        private void frmProductos_Load(object sender, EventArgs e)
        {
            Producto producto = new Producto();
            comboBox1.DataSource = producto.GetTiposDeCategoria();
            comboBox1.DisplayMember = "Descripcion";
            comboBox1.ValueMember = "Id";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (txtCodigo.Text != "" && txtDescripcion.Text != "" && txtCosto.Text != "" && txtPorcentaje.Text != "" && txtExistencia.Text != "")
            {
                ent.TipoDeCategoria = int.Parse(comboBox1.SelectedValue.ToString());
                ent.Codigo = txtCodigo.Text.Trim();
                ent.DescripcionDelProducto = txtDescripcion.Text.Trim();
                ent.Costo = decimal.Parse(txtCosto.Text);
                ent.Utilidad = decimal.Parse(txtPorcentaje.Text);
                ent.Existencia = int.Parse(txtExistencia.Text);
                int r = rep.Grabar(ent);

                if (r > 0)
                {
                    MessageBox.Show("Registros Guardados Correctamente, ");
                }
                Limpiar();
            }
            else

                MessageBox.Show("Hay Campos Vacíos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
        }

      
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void CargarProductosExistente(int productoId)
        {
            ent = rep.GetProducto(productoId);

            txtCodigo.Text = ent.Codigo.ToString();
            txtCosto.Text = ent.Costo.ToString();
            txtDescripcion.Text = ent.DescripcionDelProducto;
            txtExistencia.Text = ent.Existencia.ToString();
            txtPorcentaje.Text = ent.Utilidad.ToString();
            comboBox1.SelectedValue = ent.TipoDeCategoria;

        }
        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "")
            {
                int Id = rep.GetId(int.Parse(txtCodigo.Text));
                if (Id > 0)
                    CargarProductosExistente(Id);
            }
            else
                Limpiar();
        }

      
        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Debe ser un numero", "Sistema",
                       MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtExistencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Debe ser un numero", "Sistema",
                       MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Debe ser un numero", "Sistema",
                       MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtPorcentaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Debe ser un numero", "Sistema",
                       MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

     

    }
}
