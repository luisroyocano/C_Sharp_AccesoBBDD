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
            rellenaComboNombres();
            rellenaComboPelículasAlquiler();
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
        private void rellenaComboNombres()
        {
            MySqlConnection conexion = new ConexionBBDD().conecta();
            MySqlCommand comando = new MySqlCommand("SELECT usuario.DNI FROM usuario  ;", conexion);
            MySqlDataReader datos = comando.ExecuteReader();

            //Mientras vaya leyendo resultados, va metiéndolos al comboBox
            
            while (datos.Read())
            {
                String DNI = datos.GetString(0);
                comboBox1.Items.Add(DNI);
            }
            conexion.Close();
        }
        private void rellenaComboPelículasAlquiler()
        {
            MySqlConnection conexion = new ConexionBBDD().conecta();
            MySqlCommand comando = new MySqlCommand("SELECT movies.name FROM movies  ;", conexion);
            MySqlDataReader nombres = comando.ExecuteReader();

            //Mientras vaya leyendo resultados, va metiéndolos al comboBox
          
            while (nombres.Read())
            {
                String name = nombres.GetString(0);
                comboBox2.Items.Add(name);
            }
            conexion.Close();
        }





        //En este botón, vamos a coger el texto de comobox1(DNI usuarios) y combovox2(nombre peliculas)
        // y los vamos a insertar en la tabla de alquileres
        private void label2_Click(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conexion = new ConexionBBDD().conecta();
            MySqlCommand comando = new MySqlCommand("INSERT INTO `alquiler` (`DNI_usuario`, `pelicula`) VALUES ('" + comboBox1.Text + "', '" + comboBox2.Text + "') ",
                conexion);
            MySqlDataReader resultado = comando.ExecuteReader();
            if (resultado.Read())
            {
                MessageBox.Show("Pelicula añadida");

            }
            conexion.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection conexion = new ConexionBBDD().conecta();
            MySqlCommand comando = new MySqlCommand("DELETE FROM `alquiler` WHERE `DNI_usuario` = '" + comboBox1.Text + "' and `pelicula` = '" + comboBox2.Text + "' ",
                conexion);
            MySqlDataReader resultado = comando.ExecuteReader();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DarDeAltaUsuario v = new DarDeAltaUsuario();
            v.Visible = true;
        }
    }
}
