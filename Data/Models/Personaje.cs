using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace FinalExame.Data.Models
{
    internal class Personaje
    {
       

        public int id { get; set; }
        public string nombre{ get; set; }
        public string juego{ get; set; }
        public int creacion { get; set; }
        public string consola { get; set; }
        public int poder { get; set; }


        //Constructor sin parametros
        public Personaje() { }


        //Constructor con parametros
        public Personaje(int ID, string Nombre, string Juego, int Creacion, string Consola, int Poder)
        {
            id = ID;
            nombre = Nombre;
            juego = Juego;
            creacion =Creacion;
            consola = Consola;
            poder = Poder;
        }

        internal static void Add(Personaje consola)
        {
            throw new NotImplementedException();
        }
    }
}