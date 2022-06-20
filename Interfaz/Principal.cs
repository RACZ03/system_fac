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
using Interfaz.Reportes;

namespace Interfaz
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tiposDeEntradasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTiposDeEntrada frmTiposDeEntrada = new frmTiposDeEntrada();
            frmTiposDeEntrada.Show();
        }

        private void tiposDeSalidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTiposDeSalida frmTiposDeSalida = new frmTiposDeSalida();
            frmTiposDeSalida.Show();
        }

        private void entradasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEntrada entrada = new frmEntrada();
            entrada.Show();
        }

        private void salidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSalida salida = new frmSalida();
            salida.Show();
        }

        private void categoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategoria categoria = new frmCategoria();
            categoria.Show();
        }

        private void productoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductos producto = new frmProductos();
            producto.Show();
        }



        private void catalogosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTiposDeEntradasR FrmTiposDeEntradaR = new frmTiposDeEntradasR();
            FrmTiposDeEntradaR.Show();
        }

        private void tiposDeSalidasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmTiposDeSalidaR TiposDeSalidaR = new frmTiposDeSalidaR();
            TiposDeSalidaR.Show();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategoriasR CategoriaR = new frmCategoriasR();
            CategoriaR.Show();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductosR ProductoR = new frmProductosR();
            ProductoR.Show();
        }

    }
}
