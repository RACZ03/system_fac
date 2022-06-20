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
    public class EntradaRepositorio
    {
        public EntradaVM GetEntrada(int EntradaId)
        {
            EntradaVM entrada = new EntradaVM();

            Conexion con = new Conexion();

            SqlCommand cmd0 = new SqlCommand(string.Format("SELECT Id,DescripcionDeEntrada,CONVERT(VARCHAR,FechaDeEntrada,103) AS Fecha,TipoDeEntradaId,NumeroDeEntrada FROM Entradas WHERE Id={0}", EntradaId), con.getConexion());

            SqlCommand cmd = new SqlCommand(string.Format("SELECT PrecioDeEntrada,CantidadDeEntrada,ProductoId,P.DescripcionDelProducto FROM	DetallesDeEntradas D INNER JOIN	Productos AS P ON D.ProductoId=P.Id WHERE EntradaId={0}", EntradaId), cmd0.Connection);

            DataSet dataset = new DataSet();
            dataset.Tables.Add("Entrada");
            dataset.Tables.Add("Detalles");

            try
            {
                SqlDataAdapter adap = new SqlDataAdapter();
                adap.SelectCommand = cmd0;
                adap.Fill(dataset.Tables["Entrada"]);
                adap.SelectCommand = cmd;
                adap.Fill(dataset.Tables["Detalles"]);

                entrada = dataset.Tables["Entrada"].AsEnumerable().Select(s => new EntradaVM
                {
                    EntradaId = s.Field<int>("Id"),
                    Descripcion = s.Field<string>("DescripcionDeEntrada"),
                    Fecha = s.Field<string>("Fecha"),
                    TipoDeEntrada = s.Field<int>("TipoDeEntradaId"),
                    Numero = s.Field<int>("NumeroDeEntrada")
                }).FirstOrDefault();

                entrada.Detalles = dataset.Tables["Detalles"].AsEnumerable().Select(s => new DetalleVW
                {
                    ProductoId = s.Field<int>("ProductoId"),
                    Producto = s.Field<string>("DescripcionDelProducto"),
                    Costo = s.Field<decimal>("PrecioDeEntrada"),
                    Cantidad = s.Field<int>("CantidadDeEntrada")
                }).ToList();
            }
            catch (Exception e)
            {

            }
            finally { con.CerrarConexion(); }
            return entrada;
        }
        public List<TipoDeEntradaVW> GetTiposDeEntrada()
        {
            Conexion con = new Conexion();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.getConexion();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Id,DescripcionTipoDeEntrada FROM TiposDeentradas";
            List<TipoDeEntradaVW> lista = new List<TipoDeEntradaVW>();
            DataSet dataset = new DataSet();
            try
            {
                SqlDataAdapter adap = new SqlDataAdapter(cmd);

                adap.Fill(dataset, "Tipo");

                lista = dataset.Tables["Tipo"].AsEnumerable().Select(s => new TipoDeEntradaVW
                {
                    Id = s.Field<int>("Id"),
                    Descripcion = s.Field<string>("DescripcionTipoDeEntrada")
                }).ToList();
            }
            catch (Exception e)
            {

            }
            finally { con.CerrarConexion(); }
            return lista;
        }
        public List<ProductoVW> GetProductos()
        {
            Conexion con = new Conexion();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.getConexion();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Id,CodigoDelProducto,costo,DescripcionDelProducto FROM Productos";
            List<ProductoVW> lista = new List<ProductoVW>();
            DataSet dataset = new DataSet();
            try
            {
                SqlDataAdapter adap = new SqlDataAdapter(cmd);

                adap.Fill(dataset, "Producto");

                lista = dataset.Tables["Producto"].AsEnumerable().Select(s => new ProductoVW
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
        public int Grabar(EntradaVM entrada)
        {
            int res = -1;
            DataTable TabDetalle = new DataTable();
            TabDetalle.Columns.Add("ProductoId", typeof(int));
            TabDetalle.Columns.Add("PrecioDeEntrada", typeof(decimal));
            TabDetalle.Columns.Add("CantidadDeEntrada", typeof(int));
            foreach (var item in entrada.Detalles)
            {
                TabDetalle.Rows.Add(item.ProductoId, item.Costo, item.Cantidad);
            }
            try
            {
                using (var conn = new Conexion().getConexion())
                {
                    using (var cmd = new SqlCommand("Entrada", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;

                        cmd.Parameters.Add(new SqlParameter("@EntradaId", entrada.EntradaId));
                        cmd.Parameters.Add(new SqlParameter("@TipoDeEntradaId", entrada.TipoDeEntrada));
                        cmd.Parameters.Add(new SqlParameter("@Descripcion", entrada.Descripcion));
                        cmd.Parameters.Add(new SqlParameter("@Numero", entrada.Numero));
                        cmd.Parameters.Add(new SqlParameter("@Fecha", entrada.Fecha));

                        SqlParameter us = new SqlParameter("@Detalles", TabDetalle);
                        us.TypeName = "dbo.TDetalleDeEntrada";

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
            BuscarId BuscarId = new BuscarId();
            Conexion con = new Conexion();
            SqlCommand cmd = new SqlCommand(string.Format("Select Id from Entradas where NumeroDeEntrada = {0}", Numero), con.getConexion());
            

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
                    BuscarId = dataset.Tables["Encontrar"].AsEnumerable().Select(s => new BuscarId
                    {
                        Id = s.Field<int>("Id")
                    }
                    ).FirstOrDefault();

                    return BuscarId.Id;
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
    
