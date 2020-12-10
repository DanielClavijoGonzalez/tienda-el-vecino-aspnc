using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using proyectv.Models;

namespace proyectv.Controllers
{
    public class RegistrarUsuario : Controller
    {
        Basedatos bd = new Basedatos();
        public IActionResult Index()
        {
            return View();
        }
        public RedirectResult Registrar(string Nombres,string Email,string Edad,string Telefono,string Tipod,string Numerod,string Tipou,string password)
        {
            string query = "INSERT INTO usuario(`id`,`nombres`,`email`,`edad`,`telefono`,`tipo_doc`,`numerodo`,`tipous`,`password`) VALUES (NULL,'" + Nombres + "','"+ Email +"','"+ Edad +"','"+ Telefono +"','"+ Tipod +"','"+ Numerod +"','"+ Tipou+"','"+ password +"')";
            MySqlCommand comando = new MySqlCommand(query, bd.connectiondatabase);

            try
            {
                bd.connectiondatabase.Open();
                MySqlDataReader reader = comando.ExecuteReader();
                bd.connectiondatabase.Close();
                TempData["estado_registro"] = "Te has registrado correctamente!";
                return Redirect("/IniciarSesion");
            }
            catch (Exception)
            {
                return Redirect("/RegistrarUsuario");
            }
        }
    }
}
