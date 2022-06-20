using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Logica;

using Interfaz.Reportes;
namespace Interfaz
{
    public partial class frmSalida : Form
    {
        SalidaRepositorio rep = new SalidaRepositorio();

        public SalidaVM ent = new SalidaVM();
        public frmSalida()
        {
            InitializeComponent();
        }

        private void frmSalida_Load(object sender, EventArgs e)
        {
            cboTipo.DataSource = rep.GetTiposDeSalida();
            cboTipo.DisplayMember = "Descripcion";
            cboTipo.ValueMember = "Id";


            dgvDetalle.Columns.Add("ProductoId", "ProductoId");
            dgvDetalle.Columns.Add("Precio", "Precio");
            dgvDetalle.Columns.Add("CostoDelProducto", "CostoDelProducto");
            dgvDetalle.Columns.Add("Utilidad", "Utilidad");
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
            //CargarSalidaExistente(5);
            //***************************************************************
        }
        public void CargarSalidaExistente(int EntradaId)
        {
            ent = rep.GetSalida(EntradaId);

            txtDescripcion.Text = ent.Descripcion;
            txtFecha.Text = ent.Fecha;
            txtNumero.Text = ent.Numero.ToString();
            cboTipo.SelectedValue = ent.TipoDeSalida;
            foreach (var item in ent.Detalle)
            {
                dgvDetalle.Rows.Add(item.ProductoId,item.Precio, item.Costo, item.Utilidad,item.Cantidad ,item.Producto);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var ids = ObtenerDetallesDelGrid().Select(s => s.ProductoId).ToList();

            frmDetalleSalida frmDetalleSalida = new frmDetalleSalida();
            frmDetalleSalida.cboProducto.DataSource = rep.GetProductos().Where(w => !ids.Contains(w.Id)).ToList();
            frmDetalleSalida.cboProducto.DisplayMember = "Nombre";
            frmDetalleSalida.cboProducto.ValueMember = "Id";
            if (frmDetalleSalida.ShowDialog() == DialogResult.OK)
            {
                dgvDetalle.Rows.Add(frmDetalleSalida.cboProducto.SelectedValue.ToString(), frmDetalleSalida.txtPrecio.Text,
                    frmDetalleSalida.txtCantidad.Text,frmDetalleSalida.txtCosto.Text,frmDetalleSalida.txtUtilidad.Text,
                    frmDetalleSalida.cboProducto.Text);
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
                        frmDetalleSalida frmDetalleSalida = new frmDetalleSalida();

                        frmDetalleSalida.cboProducto.DataSource = rep.GetProductos().Where(w => !ids.Contains(w.Id)).ToList();
                        frmDetalleSalida.cboProducto.DisplayMember = "Nombre";
                        frmDetalleSalida.cboProducto.ValueMember = "Id";
                        //asignar valores de la fila del grid a los campos del formulario
                        frmDetalleSalida.cboProducto.SelectedValue = id_producto;
                        frmDetalleSalida.txtCantidad.Text = dgvDetalle.Rows[e.RowIndex].Cells["Cantidad"].Value.ToString();
                        frmDetalleSalida.txtPrecio.Text = dgvDetalle.Rows[e.RowIndex].Cells["Precio"].Value.ToString();
                        frmDetalleSalida.txtCosto.Text = dgvDetalle.Rows[e.RowIndex].Cells["Costo"].Value.ToString();
                        frmDetalleSalida.txtUtilidad.Text = dgvDetalle.Rows[e.RowIndex].Cells["Utilidad"].Value.ToString();

                        if (frmDetalleSalida.ShowDialog() == DialogResult.OK)
                        {
                            dgvDetalle.Rows[e.RowIndex].Cells["ProductoId"].Value = frmDetalleSalida.cboProducto.SelectedValue;
                            dgvDetalle.Rows[e.RowIndex].Cells["Producto"].Value = frmDetalleSalida.cboProducto.Text;
                            dgvDetalle.Rows[e.RowIndex].Cells["Cantidad"].Value = frmDetalleSalida.txtCantidad.Text;
                            dgvDetalle.Rows[e.RowIndex].Cells["Precio"].Value = frmDetalleSalida.txtPrecio.Text;
                            dgvDetalle.Rows[e.RowIndex].Cells["Costo"].Value = frmDetalleSalida.txtCosto.Text;
                            dgvDetalle.Rows[e.RowIndex].Cells["Utilidad"].Value = frmDetalleSalida.txtUtilidad.Text;
                        }
                    }
                    catch { }
                }
            }
        }
        public List<DetalleSVW> ObtenerDetallesDelGrid()
        {
            List<DetalleSVW> data = new List<DetalleSVW>();
            for (int i = 0; i < dgvDetalle.Rows.Count; i++)
            {
                data.Add(new DetalleSVW()
                {
                    ProductoId = int.Parse(dgvDetalle.Rows[i].Cells["ProductoId"].Value.ToString()),
                    Cantidad = int.Parse(dgvDetalle.Rows[i].Cells["Cantidad"].Value.ToString()),
                    Precio = decimal.Parse(dgvDetalle.Rows[i].Cells["Precio"].Value.ToString()),
                    Costo = decimal.Parse(dgvDetalle.Rows[i].Cells["Costo"].Value.ToString()),
                    Utilidad = decimal.Parse(dgvDetalle.Rows[i].Cells["Utilidad"].Value.ToString()),
                    Producto = dgvDetalle.Rows[i].Cells["Producto"].Value.ToString()
                });
            }
            return data;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
           
            ent.Numero = int.Parse(txtNumero.Text);
            ent.TipoDeSalida = int.Parse(cboTipo.SelectedValue.ToString());
            ent.Descripcion = txtDescripcion.Text.Trim();
            ent.Fecha = txtFecha.Text;
            ent.Detalle = ObtenerDetallesDelGrid();

            if (ent.Detalle.Count > 0)
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
            if(Id>0)
            CargarSalidaExistente(Id);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            frmSalidasR SalidasR = new frmSalidasR();
            int Numero = int.Parse(txtNumero.Text);
            SalidasR.SetNumber(Numero);
            SalidasR.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
       }

    }


