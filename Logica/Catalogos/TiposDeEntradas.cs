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
    public class TiposDeEntradas
    {
        

        public string CodigoTipoEntrada { get; set; }

        public string DescripcionTipoDeEntrada { get; set; }

        // Metodo para guardar Nuevo Registro

        public int NuevoTiposDeEntrada(TiposDeEntradas TiposDeEntradas)
        {
            DatosSistema datos = new DatosSistema();

            string[] parametros = { "@Ope", "@CodigoTipoEntrada", "@DescripcionTipoDeEntrada" };

            return datos.Ejecutar("dbo.spTipoDeEntradas",
                parametros, "I",
                TiposDeEntradas.CodigoTipoEntrada,
                TiposDeEntradas.DescripcionTipoDeEntrada);
        }

        public int ActualizarTiposDeEntrada(TiposDeEntradas TiposDeEntradas)
        {
            DatosSistema datos = new DatosSistema();

            string[] parametros = { "@Ope", "@CodigoTipoEntrada", "@DescripcionTipoDeEntrada" };

            return datos.Ejecutar("dbo.spTipoDeEntradas",
                parametros, "A",
                TiposDeEntradas.CodigoTipoEntrada,
                TiposDeEntradas.DescripcionTipoDeEntrada);
        }

        //Metodo para Eliminar el Registro
        public int EliminarTiposDeEntrada(TiposDeEntradas TiposDeEntradas)
        {
            DatosSistema datos = new DatosSistema();

            string[] parametros = { "@Ope", "@CodigoTipoEntrada", "@DescripcionTipoDeEntrada" };

            return datos.Ejecutar("dbo.spTipoDeEntradas",
                parametros, "E",
                TiposDeEntradas.CodigoTipoEntrada,
                TiposDeEntradas.DescripcionTipoDeEntrada);
        }

        //Metodo de consultar un Registro

        public int getTiposDeEntrada(TiposDeEntradas t)
        {
            DatosSistema datos = new DatosSistema();

            TiposDeEntradas TiposDeentradas = new TiposDeEntradas();

            var dt = new DataTable();

            string[] parametros = { "@Ope", "@CodigoTipoEntrada", "@DescripcionTipoDeEntrada" };

            dt = datos.getDatosTable("dbo.spTipoDeEntradas",
                parametros, "S",
                t.CodigoTipoEntrada,
                "");

            foreach(DataRow fila in dt.Rows)
            {
                this.CodigoTipoEntrada = fila["CodigoTipoEntrada"].ToString();
                this.DescripcionTipoDeEntrada= fila["DescripcionTipoDeEntrada"].ToString();
            }

            return dt.Rows.Count > 0 ? Convert.ToInt32(this.CodigoTipoEntrada): -1;
        }
    }
}
