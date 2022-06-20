using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Datos
{
    public class Conexion
    {
        private SqlConnection con { get; set; }
        private string CadenaConexion()
        {
            return @"Data Source=DELL\ADMIN;Initial Catalog=Inventario;Integrated Security=True";
        }

        //Metodo para obtener la conexion

        public  SqlConnection getConexion()
        {
            try
            {
                con = new SqlConnection(CadenaConexion());
                 this.con.Open();
                return this.con;
            }
            catch(Exception)
            {
                return null;
            }
        }

        //Metodo para Cerrar Concexion

        public void CerrarConexion()
        {
            if(this.con != null)
            {
                this.con.Close();
            }
        }

    }
}
