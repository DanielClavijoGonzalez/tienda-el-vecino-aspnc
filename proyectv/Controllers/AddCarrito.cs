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
    public class AddCarrito : Controller
    {
        Basedatos bd = new Basedatos();
        Basedatos bdc = new Basedatos();
        Basedatos bdp = new Basedatos();
        Basedatos bdpAC = new Basedatos();
        Basedatos bdpAC2 = new Basedatos();
        Basedatos bdAQntP = new Basedatos();
        public IActionResult Index(int id = -1, int qnt = 0)
        {
            if (id == -1 || qnt == 0 || id <= -1 || qnt <= 0) return Redirect("/Cliente");

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
                            #region LecturaCarritoCompleto
                            /*bd.connectiondatabase.Open();*/
                            string queryCarritoFind = "select c.*, p.id as id_producto, p.precio_producto, (c.cantidad_producto * p.precio_producto) as valor_a_pagar from carrito c, productos p, usuario u where c.codigo_producto_carrito=p.id and c.id_comprador=u.id and c.id_comprador= '" + idSession + "'";
                            bdc.connectiondatabase.Open();
                            MySqlCommand comandoCarrito = new MySqlCommand(queryCarritoFind, bdc.connectiondatabase);
                            MySqlDataReader leerCarrito;
                            leerCarrito = comandoCarrito.ExecuteReader();
                            leerCarrito.Read();
                            #endregion

                            #region LecturaProductosAddAC
                            bdpAC.connectiondatabase.Open();
                            string queryLeerAC = "select * from productos where id='" + id + "'";
                            MySqlCommand comandoLeerAC = new MySqlCommand(queryLeerAC, bdpAC.connectiondatabase);
                            MySqlDataReader leerProductosAC;
                            leerProductosAC = comandoLeerAC.ExecuteReader();
                            leerProductosAC.Read();
                            #endregion

                            if (leerCarrito.HasRows)
                            {
                                #region RevExistenciaProductoRecibido
                                if (leerProductosAC.HasRows)
                                {
                                    leerCarrito.Close();

                                    #region HayCarritoDisponible -- >

                                    #region RevisarCantidadRecibida
                                    if (qnt <= leerProductosAC.GetInt32(5))
                                    {
                                        #region AddProductoAC
                                        bdpAC2.connectiondatabase.Open();
                                        string queryAddAC = "INSERT INTO carrito(`id`,`codigo_producto_carrito`,`cantidad_producto`,`id_comprador`) VALUES (NULL,'" + id + "','" + qnt + "','" + idSession + "')";
                                        MySqlCommand comandoAddAC = new MySqlCommand(queryAddAC, bdpAC2.connectiondatabase);
                                        MySqlDataReader AddProductoAC;
                                        AddProductoAC = comandoAddAC.ExecuteReader();
                                        AddProductoAC.Read();
                                        #endregion

                                        #region CambiarCantidadProducto
                                        string resultado = (leerProductosAC.GetInt32(5) - qnt).ToString();
                                        #region ActualizarCantidadProductos
                                        bdAQntP.connectiondatabase.Open();

                                        string queryActQntP = "UPDATE productos SET cantidad_producto ='" + resultado + "' WHERE (id ='" + id + "')";
                                        MySqlCommand comandoActQntP = new MySqlCommand(queryActQntP, bdAQntP.connectiondatabase);
                                        MySqlDataReader ActQntP;
                                        ActQntP = comandoActQntP.ExecuteReader();
                                        ActQntP.Read();
                                        #endregion

                                        bd.connectiondatabase.Close();
                                        bdp.connectiondatabase.Close();
                                        bdc.connectiondatabase.Close();
                                        bdpAC.connectiondatabase.Close();
                                        bdpAC2.connectiondatabase.Close();
                                        bdAQntP.connectiondatabase.Close();
                                        return Redirect("/Cliente");
                                        #endregion
                                    }
                                    else
                                    {
                                        // Problema: el producto excede la capacidad disponible
                                        bd.connectiondatabase.Close();
                                        bdp.connectiondatabase.Close();
                                        bdc.connectiondatabase.Close();
                                        bdpAC.connectiondatabase.Close();
                                        bdpAC2.connectiondatabase.Close();
                                        bdAQntP.connectiondatabase.Close();
                                        return Redirect("/Cliente");
                                    }
                                    #endregion

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

                                #region RevExistenciaProductoRecibido
                                if (leerProductosAC.HasRows)
                                {
                                    leerCarrito.Close();
                                    //leerCarrito = comandoCarrito.ExecuteReader()

                                    #region RevisarCantidadRecibida
                                    if (qnt <= leerProductosAC.GetInt32(5))
                                    {
                                        #region AddProductoAC
                                        bdpAC2.connectiondatabase.Open();
                                        string queryAddAC = "INSERT INTO carrito(`id`,`codigo_producto_carrito`,`cantidad_producto`,`id_comprador`) VALUES (NULL,'" + id + "','" + qnt + "','" + idSession + "')";
                                        MySqlCommand comandoAddAC = new MySqlCommand(queryAddAC, bdpAC2.connectiondatabase);
                                        MySqlDataReader AddProductoAC;
                                        AddProductoAC = comandoAddAC.ExecuteReader();
                                        AddProductoAC.Read();
                                        #endregion

                                        #region CambiarCantidadProducto
                                        string resultado = (leerProductosAC.GetInt32(5) - qnt).ToString();
                                        #region ActualizarCantidadProductos
                                        bdAQntP.connectiondatabase.Open();

                                        string queryActQntP = "UPDATE productos SET cantidad_producto ='" + resultado + "' WHERE (id ='" + id + "')";
                                        MySqlCommand comandoActQntP = new MySqlCommand(queryActQntP, bdAQntP.connectiondatabase);
                                        MySqlDataReader ActQntP;
                                        ActQntP = comandoActQntP.ExecuteReader();
                                        ActQntP.Read();
                                        #endregion

                                        bd.connectiondatabase.Close();
                                        bdp.connectiondatabase.Close();
                                        bdc.connectiondatabase.Close();
                                        bdpAC.connectiondatabase.Close();
                                        bdpAC2.connectiondatabase.Close();
                                        bdAQntP.connectiondatabase.Close();
                                        return Redirect("/Cliente");
                                        #endregion

                                    }
                                    else
                                    {
                                        // Problema: el producto excede la capacidad disponible
                                        bd.connectiondatabase.Close();
                                        bdp.connectiondatabase.Close();
                                        bdc.connectiondatabase.Close();
                                        bdpAC.connectiondatabase.Close();
                                        bdpAC2.connectiondatabase.Close();
                                        bdAQntP.connectiondatabase.Close();
                                        return Redirect("/Cliente");
                                    }
                                    #endregion
                                }
                                else
                                {
                                    // Problema: No existe el producto para añadir el valor a pagar, error de ID
                                    return Redirect("/Cliente");
                                }
                                #endregion
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
