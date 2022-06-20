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
    public partial class frmProductosR : Form
    {
        public frmProductosR()
        {
            InitializeComponent();
        }

        private void frmProductosR_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DSProductosR.spProductosR' Puede moverla o quitarla según sea necesario.
            //this.spProductosRTableAdapter.Fill(this.DSProductosR.spProductosR);

            //this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.spProductosRTableAdapter.Fill(this.DSProductosR.spProductosR, int.Parse(txtId.Text));

            this.reportViewer1.RefreshReport();
        }
    }
}
