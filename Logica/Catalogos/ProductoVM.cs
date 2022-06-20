using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Datos;

namespace Logica
{
    public class CategoriasVW
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

    }

    public class ProductosVM
    {
        public int ProductoId { get; set; }
        public string Codigo { get; set; }
        public int Existencia { get; set; }
        public decimal Costo { get; set; }
        public decimal Utilidad { get; set; }
        public int TipoDeCategoria { get; set; }
        public string DescripcionDelProducto { get; set; }
        
    }

   public class BuscarIdProducto
   {
       public int Id2 { get; set; }
   }
  
}
