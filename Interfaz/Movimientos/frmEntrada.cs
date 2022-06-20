using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Interfaz.Reportes;

using Logica;

namespace Interfaz
{
    public partial class frmEntrada : Form
    {
        EntradaRepositorio rep = new EntradaRepositorio();
        public EntradaVM ent = new EntradaVM();
        public frmEntrada()
        {
            InitializeComponent();
        }

        private void frmEntrada_Load(object sender, EventArgs e)
        {
            txtNumero.Focus();
            cboTipo.DataSource = rep.GetTiposDeEntrada();
            cboTipo.DisplayMember = "Descripcion";
            cboTipo.ValueMember = "Id";


            dgvDetalle.Columns.Add("ProductoId", "ProductoId");
            dgvDetalle.Columns.Add("Precio", "Precio");
            dgvDetalle.Columns.Add("Cantidad", "Cantidad");
            dgvDetalle.Columns.Add("Producto", "Producto");

            dgvDetalle.Columns["ProductoId"].Visible = false;

            DataGridViewButtonColumn dgvButtonDetalle = new DataGridViewButtonColumn();
            dgvButtonDetalle.HeaderText = "Editar";
            dgvButtonDetalle.Name = "btnEditar";
            dgvButtonDetalle.Text = "Editar";
            dgvButtonDetalle.UseColumnTextForButtonValue = true;

            dgvDetalle.Columns.Add(dgvButtonDetalle);

            DataGridViewButtonColumn dgvButtonRemover = new DataGridViewButtonColumn();
            dgvButtonRemover.HeaderText = "Remover";
            dgvButtonRemover.Name = "btnRemover";
            dgvButtonRemover.Text = "Remover";
            dgvButtonRemover.UseColumnTextForButtonValue = true;

            dgvDetalle.Columns.Add(dgvButtonRemover);

            //****************************************************************
            //SOLO SI VA A EDITAR UNA ENTRADA
            //cargando una entrada que exista, comentar esta parte si desea crear una entrada nueva
            //CargarEntradaExistente(4);
            //***************************************************************
        }
        public void CargarEntradaExistente(int EntradaId)
        {
            ent = rep.GetEntrada(EntradaId);

            txtDescripcion.Text = ent.Descripcion;
            txtFecha.Text = ent.Fecha;
            txtNumero.Text = ent.Numero.ToString();
            cboTipo.SelectedValue = ent.TipoDeEntrada;
            foreach (var item in ent.Detalles)
            {
                dgvDetalle.Rows.Add(item.ProductoId, item.Costo, item.Cantidad, item.Producto);
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var ids = ObtenerDetallesDelGrid().Select(s => s.ProductoId).ToList();

            frmDetalleEntrada frmDetalleEntrada = new frmDetalleEntrada();
            frmDetalleEntrada.cboProducto.DataSource = rep.GetProductos().Where(w => !ids.Contains(w.Id)).ToList();
            frmDetalleEntrada.cboProducto.DisplayMember = "Nombre";
            frmDetalleEntrada.cboProducto.ValueMember = "Id";
            if (frmDetalleEntrada.ShowDialog() == DialogResult.OK)
            {
                dgvDetalle.Rows.Add(frmDetalleEntrada.cboProducto.SelectedValue.ToString(), frmDetalleEntrada.txtPrecio
                    .Text, frmDetalleEntrada.txtCantidad.Text, frmDetalleEntrada.cboProducto.Text);
            }
        }

        private void dgvDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dgvDetalle.Columns[e.ColumnIndex].Name == "btnRemover")
                {
                    try
                    {
                        dgvDetalle.Rows.RemoveAt(e.RowIndex);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (dgvDetalle.Columns[e.ColumnIndex].Name == "btnEditar")
                {
                    try
                    {

                        var id_producto = int.Parse(dgvDetalle.Rows[e.RowIndex].Cells["ProductoId"].Value.ToString());
                        var ids = ObtenerDetallesDelGrid().Where(w => w.ProductoId != id_producto).Select(s => s.ProductoId).ToList();
                        frmDetalleEntrada frmDetalleEntrada = new frmDetalleEntrada();

                        frmDetalleEntrada.cboProducto.DataSource = rep.GetProductos().Where(w => !ids.Contains(w.Id)).ToList();
                        frmDetalleEntrada.cboProducto.DisplayMember = "Nombre";
                        frmDetalleEntrada.cboProducto.ValueMember = "Id";
                        //asignar valores de la fila del grid a los campos del formulario
                        frmDetalleEntrada.cboProducto.SelectedValue = id_producto;
                        frmDetalleEntrada.txtCantidad.Text = dgvDetalle.Rows[e.RowIndex].Cells["Cantidad"].Value.ToString();
                        frmDetalleEntrada.txtPrecio.Text = dgvDetalle.Rows[e.RowIndex].Cells["Precio"].Value.ToString();

                        if (frmDetalleEntrada.ShowDialog() == DialogResult.OK)
                        {
                            dgvDetalle.Rows[e.RowIndex].Cells["ProductoId"].Value = frmDetalleEntrada.cboProducto.SelectedValue;
                            dgvDetalle.Rows[e.RowIndex].Cells["Producto"].Value = frmDetalleEntrada.cboProducto.Text;
                            dgvDetalle.Rows[e.RowIndex].Cells["Cantidad"].Value = frmDetalleEntrada.txtCantidad.Text;
                            dgvDetalle.Rows[e.RowIndex].Cells["Precio"].Value = frmDetalleEntrada.txtPrecio.Text;
                        }
                    }
                    catch { }
                }
            }
        }
      
        public List<DetalleVW> ObtenerDetallesDelGrid()
        {
            List<DetalleVW> data = new List<DetalleVW>();
            for (int i = 0; i < dgvDetalle.Rows.Count; i++)
            {
                data.Add(new DetalleVW()
                {
                    ProductoId = int.Parse(dgvDetalle.Rows[i].Cells["ProductoId"].Value.ToString()),
                    Cantidad = int.Parse(dgvDetalle.Rows[i].Cells["Cantidad"].Value.ToString()),
                    Costo = decimal.Parse(dgvDetalle.Rows[i].Cells["Precio"].Value.ToString()),
                    Producto = dgvDetalle.Rows[i].Cells["Producto"].Value.ToString()
                });
            }
            return data;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ent.TipoDeEntrada = int.Parse(cboTipo.SelectedValue.ToString());
            ent.Numero = int.Parse(txtNumero.Text);
            ent.Descripcion = txtDescripcion.Text.Trim();
            ent.Fecha = txtFecha.Text;
            ent.Detalles = ObtenerDetallesDelGrid();

            if (ent.Detalles.Count > 0)
            {
                int r = rep.Grabar(ent);

                if (r > 0)
                {
                    MessageBox.Show("Cambios realizados");
                }
            }
        }

        private void txtNumero_TextChanged(object sender, EventArgs e)
        {
            int Id = rep.GetId(int.Parse(txtNumero.Text));
            if (Id > 0)
                CargarEntradaExistente(Id);
       
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmEntradasR EntradasR = new frmEntradasR();
            int Numero = int.Parse(txtNumero.Text);
            EntradasR.SetNumber(Numero);
            EntradasR.Show();
        }
       
    }

    
  

}
