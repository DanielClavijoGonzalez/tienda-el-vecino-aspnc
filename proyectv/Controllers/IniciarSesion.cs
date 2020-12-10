using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using proyectv.Models;
using MySql.Data.MySqlClient;
using Microsoft.AspNetCore.Http;

namespace proyectv.Controllers
{
    public class IniciarSesion : Controller
    {
        Basedatos bd = new Basedatos();
        public IActionResult Index()
        {
            string idSession = HttpContext.Session.GetString("idSession");
            if (idSession != null)
            {
                string query = "SELECT * FROM usuario WHERE id='" + idSession + "'";
                bd.connectiondatabase.Open();
                MySqlCommand comando = new MySqlCommand(query, bd.connectiondatabase);
                MySqlDataReader leer;
                leer = comando.ExecuteReader();
                if (leer.Read())
                {
                    if (leer.GetString(7) == "1")
                    {
                        return Redirect("/Vendedor");
                    }
                    else
                    {
                        if (leer.GetString(7) == "2")
                        {
                            return Redirect("/Cliente");
                        }
                        else
                        {
                            // problema: No se ha encontrado el valor de la session en la DB.
                            HttpContext.Session.Clear();
                            ViewBag.error = "Error: No se ha encontrado el rol: " + idSession;
                            return View();
                        }
                    }
                }
                else
                {
                    // problema: No se ha encontrado el valor de la session en la DB.
                    HttpContext.Session.Clear();
                    ViewBag.error = "Error: No se ha encontrado el rol: " + idSession;
                    return View();
                }

            }
            else
            {
                ViewData["estado_registro"] = "";
                // No hay session
                #region Revisar Existencia De Registro
                try
                {
                    if (TempData["estado_registro"].ToString() == "Te has registrado correctamente!") ViewData["estado_registro"] = "Te has registrado correctamente!";
                }
                catch (Exception)
                {

                    return View();
                }
                #endregion

                return View();
            }
        }

        public RedirectResult Select(string email, string password)
        {
            string query = "SELECT id, tipous FROM usuario WHERE email='" + email + "' and password='" + password + "'";
            bd.connectiondatabase.Open();
            MySqlCommand comando = new MySqlCommand(query, bd.connectiondatabase);
            MySqlDataReader leer;
            leer = comando.ExecuteReader();

            if (leer.Read())
            {
                string idSession = HttpContext.Session.GetString("idSession");
                if (idSession == null)
                {
                                      
                    if (leer.GetString(1) == "1") //vend = 1, client = 2
                    {
                        HttpContext.Session.SetString("idSession", leer.GetString(0));
                        /*ViewBag.messaged = "Logueado correctamente con id: " + leer.GetString(0) + "y rol: " + leer.GetString(1);*/
                        bd.connectiondatabase.Close();
                        return Redirect("/Vendedor");
                    }
                    else
                    {
                        if (leer.GetString(1) == "2")
                        {
                            HttpContext.Session.SetString("idSession", leer.GetString(0));
                            ViewBag.messaged = "Logueado correctamente con id: " + leer.GetString(0) + "y rol: " + leer.GetString(1);
                            bd.connectiondatabase.Close();
                            return Redirect("/Cliente");
                        }
                        else
                        {
                            // problema: Se intentó enviar un rol diferente a 1 o 2. (vendedor o cliente)
                            HttpContext.Session.Clear();
                            ViewBag.error = "Error: No existe el rol: " + leer.GetString(1) + " generado por el Id: " + idSession;
                            bd.connectiondatabase.Close();
                            return Redirect("/IniciarSesion");
                        }

                    }

                }
                else
                {
                    if (idSession == leer.GetString(0))
                    {
                        HttpContext.Session.Clear();

                        if (leer.GetString(1) == "1") //vend = 1, client = 2
                        {
                            HttpContext.Session.SetString("idSession", leer.GetString(0));
                            /*ViewBag.messaged = "Logueado nuevamente con el mismo id: " + leer.GetString(0) + "y rol: " + leer.GetString(1);*/
                            bd.connectiondatabase.Close();
                            return Redirect("/Vendedor");
                        }
                        else 
                        {
                            if (leer.GetString(1) == "2")
                            {
                                HttpContext.Session.SetString("idSession", leer.GetString(0));
                                /*ViewBag.messaged = "Logueado nuevamente con el mismo id: " + leer.GetString(0) + "y rol: " + leer.GetString(1);*/
                                bd.connectiondatabase.Close();
                                return Redirect("/Cliente");
                            }
                            else
                            {
                                // problema: Se intentó enviar un rol diferente a 1 ó 2. (vendedor ó cliente)
                                HttpContext.Session.Clear();
                                // Borrar cookie?**
                                ViewBag.error = "Error: No existe el rol: " + leer.GetString(1) + " generado por el Id: " + idSession;
                                bd.connectiondatabase.Close();
                                return Redirect("/IniciarSesion");
                            }
                            
                        }
                    }
                    else
                    {
                        // problema: No se cerró sesión
                        ViewBag.error = "Error= No son login igual nuevo: " + leer.GetString(0)+ " Anterior: " + idSession;
                        HttpContext.Session.Clear();
                        // Borrar cookie?**
                        HttpContext.Session.SetString("idSession", leer.GetString(0));
                        bd.connectiondatabase.Close();
                        return Redirect("/IniciarSesion");
                    }
                }
                
            }
            else
            {
                //ViewBag.error = "Datos ingresados incorrectamente";
                ViewData["error"] = "error detectado!";
                bd.connectiondatabase.Close();
                return Redirect("/IniciarSesion");
            }
        }

    }
}
