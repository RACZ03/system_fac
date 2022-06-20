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

        public string CodigoTipoSalida { get; set; }

        public string DescripcionTipoDeSalida { get; set; }

        // Metodo para guardar Nuevo Registrar
        public int NuevoTiposDeSalida(TiposDeSalidas TiposDeSalidas)
        {
            DatosSistema datos = new DatosSistema();

            string[] parametros = { "@Ope", "@CodigoTipoSalida", "@DescripcionTipoDeSalida" };

            return datos.Ejecutar("dbo.spTipoDeSalidas",
                parametros, "I",
                TiposDeSalidas.CodigoTipoSalida,
                TiposDeSalidas.DescripcionTipoDeSalida
                );
        }

        public int ActualizarTiposDeSalidas(TiposDeSalidas TiposDeSalidas)
        {
            DatosSistema datos = new DatosSistema();

            string[] parametros = { "@Ope", "@CodigoTipoSalida", "@DescripcionTipoDeSalida" };

            return datos.Ejecutar("dbo.spTipoDeSalidas",
                parametros, "A",
                TiposDeSalidas.CodigoTipoSalida,
                TiposDeSalidas.DescripcionTipoDeSalida);
        }

        //Metodo para Eliminar el Registro
        public int EliminarTiposDeSalida(TiposDeSalidas TiposDeSalidas)
        {
            DatosSistema datos = new DatosSistema();

            string[] parametros = { "@Ope", "@CodigoTipoSalida", "@DescripcionTipoDeSalida" };

            return datos.Ejecutar("dbo.spTipoDeSalidas",
                parametros, "E",
                TiposDeSalidas.CodigoTipoSalida,
                TiposDeSalidas.DescripcionTipoDeSalida);
        }

        //Metodo de consultar un Registro

        public int getTiposDeSalida(TiposDeSalidas t)
        {
            DatosSistema datos = new DatosSistema();

            TiposDeSalidas TiposDeSalidas = new TiposDeSalidas();

            var dt = new DataTable();

            string[] parametros = { "@Ope", "@CodigoTipoSalida", "@DescripcionTipoDeSalida" };

            dt = datos.getDatosTable("dbo.spTipoDeSalidas",
                parametros, "S",
                t.CodigoTipoSalida,
                "");

            foreach (DataRow fila in dt.Rows)
            {
                this.CodigoTipoSalida = fila["CodigoTipoSalida"].ToString();
                this.DescripcionTipoDeSalida = fila["DescripcionTipoDeSalida"].ToString();
            }
            return dt.Rows.Count > 0 ? Convert.ToInt32(this.CodigoTipoSalida ): -1;
        }
    }
}