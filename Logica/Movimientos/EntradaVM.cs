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
    public class EntradaVM
    {
        public int EntradaId { get; set; }
        public int TipoDeEntrada { get; set; }
        public int Numero { get; set; }

        public string Descripcion { get; set; }
        public string Fecha{get; set;}
        public List<DetalleVW> Detalles { get; set; }

    }

    public class TipoDeEntradaVW
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }

    public class ProductoVW
    {
        public int Id { get; set; }
        public decimal Costo { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
    }

    public class DetalleVW
    {
        public int Cantidad {get; set;}
        public decimal Costo {get; set;}
        public int ProductoId { get; set; }
        public string Producto {get; set;}
    }

    public class BuscarId
    {
        public int Id { get; set; }
    }
        
}
