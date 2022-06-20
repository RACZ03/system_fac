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
    public partial class frmEntradasR : Form
    {
        public frmEntradasR()
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

        private void frmEntradas_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DSEntradas.spEntradasR' Puede moverla o quitarla según sea necesario.
            this.spEntradasRTableAdapter.Fill(this.DSEntradas.spEntradasR, Number);

            this.reportViewer1.RefreshReport();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
