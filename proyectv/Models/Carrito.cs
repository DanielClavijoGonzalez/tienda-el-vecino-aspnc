using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyectv.Models
{
    public class Carrito
    {
        public int id { get; set; }
        public int codigo_producto_carrito { get; set; }
        public int cantidad_producto { get; set; }
        public int id_comprador { get; set; }
        public string nombre_producto { get; set; }
        public string imagen_producto { get; set; }
        public double precio_producto { get; set; }
    }
}
