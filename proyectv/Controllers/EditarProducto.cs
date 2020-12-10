using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using proyectv.Models;
using MySql.Data.MySqlClient;
using System.Web.Optimization;
using System.Data;

namespace proyectv.Controllers
{
    public class EditarProducto : Controller
    {
        Basedatos bd = new Basedatos();
        Basedatos bdc = new Basedatos();
        Basedatos bdp = new Basedatos();
        Basedatos bdLAC = new Basedatos();
        Basedatos bdPP = new Basedatos();
        Double capital_total = 0;
        public IActionResult Index(int idp = -1)
        {
            #region Content
            if (idp <= 0) return Redirect("/Vendedor");

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
                        #region Lectura Productos_adquiridos Completo
                        bdLAC.connectiondatabase.Open();
                        string queryLAC = "SELECT * FROM productos_adquiridos WHERE id_vendedor_producto='" + idSession + "'";
                        MySqlCommand comandoLAC = new MySqlCommand(queryLAC, bdLAC.connectiondatabase);
                        MySqlDataReader leerLAC;
                        leerLAC = comandoLAC.ExecuteReader();
                        leerLAC.Read();
                        #endregion

                        #region Lectura Producto Perteneciente
                        bdPP.connectiondatabase.Open();
                        string queryPP = "SELECT * FROM productos WHERE id='" + idp + "' AND codigo_producto ='" + idSession + "'";
                        MySqlCommand comandoPP = new MySqlCommand(queryPP, bdPP.connectiondatabase);
                        MySqlDataReader leerPP;
                        leerPP = comandoPP.ExecuteReader();
                        leerPP.Read();
                        #endregion

                        #region Inspeccion Si Tiene Saldo
                        if (leerLAC.HasRows)
                        {
                            leerLAC.Close();
                            leerLAC = comandoLAC.ExecuteReader();

                            while (leerLAC.Read())
                            {
                                capital_total += leerLAC.GetDouble(10);
                            }
                        }
                        leerLAC.Close();
                        leerLAC = comandoLAC.ExecuteReader();
                        #endregion

                        #region Inspección Del Producto Recibido
                        if (leerPP.HasRows)
                        {
                            ViewData["id_producto"] = leerPP.GetString(0);
                            ViewData["nombre_producto"] = leerPP.GetString(1);
                            ViewData["precio_producto"] = leerPP.GetString(2);
                            ViewData["descripcion_producto"] = leerPP.GetString(3);
                            ViewData["imagen_producto"] = leerPP.GetString(4);
                            ViewData["cantidad_producto"] = leerPP.GetString(5);
                        }
                        else
                        {
                            bdLAC.connectiondatabase.Close();
                            bdPP.connectiondatabase.Close();
                            bdp.connectiondatabase.Close();
                            return Redirect("/NoExisteElProductoSolicitadoDelUsuariox" + idSession);
                        }
                        #endregion

                        ViewData["capital_total"] = capital_total;
                        ViewData["nombre"] = leer.GetString(1);
                        ViewData["imagen_perfil"] = leer.GetString(8);

                        bdLAC.connectiondatabase.Close();
                        bdPP.connectiondatabase.Close();
                        bdp.connectiondatabase.Close();
                        return View();
                    }
                    else
                    {
                        if (leer.GetString(7) == "2")
                        {
                            ViewBag.messaged = "Redireccion aqui por parte de el area de cliente";
                            bd.connectiondatabase.Close();
                            return Redirect("/Cliente");
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
