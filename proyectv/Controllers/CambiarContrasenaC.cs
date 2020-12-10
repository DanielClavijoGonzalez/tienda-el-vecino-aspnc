using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using proyectv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyectv.Controllers
{
    public class CambiarContrasenaC : Controller
    {
        Basedatos bd = new Basedatos();
        Basedatos bdLAC = new Basedatos();
        Basedatos bdLU = new Basedatos();
        Basedatos bdLC = new Basedatos();
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
                        return Redirect("/Cliente");
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

                            #region Lectura De Datos Del Usuario
                            bdLU.connectiondatabase.Open();
                            string queryLU = "SELECT * FROM usuario WHERE id='" + idSession + "'";
                            MySqlCommand comandoLU = new MySqlCommand(queryLU, bdLU.connectiondatabase);
                            MySqlDataReader leerLU;
                            leerLU = comandoLU.ExecuteReader();
                            leerLU.Read();
                            #endregion

                            ViewData["valor_a_pagar"] = valor_a_pagar;
                            ViewData["nombre"] = leer.GetString(1);
                            ViewData["imagen_perfil"] = leer.GetString(8);
                            ViewData["estado_intento"] = "";

                            #region Revisar Existencia De Fallo De Contraseña
                            try
                            {
                                if (TempData["estado_intento"].ToString() == "false") ViewData["estado_intento"] = "false";
                            }
                            catch (Exception)
                            {
                                bdLAC.connectiondatabase.Close();
                                bdLU.connectiondatabase.Close();
                                bd.connectiondatabase.Close();
                                return View();
                            }
                            #endregion

                            bdLAC.connectiondatabase.Close();
                            bdLU.connectiondatabase.Close();
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
