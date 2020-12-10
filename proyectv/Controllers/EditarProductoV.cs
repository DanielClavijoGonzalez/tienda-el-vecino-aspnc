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
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace proyectv.Controllers
{
    public class EditarProductoV : Controller
    {
        Basedatos bd = new Basedatos();
        Basedatos bdc = new Basedatos();
        Basedatos bdp = new Basedatos();
        Basedatos bdLAC = new Basedatos();
        Basedatos bdIP = new Basedatos();
        Basedatos bdpAC = new Basedatos();
        private string _dir;
        private IWebHostEnvironment _env;
        string rutaDImagen;
        string queryIP;
        public EditarProductoV(IWebHostEnvironment env)
        {
            _env = env;
            _dir = _env.ContentRootPath;
        }
        public IActionResult Index(IFormFile imagenDP = null, string nombreP = null, int precioP = 0, int unidadesP = 0, string descripcionP = null, int idP = 0)
        {
            #region Content
            if (nombreP == null || precioP <= 0 || unidadesP <= 0 || descripcionP == null || idP <= 0)
            {
                return Redirect("/DatosDeFormularioRecibidosConErrorONoRecibidos");
            }
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
                        #region LecturaProductosAddAC
                        bdpAC.connectiondatabase.Open();
                        string queryLeerAC = "SELECT * FROM productos WHERE id='" + idP + "'";
                        MySqlCommand comandoLeerAC = new MySqlCommand(queryLeerAC, bdpAC.connectiondatabase);
                        MySqlDataReader leerProductosAC;
                        leerProductosAC = comandoLeerAC.ExecuteReader();
                        leerProductosAC.Read();
                        #endregion

                        #region Insertar Producto A la DB

                        if (leerProductosAC.GetInt32(6) == Convert.ToInt32(idSession))
                        {
                            #region Verificar Cambio De Imagen
                            if (imagenDP == null)
                            {
                                queryIP = "UPDATE `productos` SET `nombre_producto` = '" + nombreP + "', `precio_producto` = '" + precioP + "', `descripcion_producto` = '" + descripcionP + "', `imagen_producto` = '" + leerProductosAC.GetString(4) + "', `cantidad_producto` = '" + unidadesP + "' WHERE (`id` = '" + idP + "');";
                            }
                            else
                            {
                                #region Insertar Imagen ALG

                                #region Cifrado Para Nombre De Archivo
                                int longitud = 10;
                                Guid miGuid = Guid.NewGuid();
                                string token = Convert.ToBase64String(miGuid.ToByteArray());
                                token = token.Replace("=", "").Replace("+", "");
                                string cifrado = (token.Substring(0, longitud)).Replace("/", "");

                                #endregion

                                try
                                {
                                    string ubicacionYNombre = Path.Combine(_dir + "\\wwwroot\\img\\productsimg\\", $"{cifrado}.jpg");
                                    using (var fileStream = new FileStream(ubicacionYNombre, FileMode.Create, FileAccess.Write))
                                    {
                                        imagenDP.CopyTo(fileStream);
                                    }
                                    rutaDImagen = cifrado + ".jpg";
                                }
                                catch (Exception e)
                                {
                                    return Redirect("/Vendedor" + e);
                                }
                                #endregion

                                #region Borrar Imagen Antigua
                                if (System.IO.File.Exists(_dir + "\\wwwroot\\img\\productsimg\\" + leerProductosAC.GetString(4)))
                                    System.IO.File.Delete(_dir + "\\wwwroot\\img\\productsimg\\" + leerProductosAC.GetString(4));
                                #endregion

                                queryIP = "UPDATE `productos` SET `nombre_producto` = '" + nombreP + "', `precio_producto` = '" + precioP + "', `descripcion_producto` = '" + descripcionP + "', `imagen_producto` = '" + rutaDImagen + "', `cantidad_producto` = '" + unidadesP + "' WHERE (`id` = '" + idP + "');";
                            }
                            #endregion

                            bdIP.connectiondatabase.Open();
                            MySqlCommand comandoIP = new MySqlCommand(queryIP, bdIP.connectiondatabase);
                            MySqlDataReader leerIP;
                            leerIP = comandoIP.ExecuteReader();
                            leerIP.Read();

                            #region Verificar Inserción De Producto
                            if (leerIP.RecordsAffected == 0)
                            {
                                bdLAC.connectiondatabase.Close();
                                bdIP.connectiondatabase.Close();
                                bdp.connectiondatabase.Close();
                                bdpAC.connectiondatabase.Close();
                                return Redirect("/Vendedor");
                            }
                            #endregion
                        }

                        #endregion

                        bdLAC.connectiondatabase.Close();
                        bdIP.connectiondatabase.Close();
                        bdp.connectiondatabase.Close();
                        bdpAC.connectiondatabase.Close();
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
