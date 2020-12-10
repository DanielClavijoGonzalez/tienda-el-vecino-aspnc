using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyectv.Models
{
    public class ProductosAdquiridos
    {
        public int id { get; set; }
        public string anio { get; set; }
        public string mes { get; set; }
        public string dia { get; set; }
        public int codigo_producto_adquirido { get; set; }
        public int id_vendedor_producto { get; set; }
        public int id_comprador_producto { get; set; }
        public string nombre_producto_adquirido { get; set; }
        public string imagen_producto_adquirido { get; set; }
        public string descripcion_producto_adquirido { get; set; }
        public double precio_producto_adquirido { get; set; }
        public string cantidad_producto_adquirido { get; set; }
        public double valor_total_pagado { get; set; }
    }
}
