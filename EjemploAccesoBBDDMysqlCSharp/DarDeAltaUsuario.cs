using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace EjemploAccesoBBDDMysqlCSharp
{
    public partial class DarDeAltaUsuario : Form
    {
        public DarDeAltaUsuario()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conexion = new ConexionBBDD().conecta();
            MySqlCommand comando = new MySqlCommand("INSERT INTO `usuario` (`DNI`, `Nombre`, `Apellido`, `password`, `email`) VALUES ('" + DNI.Text + "', '" + nombre.Text + "', '" + apellido.Text + "', '" + password.Text + "', '" + email.Text + "') ",
                conexion);
            MySqlDataReader resultado = comando.ExecuteReader();
        }
    }
}
