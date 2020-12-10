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
    public class GuardarCorreoV : Controller
    {
        Basedatos bd = new Basedatos();
        Basedatos bdc = new Basedatos();
        Basedatos bdp = new Basedatos();
        Basedatos bdCC = new Basedatos();

        [ValidateAntiForgeryToken]
        public IActionResult Index(string correoDU = null)
        {
            #region Content
            if (correoDU == null) return Redirect("/Vendedor");

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
                        #region Actualizar Correo En La DB
                        bdCC.connectiondatabase.Open();
                        string queryCC = "UPDATE `usuario` SET `email` = '"+ correoDU +"' WHERE (`id` = '"+ idSession +"')";
                        MySqlCommand comandoCC = new MySqlCommand(queryCC, bdCC.connectiondatabase);
                        MySqlDataReader leerCC;
                        leerCC = comandoCC.ExecuteReader();
                        leerCC.Read();
                        #endregion

                        #region Verificar Inserción De Producto
                        if (leerCC.RecordsAffected == 0)
                        {
                            
                            bd.connectiondatabase.Close();
                            bdCC.connectiondatabase.Close();
                            bdp.connectiondatabase.Close();
                            return Redirect("/CambiarCorreoV");
                        }
                        #endregion

                        bd.connectiondatabase.Close();
                        bdCC.connectiondatabase.Close();
                        bdp.connectiondatabase.Close();
                        return Redirect("/CambiarCorreoV");
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
