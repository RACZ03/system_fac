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
    public class TiposDeSalidas
    {
        public int Id { get; set; }

        public string CodigoTipoSalida { get; set; }

        public string DescripcionTipoDeSalida { get; set; }

        // Metodo para guardar Nuevo Registrar
        public int NuevoTiposDeSalida(TiposDeSalidas TiposDeSalidas)
        {
            DatosSistema datos = new DatosSistema();

            string[] parametros = { "@Ope", "@Id", "@CodigoTipoSalida", "@DescripcionTipoDeSalida" };

            return datos.Ejecutar("dbo.spTipoDeSalidas",
                parametros, "I",
                TiposDeSalidas.Id,
                TiposDeSalidas.CodigoTipoSalida,
                TiposDeSalidas.DescripcionTipoDeSalida
                );
        }

        public int ActualizarTiposDeSalidas(TiposDeSalidas TiposDeSalidas)
        {
            DatosSistema datos = new DatosSistema();

            string[] parametros = { "@Ope", "@Id", "@CodigoTipoSalida", "@DescripcionTipoDeSalida" };

            return datos.Ejecutar("dbo.spTipoDeSalidas",
                parametros, "A",
                TiposDeSalidas.Id,
                TiposDeSalidas.CodigoTipoSalida,
                TiposDeSalidas.DescripcionTipoDeSalida);
        }

        //Metodo para Eliminar el Registro
        public int EliminarTiposDeSalida(TiposDeSalidas TiposDeSalidas)
        {
            DatosSistema datos = new DatosSistema();

            string[] parametros = { "@Ope", "@Id", "@CodigoTipoSalida", "@DescripcionTipoDeSalida" };

            return datos.Ejecutar("dbo.spTipoDeSalidas",
                parametros, "E",
                TiposDeSalidas.Id,
                TiposDeSalidas.CodigoTipoSalida,
                TiposDeSalidas.DescripcionTipoDeSalida);
        }

        //Metodo de consultar un Registro

        public int getTiposDeSalida(TiposDeSalidas t)
        {
            DatosSistema datos = new DatosSistema();

            TiposDeSalidas TiposDeSalidas = new TiposDeSalidas();

            var dt = new DataTable();

            string[] parametros = { "@Ope", "@Id", "@CodigoTipoSalida", "@DescripcionTipoDeSalida" };

            dt = datos.getDatosTable("dbo.spTipoDeSalidas",
                parametros, "S",
                t.Id,
                "",
                "");

            foreach (DataRow fila in dt.Rows)
            {
                this.Id = Convert.ToInt16(fila["Id"].ToString());
                this.CodigoTipoSalida = fila["CodigoTipoSalida"].ToString();
                this.DescripcionTipoDeSalida = fila["DescripcionTipoDeSalida"].ToString();
            }
            return dt.Rows.Count > 0 ? this.Id : -1;
        }
    }
}