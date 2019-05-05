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
    public partial class VentanaPrincipal : Form
    {
        public VentanaPrincipal()
        {
            InitializeComponent();
            rellenaComboPelis();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            
            Application.Exit();

        }

        //Método que rellena el comboBox de los títulos de las pelis
        // Basado en un trabajo de Jose Ignacio Navas Sanz  (J)
        private void rellenaComboPelis()
        {
            MySqlConnection conexion = new ConexionBBDD().conecta();
            MySqlCommand comando = new MySqlCommand("SELECT * FROM movies ORDER BY name ;", conexion);
            MySqlDataReader resultado = comando.ExecuteReader();

            //Mientras vaya leyendo resultados, va metiéndolos al comboBox
            //Además, separa los valores por medio de guiones
            while (resultado.Read())
            {
                String id = resultado.GetString(0);
                String name = resultado.GetString("name");
                String year = resultado.GetString(2);
                String rank = "";
                if (!resultado.IsDBNull(3)) { rank = resultado.GetString(3); }
                desplegableTitulos.Items.Add(id + "-" + name + "-" + year + "-" + rank);
            }
            conexion.Close();
        }

    }
}
