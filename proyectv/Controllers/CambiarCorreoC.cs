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
    public class CambiarCorreoC : Controller
    {
        Basedatos bd = new Basedatos();
        Basedatos bdLC = new Basedatos();
        Basedatos bdLIU = new Basedatos();
        Double valor_a_pagar = 0;
        public IActionResult Index()
        {
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
                            #region Lectura De Carrito
                            bdLC.connectiondatabase.Open();
                            string queryLC = "select c.*, p.id as id_producto, p.precio_producto, (c.cantidad_producto * p.precio_producto) as valor_a_pagar from carrito c, productos p, usuario u where c.codigo_producto_carrito=p.id and c.id_comprador=u.id and c.id_comprador= '" + idSession + "'";
                            MySqlCommand comandoLC = new MySqlCommand(queryLC, bdLC.connectiondatabase);
                            MySqlDataReader leerLC;
                            leerLC = comandoLC.ExecuteReader();
                            leerLC.Read();
                            #endregion

                            #region Inspeccion Si Tiene Algo En Carrito
                            if (leerLC.HasRows)
                            {
                                leerLC.Close();
                                leerLC = comandoLC.ExecuteReader();

                                while (leerLC.Read())
                                {
                                    valor_a_pagar += leerLC.GetDouble(6);
                                }
                            }
                            #endregion

                            #region Leer Información Del Usuario
                            bdLIU.connectiondatabase.Open();
                            string queryLIU = "SELECT * FROM usuario WHERE id='" + idSession + "'";
                            MySqlCommand comandoLIU = new MySqlCommand(queryLIU, bdLIU.connectiondatabase);
                            MySqlDataReader leerLIU;
                            leerLIU = comandoLIU.ExecuteReader();
                            leerLIU.Read();
                            #endregion

                            #region Extraer Correo Actual Del Usuario
                            if (leerLIU.HasRows)
                            {
                                ViewData["correo_actual"] = leerLIU.GetString(2);
                            }
                            else
                            {
                                bdLIU.connectiondatabase.Close();
                                bdLC.connectiondatabase.Close();
                                bd.connectiondatabase.Close();
                                return Redirect("/Cliente");
                            }
                            #endregion

                            ViewData["valor_a_pagar"] = valor_a_pagar;
                            ViewData["nombre"] = leer.GetString(1);
                            ViewData["imagen_perfil"] = leer.GetString(8);

                            bdLIU.connectiondatabase.Close();
                            bdLC.connectiondatabase.Close();
                            bd.connectiondatabase.Close();
                            return View();
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
