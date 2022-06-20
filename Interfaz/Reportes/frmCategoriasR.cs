using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz.Reportes
{
    public partial class frmCategoriasR : Form
    {
        public frmCategoriasR()
        {
            InitializeComponent();
        }

        private void frmCategoriasR_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DSCategorias.spCategoriaR' Puede moverla o quitarla según sea necesario.
            //this.spCategoriaRTableAdapter.Fill(this.DSCategorias.spCategoriaR);

            //this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.spCategoriaRTableAdapter.Fill(this.DSCategorias.spCategoriaR, int.Parse(txtId.Text));

            this.reportViewer1.RefreshReport();
        }
    }
}
