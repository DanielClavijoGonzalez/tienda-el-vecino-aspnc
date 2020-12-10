using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using proyectv.Models;
using MySql.Data.MySqlClient;
using System.Data;

namespace proyectv.Controllers
{
    public class MisProductos : Controller
    {
        DataTable dt = new DataTable();
        Basedatos bd = new Basedatos();
        Basedatos bdc = new Basedatos();
        Basedatos bdp = new Basedatos();
        int valor_a_pagar = 0;
        public IActionResult Index()
        {
            Select();

            #region ListaDeProductos

            List<ProductosAdquiridos> productosadquiridoslist = new List<ProductosAdquiridos>();
            productosadquiridoslist = (from DataRow dr in dt.Rows
                           select new ProductosAdquiridos()
                           {
                               id = Convert.ToInt32(dr["id"]),
                               anio = (dr["anio"]).ToString(),
                               mes = (dr["mes"]).ToString(),
                               dia = (dr["dia"]).ToString(),
                               codigo_producto_adquirido = Convert.ToInt32(dr["codigo_producto_adquirido"]),
                               id_vendedor_producto = Convert.ToInt32(dr["id_vendedor_producto"]),
                               id_comprador_producto = Convert.ToInt32(dr["id_comprador_producto"]),
                               nombre_producto_adquirido = dr["nombre_producto_adquirido"].ToString(),
                               imagen_producto_adquirido = dr["imagen_producto_adquirido"].ToString(),
                               descripcion_producto_adquirido = (dr["descripcion_producto_adquirido"]).ToString(),
                               precio_producto_adquirido = Convert.ToDouble(dr["precio_producto_adquirido"]),
                               cantidad_producto_adquirido = (dr["cantidad_producto_adquirido"]).ToString(),
                               valor_total_pagado = Convert.ToDouble(dr["valor_total_pagado"]),
                           }).ToList();
            #endregion

            #region Content
            string idSession = HttpContext.Session.GetString("idSession");
            if (idSession != null)
            {
                #region LecturaUsuarios
                string query = "SELECT * FROM usuario WHERE id='" + idSession + "'";
                MySqlCommand comando = new MySqlCommand(query, bd.connectiondatabase);
                MySqlDataReader leer;
                leer = comando.ExecuteReader();
                #endregion

                if (leer.Read())
                {
                    if (leer.GetString(7) == "1")
                    {
                        ViewBag.messaged = "Redireccion aqui por parte de el area de cliente";
                        bd.connectiondatabase.Close();
                        return Redirect("/Vendedor");
                    }
                    else
                    {
                        if (leer.GetString(7) == "2")
                        {
                            #region LecturaCarrito
                            /*bd.connectiondatabase.Open();*/
                            string queryCarritoFind = "select c.*, p.id as id_producto, p.precio_producto, (c.cantidad_producto * p.precio_producto) as valor_a_pagar from carrito c, productos p, usuario u where c.codigo_producto_carrito=p.id and c.id_comprador=u.id and c.id_comprador= '" + idSession + "'";
                            bdc.connectiondatabase.Open();
                            MySqlCommand comandoCarrito = new MySqlCommand(queryCarritoFind, bdc.connectiondatabase);
                            MySqlDataReader leerCarrito;
                            leerCarrito = comandoCarrito.ExecuteReader();
                            leerCarrito.Read();
                            #endregion

                            if (leerCarrito.HasRows)
                            {
                                #region LecturaProductos
                                bdp.connectiondatabase.Open();
                                string queryProductos = "SELECT * FROM productos WHERE id='" + leerCarrito.GetString(1) + "'";
                                /*bdc.connectiondatabase.Open();*/
                                MySqlCommand comandoProductos = new MySqlCommand(queryProductos, bdp.connectiondatabase);
                                MySqlDataReader leerProductos;
                                leerProductos = comandoProductos.ExecuteReader();
                                leerProductos.Read();
                                #endregion

                                #region RevExistenciaProducto-Asign-Valor
                                if (leerProductos.HasRows)
                                {
                                    leerCarrito.Close();
                                    leerCarrito = comandoCarrito.ExecuteReader();

                                    while (leerCarrito.Read())
                                    {
                                        valor_a_pagar += leerCarrito.GetInt32(6);
                                    }

                                    #region HayCarritoDisponible

                                    ViewData["nombre"] = leer.GetString(1);
                                    ViewData["imagen_perfil"] = leer.GetString(8);
                                    ViewData["valor_a_pagar"] = valor_a_pagar;
                                    ViewData["estado_misproductos"] = "";
                                    if (productosadquiridoslist.Count <= 0) ViewData["estado_misproductos"] = "No has comprado nada, haz tu primera compra :)";

                                    bd.connectiondatabase.Close();
                                    bdp.connectiondatabase.Close();
                                    bdc.connectiondatabase.Close();
                                    return View(productosadquiridoslist);
                                    #endregion
                                }
                                else
                                {
                                    // Problema: No existe el producto para añadir el valor a pagar, error de ID
                                    return Redirect("/Cliente");
                                }
                                #endregion
                            }
                            else
                            {
                                #region NoHayCarritoDisponible

                                ViewData["nombre"] = leer.GetString(1);
                                ViewData["imagen_perfil"] = leer.GetString(8);
                                ViewData["valor_a_pagar"] = valor_a_pagar;
                                ViewData["estado_misproductos"] = "";
                                if (productosadquiridoslist.Count <= 0) ViewData["estado_misproductos"] = "No has comprado nada, haz tu primera compra :)";

                                bd.connectiondatabase.Close();
                                bdp.connectiondatabase.Close();
                                bdc.connectiondatabase.Close();
                                return View(productosadquiridoslist);
                                #endregion
                            }
                        }
                        else
                        {
                            #region NoExisteLaSesion
                            // problema: No se ha encontrado el valor de la session en la DB.
                            HttpContext.Session.Clear();
                            ViewBag.error = "Error: No se ha encontrado el rol: " + idSession;
                            bd.connectiondatabase.Close();
                            return Redirect("/IniciarSesion");
                            #endregion
                        }
                    }
                }
                else
                {
                    #region NoExisteLaSesion
                    // problema: No se ha encontrado el valor de la session en la DB.
                    HttpContext.Session.Clear();
                    ViewBag.error = "Error: No se ha encontrado el rol: " + idSession;
                    bd.connectiondatabase.Close();
                    return Redirect("/IniciarSesion");
                    #endregion
                }
            }
            else
            {
                // No hay session
                return Redirect("/IniciarSesion");
            }
            #endregion
        }

        public void Select()
        {
            string idSession2 = HttpContext.Session.GetString("idSession");
            string query = "SELECT id, YEAR(fecha_de_compra) as anio, MONTH(fecha_de_compra) as mes, DATE_FORMAT(fecha_de_compra, '%d') as dia, codigo_producto_adquirido, id_vendedor_producto, id_comprador_producto, nombre_producto_adquirido, imagen_producto_adquirido, descripcion_producto_adquirido, precio_producto_adquirido, cantidad_producto_adquirido, valor_total_pagado FROM productos_adquiridos WHERE id_comprador_producto ='" + idSession2 + "'";
            bd.connectiondatabase.Open();
            MySqlCommand comando = new MySqlCommand(query, bd.connectiondatabase);
            MySqlDataAdapter da = new MySqlDataAdapter(comando);
            da.Fill(dt);
        }
    }
}
