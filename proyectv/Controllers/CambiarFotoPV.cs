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
using System.IO;

namespace proyectv.Controllers
{
    public class CambiarFotoPV : Controller
    {
        Basedatos bd = new Basedatos();
        Basedatos bdU = new Basedatos();
        Basedatos bdRI = new Basedatos();
        private string _dir;
        private IWebHostEnvironment _env;
        string rutaDImagen;
        public CambiarFotoPV(IWebHostEnvironment env)
        {
            _env = env;
            _dir = _env.ContentRootPath;
        }
        public IActionResult Index(IFormFile imagenDP = null)
        {
            #region Content
            if (imagenDP == null) return Redirect("/Vendedor");

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
                        #region Leer Información Del Usuario
                        bdU.connectiondatabase.Open();
                        string queryU = "SELECT * FROM usuario WHERE id='" + idSession + "'";
                        MySqlCommand comandoU = new MySqlCommand(queryU, bdU.connectiondatabase);
                        MySqlDataReader leerU;
                        leerU = comandoU.ExecuteReader();
                        leerU.Read();
                        #endregion

                        #region Actualizar Foto De Perfil

                        #region Cifrado Para Nombre De Archivo
                        int longitud = 10;
                        Guid miGuid = Guid.NewGuid();
                        string token = Convert.ToBase64String(miGuid.ToByteArray());
                        token = token.Replace("=", "").Replace("+", "");
                        string cifrado = (token.Substring(0, longitud)).Replace("/", "");
                        #endregion

                        #region Guardado De Imagen Sistema De Archivos
                        try
                        {
                            string ubicacionYNombre = Path.Combine(_dir + "\\wwwroot\\img\\profilesimg\\", $"{cifrado}.jpg");
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

                        #region Registrar Imagen En DB
                        bdRI.connectiondatabase.Open();
                        string queryRI = "UPDATE `usuario` SET `imagen_usuario` = '"+ rutaDImagen +"' WHERE (`id` = '"+ idSession +"')";
                        MySqlCommand comandoRI = new MySqlCommand(queryRI, bdRI.connectiondatabase);
                        MySqlDataReader leerRI;
                        leerRI = comandoRI.ExecuteReader();
                        leerRI.Read();
                        #endregion

                        #region Verificación De Registro De Imagen
                        if (leerRI.RecordsAffected == 0)
                        {
                            return Redirect("/Vendedor");
                        }
                        #endregion

                        #region Borrar Imagen Antigua
                        if (leerU.GetString(8) != "targetblank.png")
                        {
                            if (System.IO.File.Exists(_dir + "\\wwwroot\\img\\profilesimg\\" + leerU.GetString(8)))
                                System.IO.File.Delete(_dir + "\\wwwroot\\img\\profilesimg\\" + leerU.GetString(8));
                        }
                        #endregion

                        #endregion

                        bdU.connectiondatabase.Close();
                        bd.connectiondatabase.Close();
                        bdRI.connectiondatabase.Close();
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
