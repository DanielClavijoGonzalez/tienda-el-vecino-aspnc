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
    public class Vendedor : Controller
    {
        DataTable dt = new DataTable();
        Basedatos bd = new Basedatos();
        Basedatos bdc = new Basedatos();
        Basedatos bdp = new Basedatos();
        Basedatos bdLAC = new Basedatos();
        Double capital_total = 0;
        public IActionResult Index()
        {
            Select();

            #region ListaDeProductos

            List<Productos> productslist = new List<Productos>();
            productslist = (from DataRow dr in dt.Rows
                            select new Productos()
                            {
                                id = Convert.ToInt32(dr["id"]),
                                nombre_producto = dr["nombre_producto"].ToString(),
                                precio_producto = Convert.ToDouble(dr["precio_producto"]),
                                descripcion_producto = dr["descripcion_producto"].ToString(),
                                imagen_producto = dr["imagen_producto"].ToString(),
                                cantidad_producto = dr["cantidad_producto"].ToString(),
                                codigo_producto = Convert.ToInt32(dr["codigo_producto"])
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
                        #region Lectura Productos Completo
                        bdp.connectiondatabase.Open();
                        string queryProductos = "SELECT * FROM productos WHERE codigo_producto='" + idSession + "'";
                        /*bdc.connectiondatabase.Open();*/
                        MySqlCommand comandoProductos = new MySqlCommand(queryProductos, bdp.connectiondatabase);
                        MySqlDataReader leerProductos;
                        leerProductos = comandoProductos.ExecuteReader();
                        leerProductos.Read();
                        #endregion

                        #region Lectura Productos_adquiridos Completo
                        bdLAC.connectiondatabase.Open();
                        string queryLAC = "SELECT * FROM productos_adquiridos WHERE id_vendedor_producto='" + idSession + "'";
                        /*bdc.connectiondatabase.Open();*/
                        MySqlCommand comandoLAC = new MySqlCommand(queryLAC, bdLAC.connectiondatabase);
                        MySqlDataReader leerLAC;
                        leerLAC = comandoLAC.ExecuteReader();
                        leerLAC.Read();
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

                        ViewData["estado_productos"] = "";

                        if (productslist.Count == 0) ViewData["estado_productos"] = "No tienes productos, comienza creando uno :)";

                        ViewData["capital_total"] = capital_total;
                        ViewData["nombre"] = leer.GetString(1);
                        ViewData["imagen_perfil"] = leer.GetString(8);

                        bdLAC.connectiondatabase.Close();
                        bdp.connectiondatabase.Close();
                        return View(productslist);
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

        public void Select()
        {
            string idSession = HttpContext.Session.GetString("idSession");
            string query = "SELECT * FROM productos WHERE codigo_producto ='" + idSession + "'";
            bd.connectiondatabase.Open();
            MySqlCommand comando = new MySqlCommand(query, bd.connectiondatabase);
            MySqlDataAdapter da = new MySqlDataAdapter(comando);
            da.Fill(dt);
        }
    }
}
