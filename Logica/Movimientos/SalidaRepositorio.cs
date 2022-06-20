using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.Data.SqlClient;
using System.Data;

namespace Logica
{
    public class SalidaRepositorio
    {
        public SalidaVM GetSalida(int SalidaId)
        {
            SalidaVM salida = new SalidaVM();

            Conexion con = new Conexion();

            SqlCommand cmd0 = new SqlCommand(string.Format("SELECT Id,DescripcionDeSalida,CONVERT(VARCHAR,FechaDeSalida,103) AS Fecha,NumeroDeSalida,TipoDeSalidaId FROM Salidas WHERE Id={0}", SalidaId), con.getConexion());

            SqlCommand cmd = new SqlCommand(string.Format("SELECT PrecioDeSalida, CostoDelProducto, UtilidadDelProducto,CantidadDeSalida,ProductoId,P.DescripcionDelProducto FROM	DetallesDeSalidas D INNER JOIN	Productos AS P ON D.ProductoId=P.Id WHERE SalidaId={0}", SalidaId), cmd0.Connection);

            DataSet dataset = new DataSet();
            dataset.Tables.Add("Salida");
            dataset.Tables.Add("Detalle");

            try
            {
                SqlDataAdapter adap = new SqlDataAdapter();
                adap.SelectCommand = cmd0;
                adap.Fill(dataset.Tables["Salida"]);
                adap.SelectCommand = cmd;
                adap.Fill(dataset.Tables["Detalle"]);

                salida= dataset.Tables["Salida"].AsEnumerable().Select(s => new SalidaVM
                {
                    SalidaId = s.Field<int>("Id"),
                    Descripcion = s.Field<string>("DescripcionDeSalida"),
                    Fecha = s.Field<string>("Fecha"),
                    Numero = s.Field<int>("NumeroDeSalida"),
                    TipoDeSalida = s.Field<int>("TipoDeSalidaId")
                }).FirstOrDefault();

                salida.Detalle = dataset.Tables["Detalle"].AsEnumerable().Select(s => new DetalleSVW
                {
                    ProductoId = s.Field<int>("ProductoId"),
                    Producto = s.Field<string>("DescripcionDelProducto"),
                    Precio = s.Field<decimal>("PrecioDeSalida"),//Add
                    Costo = s.Field<decimal>("CostoDelProducto"),
                    Utilidad = s.Field<decimal>("UtilidadDelProducto"),
                    Cantidad = s.Field<int>("CantidadDeSalida")
                }).ToList();
            }
            catch (Exception e)
            {

            }
            finally { con.CerrarConexion(); }
            return salida;
        }
        public List<TipoDeSalidaVW> GetTiposDeSalida()
        {
            Conexion con = new Conexion();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.getConexion();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Id,DescripcionTipoDeSalida FROM TiposDeSalidas";
            List<TipoDeSalidaVW> lista = new List<TipoDeSalidaVW>();
            DataSet dataset = new DataSet();
            try
            {
                SqlDataAdapter adap = new SqlDataAdapter(cmd);

                adap.Fill(dataset, "Tipo");

                lista = dataset.Tables["Tipo"].AsEnumerable().Select(s => new TipoDeSalidaVW
                {
                    Id = s.Field<int>("Id"),
                    Descripcion = s.Field<string>("DescripcionTipoDeSalida")
                }).ToList();
            }
            catch (Exception e)
            {

            }
            finally { con.CerrarConexion(); }
            return lista;
        }
        public List<ProductoSVW> GetProductos()
        {
            Conexion con = new Conexion();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.getConexion();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Id,CodigoDelProducto,costo,DescripcionDelProducto FROM Productos";
            List<ProductoSVW> lista = new List<ProductoSVW>();
            DataSet dataset = new DataSet();
            try
            {
                SqlDataAdapter adap = new SqlDataAdapter(cmd);

                adap.Fill(dataset, "Producto");

                lista = dataset.Tables["Producto"].AsEnumerable().Select(s => new ProductoSVW
                {
                    Id = s.Field<int>("Id"),
                    Nombre = s.Field<string>("DescripcionDelProducto"),
                    Codigo = s.Field<string>("CodigoDelProducto"),
                    Costo = s.Field<decimal>("costo")
                }).ToList();
            }
            catch (Exception e)
            {

            }
            finally { con.CerrarConexion(); }
            return lista;
        }
        public int Grabar(SalidaVM salida)
        {
            int res = -1;
            DataTable TabDetalle = new DataTable();
            TabDetalle.Columns.Add("ProductoId", typeof(int));
            TabDetalle.Columns.Add("PrecioDeSalida", typeof(decimal));
            TabDetalle.Columns.Add("CostoDelProducto", typeof(decimal));
            TabDetalle.Columns.Add("UtilidadDelProducto", typeof(decimal));
            TabDetalle.Columns.Add("CantidadDeSalida", typeof(int));
            foreach (var item in salida.Detalle)
            {
                TabDetalle.Rows.Add(item.ProductoId,item.Precio, item.Costo,item.Utilidad, item.Cantidad);
            }
            try
            {
                using (var conn = new Conexion().getConexion())
                {
                    using (var cmd = new SqlCommand("Salida", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;

                        cmd.Parameters.Add(new SqlParameter("@SalidaId", salida.SalidaId));
                        cmd.Parameters.Add(new SqlParameter("@TipoDeSalidaId", salida.TipoDeSalida));
                        cmd.Parameters.Add(new SqlParameter("@Descripcion", salida.Descripcion));
                        cmd.Parameters.Add(new SqlParameter("@Numero", salida.Numero));
                        cmd.Parameters.Add(new SqlParameter("@Fecha", salida.Fecha));

                        SqlParameter us = new SqlParameter("@Detalle", TabDetalle);
                        us.TypeName = "dbo.TDetalleDeSalida";

                        cmd.Parameters.Add(us);
                        if (conn.State != ConnectionState.Open) conn.Open();
                        res = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return res;
        }
        public int GetId(int Numero)
        {
            BuscarIdSalida BuscarIdSalida = new BuscarIdSalida();
            Conexion con = new Conexion();
            SqlCommand cmd = new SqlCommand(string.Format("Select Id from Salidas where NumeroDeSalida = {0}", Numero), con.getConexion());


            DataSet dataset = new DataSet();
            dataset.Tables.Add("Encontrar");


            try
            {
                SqlDataAdapter adap = new SqlDataAdapter();
                adap.SelectCommand = cmd;
                adap.Fill(dataset.Tables["Encontrar"]);

                if (dataset.Tables[0].Rows.Count == 0)
                    return 0;
                else
                {
                    BuscarIdSalida = dataset.Tables["Encontrar"].AsEnumerable().Select(s => new BuscarIdSalida
                    {
                        Id = s.Field<int>("Id")
                    }
                    ).FirstOrDefault();

                    return BuscarIdSalida.Id;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally { con.CerrarConexion(); }

        }
    }
}
