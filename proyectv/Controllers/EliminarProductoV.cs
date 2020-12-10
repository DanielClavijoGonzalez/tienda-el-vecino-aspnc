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
using Microsoft.AspNetCore.Hosting;

namespace proyectv.Controllers
{
    public class EliminarProductoV : Controller
    {
        DataTable dt = new DataTable();
        Basedatos bd = new Basedatos();
        Basedatos bdc = new Basedatos();
        Basedatos bdp = new Basedatos();
        Basedatos bdLAC = new Basedatos();
        Basedatos bdVP = new Basedatos();
        Basedatos bdBP = new Basedatos();
        private string _dir;
        private IWebHostEnvironment _env;
        public EliminarProductoV(IWebHostEnvironment env)
        {
            _env = env;
            _dir = _env.ContentRootPath;
        }
        public IActionResult Index(int idp)
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
                        #region Lectura Productos Completo
                        bdp.connectiondatabase.Open();
                        string queryProductos = "SELECT * FROM productos WHERE id='" + idp + "'";
                        /*bdc.connectiondatabase.Open();*/
                        MySqlCommand comandoProductos = new MySqlCommand(queryProductos, bdp.connectiondatabase);
                        MySqlDataReader leerProductos;
                        leerProductos = comandoProductos.ExecuteReader();
                        leerProductos.Read();
                        #endregion

                        #region Verificar Existencia Del Producto
                        if (leerProductos.HasRows)
                        {
                            #region Verificación De Propiedad De Producto
                            if (leerProductos.GetInt32(6) == Convert.ToInt32(idSession))
                            {
                                #region Lectura De Producto De Acuerdo A Resultados
                                bdVP.connectiondatabase.Open();
                                string queryVP = "SELECT * FROM productos WHERE codigo_producto='" + leerProductos.GetInt32(6) + "'";
                                MySqlCommand comandoVP = new MySqlCommand(queryVP, bdVP.connectiondatabase);
                                MySqlDataReader leerVP;
                                leerVP = comandoVP.ExecuteReader();
                                leerVP.Read();
                                #endregion

                                if (leerVP.HasRows)
                                {
                                    #region Eliminar Imagen Del Sistema De Archivos
                                    if (System.IO.File.Exists(_dir + "\\wwwroot\\img\\productsimg\\" + leerProductos.GetString(4)))
                                        System.IO.File.Delete(_dir + "\\wwwroot\\img\\productsimg\\" + leerProductos.GetString(4));
                                    #endregion

                                    #region Eliminar Producto De DB
                                    bdBP.connectiondatabase.Open();
                                    string queryBP = "DELETE FROM `productos` WHERE(`id` = '" + idp + "')";
                                    MySqlCommand comandoBP = new MySqlCommand(queryBP, bdBP.connectiondatabase);
                                    MySqlDataReader leerBP;
                                    leerBP = comandoBP.ExecuteReader();
                                    leerBP.Read();
                                    #endregion

                                    #region Verificar Eliminación Del Producto En DB
                                    if (leerBP.RecordsAffected > 0)
                                    {
                                        bdBP.connectiondatabase.Close();
                                        bdLAC.connectiondatabase.Close();
                                        bdVP.connectiondatabase.Close();
                                        bdp.connectiondatabase.Close();
                                        return Redirect("/Vendedor");
                                    }
                                    #endregion
                                }
                                #endregion
                            }


                            
                        }
                        #endregion

                        bdBP.connectiondatabase.Close();
                        bdLAC.connectiondatabase.Close();
                        bdVP.connectiondatabase.Close();
                        bdp.connectiondatabase.Close();
                        return Redirect("/Vendedor");
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
