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
    public partial class frmTiposDeEntradasR : Form
    {
        public frmTiposDeEntradasR()
        {
            InitializeComponent();
        }

        private void frmTiposDeEntradas_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DSTiposDeEntradaR.spTiposDeEntradaR' Puede moverla o quitarla según sea necesario.
           
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.spTiposDeEntradaRTableAdapter.Fill(this.DSTiposDeEntradaR.spTiposDeEntradaR, int.Parse(txtId.Text));

            this.reportViewer1.RefreshReport();
        }
    }
}
