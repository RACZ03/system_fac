using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Logica
{
    public class SalidaVM
    {
        public int SalidaId { get; set; }
        public int TipoDeSalida { get; set; }
        public int Numero { get; set; }

        public string Descripcion { get; set; }
        public string Fecha { get; set; }
        public List<DetalleSVW> Detalle { get; set; }
    }
    public class TipoDeSalidaVW
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }

    public class ProductoSVW
    {
        public int Id { get; set; }
        public decimal Costo { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
    }

    public class DetalleSVW
    {
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }

        public decimal Costo { get; set; }

        public decimal Utilidad { get; set; }
        public int ProductoId { get; set; }
        public string Producto { get; set; }

    }
    public class BuscarIdSalida
    {
        public int Id { get; set; }
    }
}
