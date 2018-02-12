using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SQLite;

namespace Turista
{
    class ConexionSqlite
    {
        public SQLiteConnection conexion;
        public ConexionSqlite()
        {
            //string direccionBase = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) + "\\Juegos\\Bases\\Prueba.db";
            conexion = new SQLiteConnection("Data Source=BaseDeDatos.db;Version=3;New=False;Compress=True;");
            conexion.Open();
        }
        public DataTable RetornaTabla(string consulta)
        {
            if (conexion.State != ConnectionState.Open)
                conexion.Open();
            SQLiteCommand comando = conexion.CreateCommand();
            comando.CommandText = consulta;
            DataTable datostabla = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(comando);
            adapter.Fill(datostabla);
            conexion.Close();
            return datostabla;
        }
        public string[] retornaArrayDatos(string consulta, string campo)
        {
            DataTable dt = RetornaTabla(consulta);
            int n = dt.Rows.Count;
            string[] arr_datos = new string[n];
            DataRow renglon;
            for (int i = 0; i < n; i++) {
                renglon = dt.Rows[i];
                arr_datos[i] = renglon[campo].ToString();
            }
            return arr_datos;
        }
    }
}
