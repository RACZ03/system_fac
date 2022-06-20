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
    public partial class frmSalidasR : Form
    {
        public frmSalidasR()
        {
            InitializeComponent();
        }


        int Number;
        public void SetNumber(int Numero)
        {
            this.Number = Numero;
        }
        private int GetNumero()
        {
            return this.Number;
        }
        private void frmSalidasR_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DSSalidas.spSalidasR' Puede moverla o quitarla según sea necesario.
            this.spSalidasRTableAdapter.Fill(this.DSSalidas.spSalidasR, Number);

            this.reportViewer1.RefreshReport();
        }
    }
}
