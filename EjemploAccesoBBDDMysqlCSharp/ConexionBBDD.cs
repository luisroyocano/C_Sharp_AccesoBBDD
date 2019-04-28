using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace EjemploAccesoBBDDMysqlCSharp
{
    class ConexionBBDD
    {
        
        public MySqlConnection conecta()
        {
            /* Se necesitan cinco parámetros:
             * --------------------------------
             * Server: IP o Nombre del servidor
             * Database: Nombre de la BBDD 
             * UID: User ID (NOT NULL)
             * Password: Contraseña
             * Port: Puerto por defecto 3306 */
            MySqlConnection conexion = new MySqlConnection("Server=127.0.0.1; " +
                "Database=videoclub; " +
                "Uid=root; " +
                "Pwd=; " +
                "Port=3306");
            conexion.Open();

            return conexion;
        }
    }
}
