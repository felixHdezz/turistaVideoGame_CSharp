using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using RamGecXNAControls;
using System.Data.SQLite;

namespace Turista
{
    class ConfigJuego : Var 
    {
        ConexionSqlite con;
        GUIManager guimanager;
        Texture2D td_FondoMensaje, td_FondoJuego;
        Rectangle rec_mensaje;
        SoundEffect sound_clik, sound_PasMouse;
        Window VentanaWindows;
        Game ga;
        public Botones BtnRegresar, BtnJugar;
        public Label lblAviso;
        string[] ContenidoCajaTexto;
        string[] ArrayIdItem;
        string ItemTema = "", ItemNumeroEquipo = "";
        public string idTema_Seleccionado = "", temaSeleccionado = "";
        public string[] ArrayEquipos;
        public string[,] ArrayPreguntas_Respuestas;
        public bool CargarJuego = false;

        int indiceFoco = 0, numControles = 0;
        int CantidadEquipo;
        public ConfigJuego(Game game, SoundEffect sound, SoundEffect sound_click)
        {
            sound_PasMouse = sound;
            sound_clik = sound_click;
            td_FondoMensaje = game.Content.Load<Texture2D>("Img/opaco");
            rec_mensaje = new Rectangle(0, 0, 450, 200);
            td_FondoJuego = game.Content.Load<Texture2D>("Img/img_pausa");
            guimanager = new GUIManager(game, "Themes", "Default");
            VentanaWindows = new Window(new Rectangle(10, 40, 700, 700), "Turista");
            VentanaWindows.Transparency = 0;
            VentanaWindows.Movable = false;
            guimanager.Controls.Add(VentanaWindows);
            ga = game;
            con = new ConexionSqlite();
            string[] Array_Temas = con.retornaArrayDatos("select * from tbl_temas", "str_Tema");
            ArrayIdItem = con.retornaArrayDatos("select * from tbl_temas", "int_Id_Tema");


            ListBox listaDeTemas = new ListBox(new Rectangle(230, 80, 500, 120), "lstTemas");

            for (int x = 0; x < Array_Temas.Length; x++)
            {
                listaDeTemas.Items.Add(Array_Temas[x]);
            }
            listaDeTemas.ItemColor = Color.Black;
            listaDeTemas.OnSelectItem += (s, i) =>
            {
                ItemTema = listaDeTemas.Items[i];
                idTema_Seleccionado = ArrayIdItem[i];
                temaSeleccionado = Array_Temas[i];
            };
            ListBox listaNumEquipos = new ListBox(new Rectangle(230, 90, 100, 100));
            listaNumEquipos.Items.Add("2");
            listaNumEquipos.Items.Add("3");
            listaNumEquipos.Items.Add("4");
            listaNumEquipos.Items.Add("5");
            listaNumEquipos.ItemColor = Color.Black;

            //groupbox 4
            GroupBox groupBox4 = new GroupBox(new Rectangle(230, 350, 500, 300), "");
            Label lblTituloNombres = new Label(new Rectangle(230, 60, 0, 0), "Nombres de equipo");
            lblTituloNombres.TextColor = Color.White;
            groupBox4.Controls.Add(lblTituloNombres);
            groupBox4.Transparency = 0;
            VentanaWindows.Controls.Add(groupBox4);
            Label config = new Label(new Rectangle(610, 80, 200, 100), "Configurando Juego...");
            config.TextColor = Color.White;
            VentanaWindows.Controls.Add(config);
            listaNumEquipos.OnSelectItem += (s, i) =>
            {
                groupBox4.Controls.Clear();
                ItemNumeroEquipo = listaNumEquipos.Items[i];
                CantidadEquipo = Convert.ToInt32(ItemNumeroEquipo);
                numControles = CantidadEquipo;
                ContenidoCajaTexto = new string[CantidadEquipo];
                ArrayEquipos = new string[CantidadEquipo];
                int y = 70;
                for (int x = 0; x < CantidadEquipo; x++)
                {
                    int NumEquipo = x + 1;
                    Label labelNombreEquipo = new Label(new Rectangle(230, y, 0, 0), "Equipo " + NumEquipo + ":");
                    labelNombreEquipo.TextColor = Color.White;
                    TextBox textNombreEquipo = new TextBox(new Rectangle(330, y, 200, 24), "", "txt" + x);
                    textNombreEquipo.OnTextChanged += (hola) =>
                    {
                        int numDeCaja = Convert.ToInt32(textNombreEquipo.Name.Substring(3, 1)); //Tomo el num del nombre txt1-->1 y convierto a int
                        if (textNombreEquipo.Text.Length > 10)//Validacion menos de 15 caracteres
                        {
                            textNombreEquipo.Text = textNombreEquipo.Text.Substring(0, 10);
                        }
                        ContenidoCajaTexto[numDeCaja] = textNombreEquipo.Text;//guardo texto de la caja en su indice del arreglo (el arreglo me sirve para validar el contenido de las cajas)
                        ArrayEquipos[numDeCaja] = textNombreEquipo.Text;
                    };
                    textNombreEquipo.OnClick += (hola) =>
                    {
                        indiceFoco = Convert.ToInt32(textNombreEquipo.Name.Substring(3, 1));
                    };
                    groupBox4.Controls.Add(labelNombreEquipo);
                    groupBox4.Controls.Add(textNombreEquipo);
                    y += 30;
                }
            };
            GroupBox groupBox2 = new GroupBox(new Rectangle(230, 80, 340, 150), "Núm. de equipos");
            groupBox2.Transparency = 0;
            Label lblTituloNumEquipos = new Label(new Rectangle(230, 60, 0, 0), "Seleccione un Tema");
            lblTituloNumEquipos.TextColor = Color.White;
            groupBox2.Controls.Add(lblTituloNumEquipos);
            //groupbox 3
            GroupBox groupBox3 = new GroupBox(new Rectangle(230, 215, 340, 180), "");
            groupBox3.Transparency = 0;
            VentanaWindows.Controls.Add(groupBox2);
            VentanaWindows.Controls.Add(groupBox3);
            groupBox2.Controls.Add(listaDeTemas);
            Label lblTituloTemas = new Label(new Rectangle(230, 70, 0, 0), "Núm. de equipos");
            lblTituloTemas.TextColor = Color.White;
            groupBox3.Controls.Add(lblTituloTemas);
            groupBox3.Controls.Add(listaNumEquipos);

            lblAviso = new Label(new Rectangle(480, 630, 100, 30), "verifique que todos los equipos tengan signado un nombre", "lbl_aviso");
            lblAviso.TextColor = Color.Red;
            lblAviso.Visible = false;
            VentanaWindows.Controls.Add(lblAviso);

            BtnJugar = new Botones(game.Content.Load<Texture2D>("Img/btn_jugar"), sound_PasMouse, sound_clik, game.GraphicsDevice);
            BtnJugar.setPosicion(new Vector2(490, 630));
            BtnJugar.setPosicionRectanguloIsOver(new Vector2(490, 626));

            BtnRegresar = new Botones(game.Content.Load<Texture2D>("Img/btn_volver"), sound_PasMouse, sound_clik, game.GraphicsDevice);
            BtnRegresar.setPosicion(new Vector2(800, 630));
            BtnRegresar.setPosicionRectanguloIsOver(new Vector2(800, 626));
        }
        public void validarTema()
        {
            con = new ConexionSqlite();
            string consulta = "select  * from tbl_preguntas where int_Id_Tema =" + idTema_Seleccionado;
            SQLiteCommand coman = new SQLiteCommand(consulta, con.conexion);
            SQLiteCommand co = new SQLiteCommand(consulta, con.conexion);
            SQLiteDataReader lee = coman.ExecuteReader();
            SQLiteDataReader lee2 = co.ExecuteReader();
            int fil = 0;
            while (lee.Read())
            {
                fil++;
            }
            int fila = 0;
            ArrayPreguntas_Respuestas = new string[fil, 7];
            while (lee2.Read())
            {
                ArrayPreguntas_Respuestas[fila, 0] = Convert.ToString(lee2[0]);
                ArrayPreguntas_Respuestas[fila, 1] = Convert.ToString(lee2[1]);
                ArrayPreguntas_Respuestas[fila, 2] = Convert.ToString(lee2[2]);
                ArrayPreguntas_Respuestas[fila, 3] = Convert.ToString(lee2[3]);
                ArrayPreguntas_Respuestas[fila, 4] = Convert.ToString(lee2[4]);
                ArrayPreguntas_Respuestas[fila, 5] = Convert.ToString(lee2[5]);
                ArrayPreguntas_Respuestas[fila, 6] = Convert.ToString(lee2[6]);
                fila++;
            }
            if (fil <= 0)
            {
                (VentanaWindows.GetControl("lbl_aviso") as Label).Text = "El Tema seleccionado no tiene preguntas";
                (VentanaWindows.GetControl("lbl_aviso") as Label).Visible = true;
            }
            else
            {
                CargarJuego = true;
                (VentanaWindows.GetControl("lbl_aviso") as Label).Visible = false;
            }
        }
        public void Update(GameTime gt, MouseState MouseAct, MouseState MouseAnt, bool ventanaAct)
        {
            guimanager.Update(gt);
            BtnJugar.Update(MouseAct, MouseAnt, ventanaAct);
            BtnRegresar.Update(MouseAct, MouseAnt, ventanaAct);
            if (BtnJugar.isClicked == true)
            {
                EstadosVendidos = new string[35, 3];
                if (temaSeleccionado != "" && ItemNumeroEquipo != "")
                {
                    bool CajasVacias = false;
                    for (int x = 0; x < ContenidoCajaTexto.Length; x++)
                    {
                        if (string.IsNullOrWhiteSpace(ContenidoCajaTexto[x]))
                        {
                            CajasVacias = true;
                        }
                    }
                    if (CajasVacias)
                    {
                        (VentanaWindows.GetControl("lbl_aviso") as Label).Text = "Verifique que todos los equipos tengan asignado un nombre";
                        (VentanaWindows.GetControl("lbl_aviso") as Label).Visible = true;
                    }
                    else
                    {

                        validarTema();
                    }
                }
                else
                {
                    (VentanaWindows.GetControl("lbl_aviso") as Label).Text = "                    Selecciona un tema y el numero de equipos";
                    (VentanaWindows.GetControl("lbl_aviso") as Label).Visible = true;
                }
                
            }
        }
        public void Draw(SpriteBatch batch)
        {
            //batch.Draw(td_FondoJuego, new Rectangle(0, 0, ga.Window.ClientBounds.Width, ga.Window.ClientBounds.Height), Color.White);
            batch.Draw(td_FondoMensaje, new Vector2(400, 100), new Rectangle(0, 0, 630, 600), Color.White);
            batch.Draw(td_FondoMensaje, new Vector2(400, 100), new Rectangle(0, 0, 630, 600), Color.White);
            guimanager.Draw(batch);
            BtnRegresar.Draw(batch);
            BtnJugar.Draw(batch);
        }
    }
}
