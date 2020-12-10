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
    public class CarritoActual : Controller
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

            List<Carrito> carritolist = new List<Carrito>();
            carritolist = (from DataRow dr in dt.Rows
                            select new Carrito()
                            {
                                id = Convert.ToInt32(dr["id"]),
                                codigo_producto_carrito = Convert.ToInt32(dr["codigo_producto_carrito"]),
                                cantidad_producto = Convert.ToInt32(dr["cantidad_producto"]),
                                id_comprador = Convert.ToInt32(dr["id_comprador"]),
                                nombre_producto = dr["nombre_producto"].ToString(),
                                imagen_producto = dr["imagen_producto"].ToString(),
                                precio_producto = Convert.ToDouble(dr["precio_producto"])
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
                                    ViewData["estado_carrito"] = "";
                                    if (carritolist.Count <= 0) ViewData["estado_carrito"] = "Carrito vacio comienza añadiendo productos :)";

                                    bd.connectiondatabase.Close();
                                    bdp.connectiondatabase.Close();
                                    bdc.connectiondatabase.Close();
                                    return View(carritolist);
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
                                ViewData["estado_carrito"] = "";
                                if (carritolist.Count <= 0) ViewData["estado_carrito"] = "Carrito vacio comienza añadiendo productos :)";

                                bd.connectiondatabase.Close();
                                bdp.connectiondatabase.Close();
                                bdc.connectiondatabase.Close();
                                return View(carritolist);
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
            string idSession = HttpContext.Session.GetString("idSession");
            string query = "SELECT c.*, p.nombre_producto, p.imagen_producto, p.precio_producto FROM carrito c, productos p where c.codigo_producto_carrito=p.id and c.id_comprador ='" + idSession + "'";
            bd.connectiondatabase.Open();
            MySqlCommand comando = new MySqlCommand(query, bd.connectiondatabase);
            MySqlDataAdapter da = new MySqlDataAdapter(comando);
            da.Fill(dt);
        }
    }
}
