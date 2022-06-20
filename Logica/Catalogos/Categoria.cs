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

    public class Categoria
    {
        public string CodigoDeLaCategoria{ get; set; }

        public string DescripcionDeCategoria { get; set; }


        // Metodo para guardar Nuevo Registro
        public int NuevaCategoria(Categoria Categoria)
        {
            DatosSistema datos = new DatosSistema();

            string[] parametros = { "@Ope", "@CodigoDeLaCategoria", "@DescripcionDeCategoria" };

            return datos.Ejecutar("dbo.spCategoria",
                parametros, "I",
                Categoria.CodigoDeLaCategoria,
                Categoria.DescripcionDeCategoria);
        }

        // Actualizar un registro
        public int ActualizarCategoria(Categoria Categoria)
        {
            DatosSistema datos = new DatosSistema();

            string[] parametros = { "@Ope", "@CodigoDeLaCategoria", "@DescripcionDeCategoria" };

            return datos.Ejecutar("dbo.spCategoria",
                parametros, "A",
                Categoria.CodigoDeLaCategoria,
                Categoria.DescripcionDeCategoria);
        }

        //Eliminar categoria
        public int EliminarCategoria(Categoria Categoria)
        {
            DatosSistema datos = new DatosSistema();

            string[] parametros = { "@Ope", "@CodigoDeLaCategoria", "@DescripcionDeCategoria" };

            return datos.Ejecutar("dbo.spCategoria",
                parametros, "E",
                Categoria.CodigoDeLaCategoria,
                Categoria.DescripcionDeCategoria);
        }

        //Metodo de consultar un Registro

        public int getCategoria(Categoria C)
        {
            DatosSistema datos = new DatosSistema();

            Categoria Categoria = new Categoria();

            var dt = new DataTable();

            string[] parametros = { "@Ope", "@CodigoDeLaCategoria", "@DescripcionDeCategoria" };

            dt = datos.getDatosTable("dbo.spCategoria",
                parametros, "S",
                C.CodigoDeLaCategoria,
                "");

            foreach (DataRow fila in dt.Rows)
            {

                this.CodigoDeLaCategoria = fila["CodigoDeLaCategoria"].ToString();
                this.DescripcionDeCategoria = fila["DescripcionDeCategoria"].ToString();
            }

            return dt.Rows.Count > 0 ? Convert.ToInt32(this.CodigoDeLaCategoria) : -1;
        }
    }
}
