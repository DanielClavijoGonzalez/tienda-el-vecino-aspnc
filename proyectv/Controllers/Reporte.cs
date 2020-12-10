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
    public class Reporte : Controller
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

            List<ProductosAdquiridos> productslist = new List<ProductosAdquiridos>();
            productslist = (from DataRow dr in dt.Rows
                            select new ProductosAdquiridos()
                            {
                                id = Convert.ToInt32(dr["id"]),
                                anio = (dr["anio"]).ToString(),
                                mes = (dr["mes"]).ToString(),
                                dia = (dr["dia"]).ToString(),
                                codigo_producto_adquirido = Convert.ToInt32(dr["codigo_producto_adquirido"]),
                                id_vendedor_producto = Convert.ToInt32(dr["id_vendedor_producto"]),
                                id_comprador_producto = Convert.ToInt32(dr["id_comprador_producto"]),
                                nombre_producto_adquirido = dr["nombre_producto_adquirido"].ToString(),
                                imagen_producto_adquirido = dr["imagen_producto_adquirido"].ToString(),
                                descripcion_producto_adquirido = (dr["descripcion_producto_adquirido"]).ToString(),
                                precio_producto_adquirido = Convert.ToDouble(dr["precio_producto_adquirido"]),
                                cantidad_producto_adquirido = (dr["cantidad_producto_adquirido"]).ToString(),
                                valor_total_pagado = Convert.ToDouble(dr["valor_total_pagado"]),
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

                        ViewData["capital_total"] = capital_total;
                        ViewData["nombre"] = leer.GetString(1);
                        ViewData["imagen_perfil"] = leer.GetString(8);
                        ViewData["estado_reporte"] = "";
                        if (productslist.Count <= 0) ViewData["estado_reporte"] = "Nadie ha adquirido productos tuyos, espera un comprador :)";

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
            string idSession2 = HttpContext.Session.GetString("idSession");
            string query = "SELECT id, YEAR(fecha_de_compra) as anio, MONTH(fecha_de_compra) as mes, DATE_FORMAT(fecha_de_compra, '%d') as dia, codigo_producto_adquirido, id_vendedor_producto, id_comprador_producto, nombre_producto_adquirido, imagen_producto_adquirido, descripcion_producto_adquirido, precio_producto_adquirido, cantidad_producto_adquirido, valor_total_pagado FROM productos_adquiridos WHERE id_vendedor_producto ='" + idSession2 + "'";
            bd.connectiondatabase.Open();
            MySqlCommand comando = new MySqlCommand(query, bd.connectiondatabase);
            MySqlDataAdapter da = new MySqlDataAdapter(comando);
            da.Fill(dt);
        }
    }
}