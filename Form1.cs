using LaboratorioFinalDB.Data;
using LaboratorioFinalDB.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace FinalExame
{
    public partial class Form1 : Form
    {

        MySqlConsola conexionConsola = new MySqlConsola();
        List<Personaje> Todos_Los_Personajes;
        CursorLista cursor1 = new CursorLista();

        // Lista de Juegos
        private string[] Juegos = {
            "mario bros",
            "Tomb Raider",
            "Pokémon",
            "The Legend of Zelda",
            "Metroid",
            "Sonic the Hedgehog",
            "God of War",
            "Halo",
            "The Witcher",
            "Final Fantasy VII",
            "DOOM",
            "Assassin’s Creed",
            "Metal Gear Solid",
            "Street Fighter",
            "Mortal Kombat",
            "Mega Man",
            "Pac-Man",
            "Half-Life",
            "Red Dead Redemption 2",
            "Overwatch",

        };
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (conexionConsola.ProbarConexion())
            {
                MessageBox.Show("La conexion con la base de datos fue exitosa.");
            }
            else
            {
                MessageBox.Show("Algo fallo al intentar hacer la conexion con la base de datos.");
            }

            comboBoxJuego.Items.AddRange(Juegos);
        }

        private void buttonCrear_Click(object sender, EventArgs e)
        {
            Personaje consCrear = new Personaje();

            consCrear.nombre = textBoxNombre.Text;
            consCrear.juego = comboBoxJuego.Text;
            consCrear.creacion= Int32.Parse(textBoxCreacion.Text);
            consCrear.consola = textBoxConsola.Text;
            consCrear.poder = Int32.Parse(textBoxPoder.Text);

            if (conexionConsola.CrearPersonaje(consCrear))
            {
                MessageBox.Show("El registro fue creado exitosamente.");
                dataGridViewPersonajes.DataSource = conexionConsola.ObtenerPersonaje();
                ActualizarPersonajes();
            }
            else
            {
                MessageBox.Show("El Personaje no fue creado");
            }
        }

        private void ActualizarPersonajes()
        {
            Todos_Los_Personajes = conexionConsola.ObtenerPersonaje();
            dataGridViewPersonajes.DataSource = null;
            dataGridViewPersonajes.DataSource = Todos_Los_Personajes;
        }

        private void buttonCargarRegistros_Click(object sender, EventArgs e)
        {
            Todos_Los_Personajes = conexionConsola.ObtenerPersonaje();
            dataGridViewPersonajes.DataSource = Todos_Los_Personajes;
            if (Todos_Los_Personajes.Count > 0)
            {
                cursor1.totalRegistros = Todos_Los_Personajes.Count;
            }
        }

       


        private void buttonActualizar_Click(object sender, EventArgs e)
        {
            Personaje consActualizar = new Personaje();

            consActualizar.id = Convert.ToInt32(textBoxID.Text);
            consActualizar.nombre = textBoxNombre.Text;
            consActualizar.juego = comboBoxJuego.Text;
            consActualizar.creacion = Int32.Parse(textBoxCreacion.Text);
            consActualizar.consola = textBoxConsola.Text;
            consActualizar.poder = Int32.Parse(textBoxPoder.Text);

            DialogResult resultado = MessageBox.Show("Estas seguro de que deseas actualizar este registro del personaje en la base de datos?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (resultado == DialogResult.Yes)
            {
                if (conexionConsola.Actualizar(consActualizar))
                {
                    MessageBox.Show("El registro de personaje fue actualizado exitoso.");
                    dataGridViewPersonajes.DataSource = conexionConsola.ObtenerPersonaje();
                    ActualizarPersonajes();
                }
                else
                {
                    MessageBox.Show("El registro no fue actualizado dentro de la base de datos.");
                }
            }
            else
            {
                MessageBox.Show("Modificaciones no realizadas.");
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            int id = Int32.Parse(textBoxID.Text);

            DialogResult resultado = MessageBox.Show("Estas seguro de que deseas eliminar permanentemente este registro en la base de datos?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (resultado == DialogResult.Yes)
            {
                if (conexionConsola.Eliminar(id))
                {
                    MessageBox.Show("El registro fue eliminado exitosamente.");
                    dataGridViewPersonajes.DataSource = conexionConsola.ObtenerPersonaje();
                    ActualizarPersonajes();
                }
                else
                {
                    MessageBox.Show("El Personaje no fue eliminado dentro de la base de datos.");
                }
            }
            else
            {
                MessageBox.Show("Modificaciones no realizadas.");
            }
        }

        private void buttonBuscarPorID_Click_1(object sender, EventArgs e)
        {


            int id_buscar = Int32.Parse(textBoxID.Text);
            DataRow registro_encontrado = conexionConsola.BuscarRegistroporID(id_buscar);

            if (registro_encontrado != null)
            {
                textBoxNombre.Text = registro_encontrado["nombre"].ToString();
                comboBoxJuego.Text = registro_encontrado["juego"].ToString();
                textBoxCreacion.Text = registro_encontrado["creacion"].ToString();
                textBoxConsola.Text = registro_encontrado["consola"].ToString();
                textBoxPoder.Text = registro_encontrado["poder"].ToString();
            }
            else
            {
                MessageBox.Show("No se encontro registro con este id.");
            }

            cursor1.actual = id_buscar - 1;
        }

        
    }
}