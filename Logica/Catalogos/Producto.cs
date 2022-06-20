using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Datos;

namespace Logica
{
    public class Producto
    {
        
        public ProductosVM GetProducto(int ProductoId)
        {
            ProductosVM producto = new ProductosVM();

            Conexion con = new Conexion();

            SqlCommand cmd0 = new SqlCommand(string.Format("SELECT Id,DescripcionDelProducto,CategoriaId,Existencia,Costo,PorcentajeUtilidad,CodigoDelProducto FROM PRODUCTOS WHERE Id ={0}", ProductoId), con.getConexion());

            DataSet dataset = new DataSet();
            dataset.Tables.Add("Productos");

            try
            {
                SqlDataAdapter adap = new SqlDataAdapter();
                adap.SelectCommand = cmd0;
                adap.Fill(dataset.Tables["Productos"]);

                producto = dataset.Tables["Productos"].AsEnumerable().Select(s => new ProductosVM
                {
                    ProductoId = s.Field<int>("Id"),
                    DescripcionDelProducto = s.Field<string>("DescripcionDelProducto"),
                    TipoDeCategoria = s.Field<int>("CategoriaId"),
                    Codigo = s.Field<string>("CodigoDelProducto"),
                    Costo = s.Field<decimal>("costo"),
                    Existencia = s.Field<int>("Existencia"),
                    Utilidad = s.Field<decimal>("PorcentajeUtilidad"),
                }).FirstOrDefault();

            }
            catch (Exception e)
            {

            }
            finally { con.CerrarConexion(); }
            return producto;
        }
        public List<CategoriasVW> GetTiposDeCategoria()
        {
            Conexion con = new Conexion();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.getConexion();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT Id,DescripcionDeCategoria FROM Categorias";
            List<CategoriasVW> lista = new List<CategoriasVW>();
            DataSet dataset = new DataSet();
            try
            {
                SqlDataAdapter adap = new SqlDataAdapter(cmd);

                adap.Fill(dataset, "Tipo");

                lista = dataset.Tables["Tipo"].AsEnumerable().Select(s => new CategoriasVW
                {
                    Id = s.Field<int>("Id"),
                    Descripcion = s.Field<string>("DescripcionDeCategoria")
                }).ToList();
            }
            catch (Exception e)
            {

            }
            finally { con.CerrarConexion(); }
            return lista;
        }
        public int Grabar(ProductosVM producto)
        {
            int res = -1;

            try
            {
                using (var conn = new Conexion().getConexion())
                {
                    using (var cmd = new SqlCommand("spProducto", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;

                        cmd.Parameters.Add(new SqlParameter("@ProductoId", producto.ProductoId));
                        cmd.Parameters.Add(new SqlParameter("@TipoDeCategoriaId", producto.TipoDeCategoria));
                        cmd.Parameters.Add(new SqlParameter("@Descripcion", producto.DescripcionDelProducto));
                        cmd.Parameters.Add(new SqlParameter("@Numero", producto.Codigo));
                        cmd.Parameters.Add(new SqlParameter("@Utilidad", producto.Utilidad));
                        cmd.Parameters.Add(new SqlParameter("@Costo", producto.Costo));
                        cmd.Parameters.Add(new SqlParameter("@Existencia", producto.Existencia));

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
        //aqui empeso la clase lo que vamos ha hacer es buscar por numero de entrada
        public int GetId(int Numero)
        {
            BuscarIdProducto BuscarIdProducto = new BuscarIdProducto();
            Conexion con = new Conexion();
            SqlCommand cmd = new SqlCommand(string.Format("select Id from Productos where CodigoDelProducto = {0}", Numero), con.getConexion());


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
                    BuscarIdProducto = dataset.Tables["Encontrar"].AsEnumerable().Select(s => new BuscarIdProducto
                    {
                        Id2 = s.Field<int>("Id")
                    }).FirstOrDefault();

                    return BuscarIdProducto.Id2;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally { con.CerrarConexion(); }

        }// fin 
    }
}


