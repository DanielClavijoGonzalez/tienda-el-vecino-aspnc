using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyectv.Models
{
    public class Productos
    {
        public int id { get; set; }
        public string nombre_producto { get; set; }
        public double precio_producto { get; set; }
        public string descripcion_producto { get; set; }
        public string imagen_producto { get; set; }
        public string cantidad_producto { get; set; }
        public int codigo_producto { get; set; }
    }
}
