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
    public class BorrarPCarrito : Controller
    {
        Basedatos bd = new Basedatos();
        Basedatos bdc = new Basedatos();
        Basedatos bdp = new Basedatos();
        Basedatos bdp2 = new Basedatos();
        Basedatos bdBP = new Basedatos();
        Basedatos bdLP = new Basedatos();
        Basedatos bdAP = new Basedatos();
        public IActionResult Index(int id = -1)
        {
            if (id == -1) return Redirect("/Cliente");

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
                            #region LecturaCarrito
                            /*bd.connectiondatabase.Open();*/
                            string queryFindProducto = "SELECT * FROM carrito where id='" + id + "'";
                            bdc.connectiondatabase.Open();
                            MySqlCommand comandoCarrito = new MySqlCommand(queryFindProducto, bdc.connectiondatabase);
                            MySqlDataReader leerCarrito;
                            leerCarrito = comandoCarrito.ExecuteReader();
                            leerCarrito.Read();
                            #endregion

                            #region VerificarResultadosCarritoDB
                            if (leerCarrito.HasRows)
                            {
                                #region LecturaProductos
                                bdLP.connectiondatabase.Open();
                                string queryLeerP = "SELECT * FROM productos where id='" + leerCarrito.GetInt32(1) + "'";
                                MySqlCommand comandoLeerP = new MySqlCommand(queryLeerP, bdLP.connectiondatabase);
                                MySqlDataReader leerProductos;
                                leerProductos = comandoLeerP.ExecuteReader();
                                leerProductos.Read();
                                #endregion

                                #region BorrarPDeCarrito
                                bdBP.connectiondatabase.Open();
                                string queryDelProducto = "DELETE FROM carrito where id='" + id + "'";
                                MySqlCommand comandoBorrarProducto = new MySqlCommand(queryDelProducto, bdBP.connectiondatabase);
                                MySqlDataReader leerBorrarProducto;
                                leerBorrarProducto = comandoBorrarProducto.ExecuteReader();
                                leerBorrarProducto.Read();
                                #endregion

                                #region CambiarCantidadProducto
                                string resultado = (leerProductos.GetInt32(5) + leerCarrito.GetInt32(2)).ToString();

                                #region ActualizarCantidadProductos
                                bdAP.connectiondatabase.Open();

                                string queryActQntP = "UPDATE `productos` SET `cantidad_producto` = '" + resultado + "' WHERE (`id` = '" + leerProductos.GetInt32(0) + "')";
                                MySqlCommand comandoActQntP = new MySqlCommand(queryActQntP, bdAP.connectiondatabase);
                                MySqlDataReader ActQntP;
                                ActQntP = comandoActQntP.ExecuteReader();
                                ActQntP.Read();
                                #endregion

                                #endregion

                                #region VerificarBorracion
                                if (leerBorrarProducto.RecordsAffected > 0 && ActQntP.RecordsAffected > 0)
                                {
                                    bdc.connectiondatabase.Close();
                                    bd.connectiondatabase.Close();
                                    bdLP.connectiondatabase.Close();
                                    bdBP.connectiondatabase.Close();
                                    bdAP.connectiondatabase.Close();
                                    return Redirect("/CarritoActual");
                                }
                                else
                                {
                                    bdc.connectiondatabase.Close();
                                    bd.connectiondatabase.Close();
                                    bdBP.connectiondatabase.Close();
                                    bdLP.connectiondatabase.Close();
                                    bdAP.connectiondatabase.Close();
                                    // Problema: No se han realizado los cambios: borrar producto de carrito y
                                    // Problema+= actualizar cantidad de producto actual.
                                    return Redirect("/Cliente");
                                }
                                #endregion

                            }
                            #endregion
                            else
                            {
                                // Problema: No hay Resultados Del carrito, error Id
                                return Redirect("/CarritoActual");
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
