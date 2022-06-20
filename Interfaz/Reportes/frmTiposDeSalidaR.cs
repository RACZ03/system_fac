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
    public partial class frmTiposDeSalidaR : Form
    {
        public frmTiposDeSalidaR()
        {
            InitializeComponent();
        }

        private void frmTiposDeSalidaR_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DSTiposDeSalidaR.spTiposDeSalidaR' Puede moverla o quitarla según sea necesario.
            //this.spTiposDeSalidaRTableAdapter.Fill(this.DSTiposDeSalidaR.spTiposDeSalidaR);

            //this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
        //    this.spTiposDeSalidaRTableAdapter.Fill(this.DSTiposDeSalidaR.spTiposDeSalidaR, int.Parse(txtId.Text));

        //    this.reportViewer1.RefreshReport();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.spTiposDeSalidaRTableAdapter.Fill(this.DSTiposDeSalidaR.spTiposDeSalidaR, int.Parse(txtId.Text));

            this.reportViewer1.RefreshReport();
        }
    }
}
