using LaboratorioFinalDB.Data.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace FinalExame.Data
{
    internal class MySqlConsola
    {
        string connectionString = "server=localhost; database=pers_juego; user=root; password=destruc10";

        public bool ProbarConexion()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch(Exception  ex)
                {
                    return false;
                }
            }
        }



        //CREATE: Insertar un registro con una clase model
        public bool CrearPersonaje(Personaje cons)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString)) {
                try
                {
                    string consulta = "INSERT INTO juegos (nombre, juego, creacion, consola, poder) VALUES (@nombre, @juego, @creacion, @consola, @poder)";
                    using (MySqlCommand cmd = new MySqlCommand(consulta, connection))
                    {
                        cmd.Parameters.AddWithValue("@nombre", cons.nombre);
                        cmd.Parameters.AddWithValue("@juego", cons.juego);
                        cmd.Parameters.AddWithValue("@creacion", cons.creacion);
                        cmd.Parameters.AddWithValue("@consola", cons.consola);
                        cmd.Parameters.AddWithValue("@poder", cons.poder);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }

                    return true; 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar el Personaje: " + ex.Message);
                    return false;
                }
                finally
                {
                    connection.Close();
                }
            }
        }



        //READ: Seleccionar todos los registros usando List
        public List<Personaje> ObtenerPersonaje()
        {
            List<Personaje> Personajes = new List<Personaje>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string consulta = "SELECT * FROM juegos";
                MySqlCommand cmd = new MySqlCommand(consulta, connection);

                try
                {
                    connection.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Personaje consola = new Personaje
                        (
                             reader.GetInt32("id"),
                             reader.GetString("nombre"),
                             reader.GetString("juego"),
                             reader.GetInt32("creacion"),
                             reader.GetString("consola"),
                             reader.GetInt32("poder")
                        );

                        Personajes.Add(consola);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al leer los Personajes: " + ex.Message);
                }
            }

            return Personajes;
        }


        //Buscar un registro por ID
        public DataRow BuscarRegistroporID(int id)
        {
            DataTable data = new DataTable();
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    string consulta = "SELECT * FROM juegos WHERE id = @ID";
                    MySqlCommand cmd = new MySqlCommand(consulta, connection);
                    cmd.Parameters.AddWithValue("@ID", id);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    connection.Open();
                    adapter.Fill(data);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al leer el personaje: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }

            return data.Rows[0];
        }
        // Actualizar un registro
        public bool Actualizar(Personaje cons)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    string consulta = "UPDATE juegos SET nombre = @nombre, juego = @juego, creacion = @creacion, consola = @consola, poder = @poder WHERE id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(consulta, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", cons.id);
                        cmd.Parameters.AddWithValue("@nombre", cons.nombre);
                        cmd.Parameters.AddWithValue("@juego", cons.juego);
                        cmd.Parameters.AddWithValue("@creacion", cons.creacion);
                        cmd.Parameters.AddWithValue("@consola", cons.consola);
                        cmd.Parameters.AddWithValue("@poder", cons.poder);
                        

                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar el registro: " + ex.Message);
                    return false;
                }
                finally
                {
                    connection.Close();
                }
            }
        }



        //DELETE: Eliminar un registro
        public bool Eliminar(int id)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    string consulta = "DELETE FROM juegos WHERE id = @id";
                    using (MySqlCommand cmd = new MySqlCommand(consulta, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el registro: " + ex.Message);
                    return false;
                }
                finally
                {
                    connection.Close();
                }






            }
        }

       

        
    }
}
