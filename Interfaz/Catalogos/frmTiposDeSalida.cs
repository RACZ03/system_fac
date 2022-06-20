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
    public partial class frmTiposDeSalida : Form
    {
        public frmTiposDeSalida()
        {
            InitializeComponent();
        }

        private void frmTiposDeSalida_Load(object sender, EventArgs e)
        {

        }
        private void Limpiar1(int l)
        {
            if (l == 1)
                txtCodigo.Text = "";

         
            txtDescripcion.Text = "";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {


            if ((txtCodigo.Text != "") && (txtDescripcion.Text != ""))
            {
                TiposDeSalidas TiposDesalida = new TiposDeSalidas();
                TiposDesalida.CodigoTipoSalida = txtCodigo.Text;
                TiposDesalida.DescripcionTipoDeSalida = txtDescripcion.Text;
                if (TiposDesalida.getTiposDeSalida(TiposDesalida) > 0)
                {

                    TiposDesalida.CodigoTipoSalida = txtCodigo.Text;
                    TiposDesalida.DescripcionTipoDeSalida = txtDescripcion.Text;
                    if (TiposDesalida.ActualizarTiposDeSalidas(TiposDesalida) > 0)
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
                    if (TiposDesalida.NuevoTiposDeSalida(TiposDesalida) > 0)
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
            TiposDeSalidas TiposDesalida = new TiposDeSalidas();

            
            TiposDesalida.CodigoTipoSalida = txtCodigo.Text;
            TiposDesalida.DescripcionTipoDeSalida = txtDescripcion.Text;

            if (TiposDesalida.EliminarTiposDeSalida(TiposDesalida) > 0)
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
                TiposDeSalidas t = new TiposDeSalidas();

                t.CodigoTipoSalida = txtCodigo.Text;
                if (t.getTiposDeSalida(t) > 0)
                {
                    lblMensaje.Text = "Registro Encontrado";
                    txtCodigo.Text = t.CodigoTipoSalida;
                    txtDescripcion.Text = t.DescripcionTipoDeSalida;

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