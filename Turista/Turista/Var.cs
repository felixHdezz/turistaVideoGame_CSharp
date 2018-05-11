using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Turista
{
    class Var
    {
        // Variables globales que se utliza en todo el juego
        
        // Array para el tablero de lso estados de la republica 
        public static int[,] tablero;
        
        // Array para la posiciones iniciales de las imagenes
        public static int[,] posImagen;
        public static int[,] PosEsquina;
        public static int[,] PosEsquina1;
        public static int[,] PosEsquina2;
        public static int[,] PosEsquina3;
        
        // Estados vendidos
        public static string[,] EstadosVendidos = new string[35, 4];
        public static string[] ColacadosHoteles = new string[35];
        public static int[,] Posiciones;
    }
}
