using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class DatosSistema
    {
        public DataTable getDatosTable(String nomProcedimiento, string[] nomParametros, params object[]Valparametros)
        {
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            Conexion con = new Conexion();

            cmd.Connection = con.getConexion();
            cmd.CommandText = nomProcedimiento;
            cmd.CommandType = CommandType.StoredProcedure;

            if(nomProcedimiento.Length!=0 && nomParametros.Length==Valparametros.Length)
            {
                int i = 0;
                foreach (string parametros in nomParametros)
                    cmd.Parameters.AddWithValue(parametros, Valparametros[i++]);

                try
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    dt.Load(dr);
                    return dt;
                }
                catch(Exception)
                {
                    throw;
                }
            }
            return dt;
        }

        //Metodo para ejecutar Procedimiento

        public int Ejecutar(string nomProcedimiento, string[] nomParametros, params object[]Valparametros)
        {
            Conexion con = new Conexion();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.getConexion();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = nomProcedimiento;

            if(nomProcedimiento.Length!=0 && nomParametros.Length == Valparametros.Length)
            {
                int i = 0;
                foreach (string parametros in nomParametros)
                    cmd.Parameters.AddWithValue(parametros, Valparametros[i++]);
                try
                {
                    return cmd.ExecuteNonQuery();
                }
                catch(Exception)
                {
                    throw;
                }
            }
            return 0;
        }

    }
}
