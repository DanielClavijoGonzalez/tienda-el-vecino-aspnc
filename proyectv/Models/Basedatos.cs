using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace proyectv.Models
{
    public class Basedatos
    {
        public MySqlConnection connectiondatabase { get; set; } = new MySqlConnection("datasource=Localhost;port=3306;username=root;password=;database=ventas;");
    }
}
