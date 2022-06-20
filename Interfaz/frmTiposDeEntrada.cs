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
    public partial class frmTiposDeEntrada : Form
    {
        public frmTiposDeEntrada()
        {
            InitializeComponent();
        }
        private void Limpiar1(int l)
        {
            if (l == 1)
                txtId.Text = "";

            txtCodigo.Text = "";
            txtDescripcion.Text = "";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            TiposDeEntradas TipoDeentrada = new TiposDeEntradas();

            if ((txtId.Text != "") && (txtCodigo.Text != "") && (txtDescripcion.Text != ""))
            {
                TipoDeentrada.Id = Convert.ToInt16(txtId.Text);
                TipoDeentrada.CodigoTipoEntrada = txtCodigo.Text;
                TipoDeentrada.DescripcionTipoDeEntrada = txtDescripcion.Text;

                if (TipoDeentrada.NuevoTiposDeEntrada(TipoDeentrada) > 0)
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
            else
                MessageBox.Show("Existen campos Vacios", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            TiposDeEntradas TipoDeentrada = new TiposDeEntradas();

            TipoDeentrada.Id = Convert.ToInt16(txtId.Text);
            TipoDeentrada.CodigoTipoEntrada = txtCodigo.Text;
            TipoDeentrada.DescripcionTipoDeEntrada = txtDescripcion.Text;

            if (TipoDeentrada.ActualizarTiposDeEntrada(TipoDeentrada) > 0)
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            TiposDeEntradas TipoDeentrada = new TiposDeEntradas();

            TipoDeentrada.Id = Convert.ToInt16(txtId.Text);
            TipoDeentrada.CodigoTipoEntrada = txtCodigo.Text;
            TipoDeentrada.DescripcionTipoDeEntrada = txtDescripcion.Text;

            if (TipoDeentrada.EliminarTiposDeEntrada(TipoDeentrada) > 0)
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

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            TiposDeEntradas t = new TiposDeEntradas();

            t.Id = Convert.ToInt16(txtId.Text);
            if (t.getTiposDeEntrada(t) > 0)
            {
                lblMensaje.Text = "Registro Encontrado";
                txtId.Text = t.Id.ToString();
                txtCodigo.Text = t.CodigoTipoEntrada;
                txtDescripcion.Text = t.DescripcionTipoDeEntrada;

            }
            else
            {
                lblMensaje.Text = "Registro no Encontrado";
                Limpiar1(0);
            }
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            if (txtId.Text != "")
            {
                TiposDeEntradas t = new TiposDeEntradas();

                t.Id = Convert.ToInt16(txtId.Text);
                if (t.getTiposDeEntrada(t) > 0)
                {
                    lblMensaje.Text = "Registro Encontrado";
                    txtId.Text = t.Id.ToString();
                    txtCodigo.Text = t.CodigoTipoEntrada;
                    txtDescripcion.Text = t.DescripcionTipoDeEntrada;

                }
                else
                {
                    lblMensaje.Text = "Registro no Encontrado";
                    Limpiar1(0);
                }
            }
        }

        private void txtId_keyPress(object sender, KeyPressEventArgs e)
        {
            if(!(char.IsNumber(e.KeyChar)) && (e.KeyChar!=(char)Keys.Back))
            {
                MessageBox.Show("Debe ser un numero", "Sistema",
                       MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void frmTiposDeEntrada_Load(object sender, EventArgs e)
        {

        }






    }
}
