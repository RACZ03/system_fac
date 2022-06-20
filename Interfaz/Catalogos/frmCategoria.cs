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
    public partial class frmCategoria : Form
    {
        public frmCategoria()
        {
            InitializeComponent();
        }

        private void Limpiar1(int l)
        {
            if (l == 1)
                txtCodigo.Text = "";


            txtDescripcion.Text = "";
        }
        private void frmCategoria_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "" && txtDescripcion.Text != "")
            {
                Categoria categoria = new Categoria();
                categoria.CodigoDeLaCategoria = txtCodigo.Text;
                categoria.DescripcionDeCategoria = txtDescripcion.Text;


                if (categoria.getCategoria(categoria) > 0)
                {
                    categoria.CodigoDeLaCategoria = txtCodigo.Text;
                    categoria.DescripcionDeCategoria = txtDescripcion.Text;
                    if (categoria.ActualizarCategoria(categoria) > 0)
                    {

                        lblMensaje.Text = "Registro actualizado Exitosamente";
                        Limpiar1(1);
                    }
                    else
                    {
                        lblMensaje.Text = "Error al actualizar";
                        Limpiar1(1);
                    }


                }
                else
                {
                    if (categoria.NuevaCategoria(categoria) > 0)
                    {
                        lblMensaje.Text = "Registro guardado Exitosamente";
                        Limpiar1(1);
                    }
                    else
                    {
                        lblMensaje.Text = "Error al Guardar";
                        Limpiar1(1);
                    }
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Categoria categoria = new Categoria();


            categoria.CodigoDeLaCategoria = txtCodigo.Text;
            categoria.DescripcionDeCategoria = txtDescripcion.Text;

            if (categoria.EliminarCategoria(categoria) > 0)
            {
                lblMensaje.Text = "Registro eliminado Exitosamente";
                Limpiar1(1);
            }
            else
            {
                lblMensaje.Text = "Error al Eliminar";
                Limpiar1(1);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "")
            {
                Categoria C = new Categoria();

                C.CodigoDeLaCategoria = txtCodigo.Text;
                if (C.getCategoria(C) > 0)
                {
                    lblMensaje.Text = "Registro Encontrado";
                    txtCodigo.Text = C.CodigoDeLaCategoria;
                    txtDescripcion.Text = C.DescripcionDeCategoria;

                }
                else
                {
                    lblMensaje.Text = "Registro no Encontrado";
                    Limpiar1(0);
                }
            }
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
    }
}
