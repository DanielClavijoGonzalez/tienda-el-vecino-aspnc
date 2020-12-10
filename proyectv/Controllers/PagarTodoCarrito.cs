using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using proyectv.Models;
using MySql.Data.MySqlClient;

namespace proyectv.Controllers
{
    public class PagarTodoCarrito : Controller
    {
        Basedatos bd = new Basedatos();
        Basedatos bdc = new Basedatos();
        Basedatos bdIP = new Basedatos();
        Basedatos bdBPC = new Basedatos();
        public IActionResult Index(/*int idCr = -1*/)
        {
            /*if (idCr <= 0) return Redirect("/CarritoActual");*/

            #region Content
            string idSession = HttpContext.Session.GetString("idSession");
            if (idSession != null)
            {
                #region LecturaUsuarios
                bd.connectiondatabase.Open();
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
                            #region Lectura Carrito Completo
                            bdc.connectiondatabase.Open();
                            string queryCarritoFind = "select CURDATE() as fecha_de_compra, p.id as codigo_producto_adquirido, p.codigo_producto as id_vendedor_producto, c.id_comprador as id_comprador_producto, p.nombre_producto as nombre_producto_adquirido, p.imagen_producto as imagen_producto_adquirido, p.descripcion_producto as descripcion_producto_adquirido, p.precio_producto as precio_producto_adquirido, c.cantidad_producto as cantidad_producto_adquirido, (c.cantidad_producto * p.precio_producto) as valor_total_pagado from carrito c, productos p, usuario u where c.codigo_producto_carrito=p.id and c.id_comprador=u.id and c.id_comprador ='" + idSession + "'";
                            MySqlCommand comandoCarrito = new MySqlCommand(queryCarritoFind, bdc.connectiondatabase);
                            MySqlDataReader leerCarrito;
                            leerCarrito = comandoCarrito.ExecuteReader();
                            leerCarrito.Read();
                            #endregion

                            if (leerCarrito.HasRows)
                            {
                                #region Hay Carrito Disponible

                                #region Insertar Datos: Productos Adquiridos
                                leerCarrito.Close();
                                leerCarrito = comandoCarrito.ExecuteReader();
                                bdIP.connectiondatabase.Open();
                                while (leerCarrito.Read())
                                {
                                    string queryIP = "INSERT INTO `productos_adquiridos` (`id`,`fecha_de_compra`, `codigo_producto_adquirido`, `id_vendedor_producto`, `id_comprador_producto`, `nombre_producto_adquirido`, `imagen_producto_adquirido`, `descripcion_producto_adquirido`,`precio_producto_adquirido`, `cantidad_producto_adquirido`, `valor_total_pagado`) VALUES(null, NOW(),'" + leerCarrito.GetInt32(1) + "','" + leerCarrito.GetInt32(2) + "','" + leerCarrito.GetInt32(3) + "','" + leerCarrito.GetString(4) + "','" + leerCarrito.GetString(5) + "','" + leerCarrito.GetString(6) + "','" + leerCarrito.GetDouble(7) + "','" + leerCarrito.GetInt32(8) + "','" + leerCarrito.GetDouble(9) + "')";
                                    MySqlCommand comandoIP = new MySqlCommand(queryIP, bdIP.connectiondatabase);
                                    MySqlDataReader leerIP;
                                    leerIP = comandoIP.ExecuteReader();
                                    leerIP.Close();
                                }
                                #endregion

                                #region Borrar Productos Del Carrito
                                bdBPC.connectiondatabase.Open();
                                string queryBPC = "DELETE FROM carrito where(id_comprador ='" + idSession +"')";
                                MySqlCommand comandoBCP = new MySqlCommand(queryBPC, bdBPC.connectiondatabase);
                                MySqlDataReader leerBCP;
                                leerBCP = comandoBCP.ExecuteReader();
                                leerBCP.Read();
                                #endregion

                                bdc.connectiondatabase.Close();
                                bdBPC.connectiondatabase.Close();
                                bdIP.connectiondatabase.Close();
                                return Redirect("/MisProductos");
                                #endregion
                            }
                            else
                            {
                                #region NoHayCarritoDisponible
                                return Redirect("/CarritoActual");
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
    }
}
