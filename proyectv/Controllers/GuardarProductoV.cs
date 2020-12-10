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
    public class GuardarProductoV : Controller
    {
        Basedatos bd = new Basedatos();
        Basedatos bdc = new Basedatos();
        Basedatos bdp = new Basedatos();
        Basedatos bdLAC = new Basedatos();
        Basedatos bdIP = new Basedatos();
        private string _dir;
        private IWebHostEnvironment _env;
        string rutaDImagen;

        public GuardarProductoV(IWebHostEnvironment env)
        {
            _env = env;
            _dir = _env.ContentRootPath;
        }
        [ValidateAntiForgeryToken]
        public IActionResult Index(IFormFile imagenDP = null, string nombreP = null, int precioP = 0, int unidadesP = 0, string descripcionP = null)
        {
            #region Content
            if (imagenDP == null || nombreP == null || precioP <= 0 || unidadesP <= 0 || descripcionP == null)
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

                        #region Insertar Producto A la DB
                        bdIP.connectiondatabase.Open();
                        string queryIP = "INSERT INTO productos (`id`,`nombre_producto`, `precio_producto`, `descripcion_producto`, `imagen_producto`, `cantidad_producto`, `codigo_producto`) VALUES (null,'" + nombreP + "','" + precioP + "','" + descripcionP + "','" + rutaDImagen + "','" + unidadesP + "','" + idSession + "')";
                        MySqlCommand comandoIP = new MySqlCommand(queryIP, bdIP.connectiondatabase);
                        MySqlDataReader leerIP;
                        leerIP = comandoIP.ExecuteReader();
                        leerIP.Read();
                        #endregion

                        #region Verificar Inserción De Producto
                        if (leerIP.RecordsAffected == 0)
                        {
                            bdLAC.connectiondatabase.Close();
                            bdIP.connectiondatabase.Close();
                            bdp.connectiondatabase.Close();
                            return Redirect("/Vendedor");
                        }
                        #endregion

                        bdLAC.connectiondatabase.Close();
                        bdIP.connectiondatabase.Close();
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
