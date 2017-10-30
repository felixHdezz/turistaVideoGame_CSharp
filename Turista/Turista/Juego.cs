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
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using RamGecXNAControls;

namespace Turista
{
    class DibujaEquipo
    {
        public string nombreequipo = "";
        public string Indice;
        public int Puntaje = 0;
        Vector2 PosicionTexto;
        Texture2D FondoEcuipo, Equipo;
        public double Fondo = 2000;
        SpriteFont fuente;
        public int NumeroVueltas = 0;
        float posicionTexto;
        int pos;
        public bool ActualEquipo = false, EdosComprados =true;
        public DibujaEquipo(string nombre,int IndiceEquipo,int posicion,float posiciontexto,Vector2 posiciTexto,SpriteFont fuent,Texture2D equipo,Texture2D fon)
        {
            nombreequipo = nombre;
            Equipo = equipo;
            pos = posicion;
            Indice = Convert.ToString(IndiceEquipo);
            PosicionTexto = posiciTexto;
            posicionTexto = posiciontexto;
            fuente = fuent;
            FondoEcuipo = fon;
        }
        public void Draw(SpriteBatch batch)
        {
            if (ActualEquipo)
            {
                batch.Draw(Equipo, new Rectangle(pos, 4, 40, 70), Color.White);
                batch.DrawString(fuente, "Equipo :" + nombreequipo, PosicionTexto, Color.White);
                batch.DrawString(fuente, "Fondo  : $" + Fondo, new Vector2(posicionTexto, 30), Color.White);
                batch.DrawString(fuente, "Vueltas : " + NumeroVueltas, new Vector2(posicionTexto, 50), Color.White);
            }
            else
            {
                batch.Draw(Equipo, new Rectangle(pos, 4, 40, 70), Color.White);
                batch.DrawString(fuente, "Equipo :" + nombreequipo, PosicionTexto, Color.White);
                batch.DrawString(fuente, "Fondo  : $" + Fondo, new Vector2(posicionTexto, 30), Color.White);
                batch.DrawString(fuente, "Vueltas : " + NumeroVueltas, new Vector2(posicionTexto, 50), Color.White);
            }
        }
    }
    class DibujaEstados
    {
        public string nombreequipo = "";
        string Indice;
        Texture2D Equipo;
        public double Fondo;
        SpriteFont fuente;
        public int NumeroVueltas = 0;
        int posY, PosX = 900, PosText, actualimagen = 0;
        public bool ActualEquipo = false, Mover = false, Quitar = false, EdosComprados = true, ActualizarFondo = false;
        public DibujaEstados(string nombre, int IndiceEquipo, int posicion,int precio, SpriteFont fuent, Texture2D equipo)
        {
            nombreequipo = nombre;
            Equipo = equipo;
            posY = posicion;
            PosText = posY;
            Fondo = precio;
            Indice = Convert.ToString(IndiceEquipo);
            fuente = fuent;
        }
        public void Update(GameTime time,int actual)
        {
            actualimagen = actual;
            if (Mover == true)
            {
                ActualizarFondo = true;
                if (actualimagen == 0)
                {
                    if (PosX > 240 && posY <= 260)
                    {
                        PosX -= 36;
                        posY += 15;
                    }
                    else
                    {
                        Quitar = true;
                    }
                }
                if (actualimagen == 1)
                {
                    if (PosX > 200 && posY <= 260)
                    {
                        PosX -= 35;
                        posY += 6;
                    }
                    else
                    {
                        Quitar = true;
                    }
                }
                if (actualimagen == 2)
                {
                    if (PosX > 450 && posY > 260)
                    {
                        PosX -= 30;
                        posY += 1;
                    }
                    else
                    {
                        Quitar = true;
                    }
                }
                if (actualimagen == 3)
                {
                    if (PosX > 450 && posY > 260)
                    {
                        PosX -= 30;
                    }
                    else
                    {
                        Quitar = true;
                    }
                }
                if (actualimagen == 4)
                {
                    if (PosX > 450 && posY > 260)
                    {
                        PosX -= 30;
                        posY -= 2;
                    }
                    else
                    {
                        Quitar = true;
                    }
                }
                if (actualimagen == 5)
                {
                    if (PosX >= 450 && posY > 260)
                    {
                        PosX -= 30;
                        posY -= 5;
                    }
                    else
                    {
                        Quitar = true;
                    }
                }
                if (actualimagen == 6)
                {
                    if (PosX >= 450 && posY > 260)
                    {
                        PosX -= 30;
                        posY -= 8;
                    }
                    else
                    {
                        Quitar = true;
                    }
                }
                if (actualimagen == 7)
                {
                    if (PosX >= 450 && posY > 260)
                    {
                        PosX -= 30;
                        posY -= 15;
                    }
                    else
                    {
                        Quitar = true;
                    }
                }
            }
        }
        public void Draw(SpriteBatch batch)
        {
            if (Quitar != true)
            {
                batch.Draw(Equipo, new Rectangle(PosX, posY, 100, 60), Color.White);
                batch.DrawString(fuente, "$" + Convert.ToString(Fondo), new Vector2(1005, PosText + 10), Color.White);
                batch.DrawString(fuente, nombreequipo, new Vector2(1080, PosText + 10), Color.White);
            }
            else { 
                
            }
        }
    }
    class ColocarHotel: Var
    {
        string Indice = "";
        Texture2D Hotel;
        public bool MostrarHotel;
        int PosX = 0, PosY = 0;
        public ColocarHotel(Texture2D hotel)
        {
            Hotel = hotel;
        }
        public void Draw(SpriteBatch batch)
        {
            if (MostrarHotel != false) {
                batch.Draw(Hotel, new Rectangle(PosX + 8, PosY -20, 75, 90), Color.White);
            } else {

            }
        }
        public void ColocaHotelEnEstado(int Val)
        {
            PosX = Posiciones[Val - 1, 0];
            PosY = Posiciones[Val - 1, 1];
        }
    }
    class Juego : Var
    {
        enum EstadoJuego
        {
            Jugando,
            Pausa,
            OpcionesJugando
        }
        EstadoJuego EstadoJuegoActual = new EstadoJuego();

        List<Texture2D> Estados = new List<Texture2D>();
        public List<Texture2D> equipos = new List<Texture2D>();
        List<Texture2D> Hoteles = new List<Texture2D>();
        Texture2D td_FondoPausa;
        Rectangle rec_pausa;
        Texture2D td_barra,vertabla;
        Texture2D td_FondobarraEquipo;
        Texture2D fondo1,avion;
        Texture2D mexico, goo, paga, colmexico, banco, hotel, Img_Aviso, Hotel;
        Vector2 tileDimensions = Vector2.Zero;
        public Botones btnPreguntarEquipo, btn_Contestar, btn_TirarDado, btn_si, btn_no,
                       btn_ReanudarJuego, btn_Opciones, btn_Reiniciar, btn_Salir, btn_cerrar, btn_penlizar;
        Jugador[] cJugador;
        Jugador jug;
        Vector2 tiles = Vector2.Zero;
        public DibujaEquipo[] Equipo;
        int[] precio;
        public string[] NomEstados,Nombreestados;
        public DibujaEstados[] cEstados;
        public ColocarHotel[] cHotel;
        SoundEffect sound_click, sound_pasmouse;
        GUIManager guimanager;
        Game ga;
        OpcionesJugando Opc_jugando;
        SpriteFont fuente, fuete11, fuetepausa,FuenteTiempo,fuenteaviso,fuenteaviso1;
        Window VentanaWindows;
        Model ModeloDado;
        Var variable;
        public Label lbl_Pregunta;
        public RadioButton rb_Respuesta1, rb_Respuesta2, rb_Respuesta3,rb_Respuesta4;
        bool activa = false;
        public bool tirardado = false;
        int NumCaidoDado = 0;
        string[] NombreEquipos;
        public string EstadoJugando = "";
        public int PreColima = 200, PreDurango = 150, PreCoahuila = 100, PreChihuahua = 200, PreEdoMexico = 300, PreGuerrero = 150,
            PreHidalgo = 100, PreGuanajuato = 250, PreMichoacan = 150, PreJalisco = 200, PreMorelos = 100, PreNayarit =150, PreNuevoL = 200, PreOxaca = 100, PrePuebla = 300,
            PreQueretaro = 200, PreQuintanaro = 300, PreSanLuis = 200, PreSinaloa = 250, PreSonora = 300, PreTabasco = 200, PreTamaul = 150, PreTlaxcala = 200, PreVeracruz = 250,
            PreYucatan = 250, PreZacatecas = 150, Prechiapas = 250, PreCampeche = 200, PreCaliforni = 300, PreCaliforSur = 250, PreAguascali = 200, PreDistrito = 150;
        //public  string col = "Colima", duran = "Durango", coah = "Coahuia", chihu = "Chihuahua", EdMex = "Edo. Mexico", guerre = "Guerrero", hidal = "Hidalgo", guana = "Guanajuato",
        //       micho = "Michoacan", jalis = "Jalisco", mor = "Morelos", naya = "Nayarit", nleon = "Nuevo Leon", oxa = "Oxaca", pueb = "Puebla", quere = "Qurretaro", quint = "Quintanaro",
        //       sanl = "San luis", sina = "Sinaloa", sono = "Sonora", tab = "Tabasco", tama = "Tamaulipas", tlax = "Tlaxcala", vera = "Veracruz", yuca = "Yucatan", zaca = "Zacatecas", chi = "Chiapas",
        //       cam = "Campeche", cali = "California", cli_S = "California Sur", aguas = "Aguascalientes", dis = "Distrito";
        string Tema, IdTema;
        string[,] Pregun_Resp;
        public int EstadoActualEquipo = 0;
        int FondoInicial = 2000,vecesmuestra =0;
        float angle;
        float aspectRatio;
        public string modo,StringPregunta ="";
        public string modoestado = "",RespuestaCorrecta="",Respuesta;
        public double Cronometro = 0,TiempoMaximo = 21,TiempoMaximoEquipo =16, tiemposAviso =15,cronometrobtnequipo =0;
        public string modojugador = "solo";
        public Vector2 TileDimensions
        {
            get { return tileDimensions; }
        }
        public Vector2 Tiles {
            get { return tiles; }
        }
        int est = 0;
        int[,] pos = new int[32,2],PosEsquinas1 = new int[1,2],PosEsquinas2 = new int[1,2],PosEsquinas3 = new int[1,2],PosEsquinas4 = new int[1,2];
        public bool Pausa = false;
        int[,] Suelo = new int[11, 13]{ {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                        {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                        {0, 5, 1, 1, 1, 1, 1, 1, 1, 1, 1, 4, 0},
                                        {31, 1, 30, 29, 28, 27, 26, 25, 24, 23, 22, 1, 21},
                                        {32, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 20},
                                        {33, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 19},
                                        {34, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 18},
                                        {35, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 17},
                                        {36, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 16},
                                        {37, 1, 6, 7, 8, 9, 10,11,12,13,14, 1, 15},
                                        {0,  2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 0} };

        int[,] Posicion = new int[11, 13]{   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                             {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                             {0, 28, 27, 26, 25, 24, 23, 22, 21, 20, 19, 18, 0},
                                             {0, 29, 0, 0, 0, 0, 0, 0, 0, 0, 0, 17, 0},
                                             {0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 16, 0},
                                             {0, 31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 15, 0},
                                             {0, 32, 0, 0, 0, 0, 0, 0, 0, 0, 0, 14, 0},
                                             {0, 33, 0, 0, 0, 0, 0, 0, 0, 0, 0, 13, 0},
                                             {0, 34, 0, 0, 0, 0, 0, 0, 0, 0, 0, 12, 0},
                                             {0, 35, 0, 0, 0, 0, 0, 0, 0, 0, 0, 11, 0},
                                             {0, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 0} };


        int[,] Mapa = new int[11, 13]{   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                             {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                                             {0, 28, 27, 26, 25, 24, 23, 22, 21, 20, 19, 18, 0},
                                             {0, 29, 0, 0, 0, 0, 0, 0, 0, 0, 0, 17, 0},
                                             {0, 30, 0, 0, 0, 0, 0, 0, 0, 0, 0, 16, 0},
                                             {0, 31, 0, 0, 0, 0, 0, 0, 0, 0, 0, 15, 0},
                                             {0, 32, 0, 0, 0, 0, 0, 0, 0, 0, 0, 14, 0},
                                             {0, 33, 0, 0, 0, 0, 0, 0, 0, 0, 0, 13, 0},
                                             {0, 34, 0, 0, 0, 0, 0, 0, 0, 0, 0, 12, 0},
                                             {0, 35, 0, 0, 0, 0, 0, 0, 0, 0, 0, 11, 0},
                                             {0, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 0} };

        public Juego(Game game, SoundEffect sound, SoundEffect sound_clic)
        {
            sound_pasmouse = sound;
            sound_click = sound_clic;
            for (int x = 0; x < 32; x++)
            {
                Estados.Add(game.Content.Load<Texture2D>("Img/0" + (x + 1)));
            }
            fondo1 = game.Content.Load<Texture2D>("Img/Prueba5");
            ga = game;
            mexico = game.Content.Load<Texture2D>("Img/034");
            goo = game.Content.Load<Texture2D>("Img/035");
            colmexico = game.Content.Load<Texture2D>("Img/036");
            paga = game.Content.Load<Texture2D>("Img/037");
            banco = game.Content.Load<Texture2D>("Img/Ban");
            hotel = game.Content.Load<Texture2D>("Img/Hotel");
            td_FondobarraEquipo = game.Content.Load<Texture2D>("Img/FondoEquipo");
            ModeloDado = game.Content.Load<Model>("Model/Dad");
            fuente = game.Content.Load<SpriteFont>("fuente");
            fuete11 = game.Content.Load<SpriteFont>("Fuente11");
            btn_TirarDado = new Botones(game.Content.Load<Texture2D>("Img/btn_tirar"), sound_pasmouse, sound_click, game.GraphicsDevice);
            btn_TirarDado.setPosicion(new Vector2(360, 460));
            btn_TirarDado.setPosicionRectanguloIsOver(new Vector2(360, 456));
            tileDimensions = new Vector2(113, 65);
            tiles = new Vector2(113, 40);
            aspectRatio = (float)game.Window.ClientBounds.Width /
            (float)game.Window.ClientBounds.Height;
        }
        public Juego(Game game, string[] arrayEquipo, string tema, string Idtema, string[,] Pregunta_Respuesta, SoundEffect sound, SoundEffect soud_clic, SpriteFont fuentPausa)
        {
            activa = true;
            sound_pasmouse = sound;
            sound_click = soud_clic;
            guimanager = new GUIManager(game, "Themes", "Default");
            VentanaWindows = new Window(new Rectangle(10, 40, 1200, 768), "Turista");
            VentanaWindows.Transparency = 0;
            VentanaWindows.Movable = false;
            guimanager.Controls.Add(VentanaWindows);

            for (int x = 0; x < 32; x++)
            {
                Estados.Add(game.Content.Load<Texture2D>("Img/0" + (x + 1)));
            }
            fondo1 = game.Content.Load<Texture2D>("Img/Prueba5");
            ga = game;
            mexico = game.Content.Load<Texture2D>("Img/034");
            goo = game.Content.Load<Texture2D>("Img/035");
            avion = game.Content.Load<Texture2D>("Img/avion");
            colmexico = game.Content.Load<Texture2D>("Img/036");
            paga = game.Content.Load<Texture2D>("Img/037");
            for (int x = 0; x < 32; x++)
            {
                Hoteles.Add(game.Content.Load<Texture2D>("Img/Hotel"));
            }
            cHotel = new ColocarHotel[Hoteles.Count];
            for (int x = 0; x < cHotel.Length; x++)
            {
                cHotel[x] = new ColocarHotel(Hoteles[x]);
                cHotel[x].MostrarHotel = false;
            }
            banco = game.Content.Load<Texture2D>("Img/Ban");
            hotel = game.Content.Load<Texture2D>("Img/Hotel");
            td_FondobarraEquipo = game.Content.Load<Texture2D>("Img/FondoEquipo");
            td_FondoPausa = game.Content.Load<Texture2D>("Img/opaco");
            Img_Aviso = game.Content.Load<Texture2D>("Img/Img_aviso");
            td_barra = game.Content.Load<Texture2D>("Img/Barra");
            vertabla = game.Content.Load<Texture2D>("Img/img_pausa");
            rec_pausa = new Rectangle(0, 0, game.Window.ClientBounds.Width, game.Window.ClientBounds.Height);
            ModeloDado = game.Content.Load<Model>("Model/Dad");
            NombreEquipos = arrayEquipo;
            Tema = tema;
            fuente = game.Content.Load<SpriteFont>("fuente");
            fuete11 = game.Content.Load<SpriteFont>("Fuente11");
            FuenteTiempo = game.Content.Load<SpriteFont>("fuentetiempo");
            fuenteaviso = game.Content.Load<SpriteFont>("FuenteAviso");
            fuenteaviso1 = game.Content.Load<SpriteFont>("FuenteAviso1");
            IdTema = Idtema;
            for (int x = 0; x < NombreEquipos.Length; x++)
            {
                equipos.Add(game.Content.Load<Texture2D>("Img/Equipo" + (x + 1)));
            }

            Equipo = new DibujaEquipo[arrayEquipo.Length];
            Vector2 PosicionTexto;
            float posisciontext = 50;
            int posi = 4;
            for (int x = 0; x < arrayEquipo.Length; x++)
            {
                PosicionTexto = new Vector2(posisciontext, 4);
                Equipo[x] = new DibujaEquipo(arrayEquipo[x],x, posi, posisciontext, PosicionTexto, fuente, equipos[x], td_FondobarraEquipo);
                posisciontext += 250;
                posi += 250;
            }
            Equipo[0].ActualEquipo = true;
            jug = new Jugador(game,avion);
            cJugador = new Jugador[NombreEquipos.Length];
            variable = new Var();
            int con = 2;
            for (int x = NombreEquipos.Length - 1; x >= 0; x--)
            {
                cJugador[x] = new Jugador(Posicion, posImagen, PosEsquina, equipos[x], NombreEquipos.Length, con);
                con += 20;
            }
            cJugador[0].ActualJugador = true;

            Pregun_Resp = Pregunta_Respuesta;
            fuetepausa = fuentPausa;
            tileDimensions = new Vector2(113, 65);
            tiles = new Vector2(113, 40);
            aspectRatio = (float)game.Window.ClientBounds.Width /
            (float)game.Window.ClientBounds.Height;

            btn_TirarDado = new Botones(game.Content.Load<Texture2D>("Img/btn_tirar"), sound_pasmouse, sound_click, game.GraphicsDevice);
            btn_TirarDado.setPosicion(new Vector2(360, 460));
            btn_TirarDado.setPosicionRectanguloIsOver(new Vector2(360, 456));

            btn_ReanudarJuego = new Botones(game.Content.Load<Texture2D>("Img/ReanudarJuego"), sound_pasmouse, sound_click, game.GraphicsDevice);
            btn_ReanudarJuego.setPosicion(new Vector2(1000, 140 + 20));
            btn_ReanudarJuego.setPosicionRectanguloIsOver(new Vector2(1000, 140 + 20));

            btn_Opciones = new Botones(game.Content.Load<Texture2D>("Img/OpcionesJuego"), sound_pasmouse, sound_click, game.GraphicsDevice);
            btn_Opciones.setPosicion(new Vector2(1000, 170 + 40));
            btn_Opciones.setPosicionRectanguloIsOver(new Vector2(1000, 170 + 40));

            btn_Reiniciar = new Botones(game.Content.Load<Texture2D>("Img/btn_finalizar"), sound_pasmouse, sound_click, game.GraphicsDevice);
            btn_Reiniciar.setPosicion(new Vector2(1000, 200 + 60));
            btn_Reiniciar.setPosicionRectanguloIsOver(new Vector2(1000, 200 + 60));

            btn_Salir = new Botones(game.Content.Load<Texture2D>("Img/btn_salir"), sound_pasmouse, sound_click, game.GraphicsDevice);
            btn_Salir.setPosicion(new Vector2(1000, 230 + 80));
            btn_Salir.setPosicionRectanguloIsOver(new Vector2(1000, 230 + 80));

            btn_si = new Botones(game.Content.Load<Texture2D>("Img/btn_ResSi"), sound_pasmouse, sound_click, game.GraphicsDevice);
            btn_si.setPosicion(new Vector2(540, 400));
            btn_si.setPosicionRectanguloIsOver(new Vector2(540, 400));

            btn_no = new Botones(game.Content.Load<Texture2D>("Img/btn_ResNo"), sound_pasmouse, sound_click, game.GraphicsDevice);
            btn_no.setPosicion(new Vector2(710, 400));
            btn_no.setPosicionRectanguloIsOver(new Vector2(710, 400));

            btn_Contestar = new Botones(game.Content.Load<Texture2D>("Img/btn_contestar"), sound_pasmouse, sound_click, game.GraphicsDevice);
            btn_Contestar.setPosicion(new Vector2(395, 540));
            btn_Contestar.setPosicionRectanguloIsOver(new Vector2(395, 540));

            btnPreguntarEquipo = new Botones(game.Content.Load<Texture2D>("Img/btn_PreguntarEquipo"), sound_pasmouse, sound_click, game.GraphicsDevice);
            btnPreguntarEquipo.setPosicion(new Vector2(590, 540));
            btnPreguntarEquipo.setPosicionRectanguloIsOver(new Vector2(590, 540));

            btn_penlizar = new Botones(game.Content.Load<Texture2D>("Img/btn_penalizar"), sound_pasmouse, sound_click, game.GraphicsDevice);
            btn_penlizar.setPosicion(new Vector2(850, 540));
            btn_penlizar.setPosicionRectanguloIsOver(new Vector2(850, 540));

            btn_cerrar = new Botones(game.Content.Load<Texture2D>("Img/btn_cerrar"), sound_pasmouse, sound_click, game.GraphicsDevice);
            btn_cerrar.setPosicion(new Vector2(600, 540));
            btn_cerrar.setPosicionRectanguloIsOver(new Vector2(600, 540));
        }
        public bool TiempoAgotado = false;
        public bool VerTabla = false, ColocarHotel = false, Contesta = false, MuetraMensajeComprEStado = false;
        public string btnequipo = "";
        public int Maximo_Vueltas = 5, Contador = 0, IndiceHotel = 0, PrecRentaHotel = 20;
        double CronometroDado = 0,CronometroAvanza =0;
        int TiempoMover;
        public void Update(GameTime gameTime, MouseState MouseAct, MouseState MouseAnt, bool ventanaAct)
        {
            switch (EstadoJuegoActual)
            {
                case EstadoJuego.Jugando:
                    if (Pausa != true || EstadoJugando !="finalizar_Juego")
                    {
                        if (tirardado == true)
                        {
                            angle += 0.04f;
                            TiempoMover++;
                        }
                        if (tirardado == false)
                        {
                            CronometroDado += gameTime.ElapsedGameTime.TotalSeconds;
                            if (CronometroDado > 3)
                            {
                                angle = 0;
                                CronometroDado = 0;
                            }
                        }

                        if (btn_TirarDado.isClicked == true)
                        {
                            btn_TirarDado.isClicked = false;
                            Random ran = new Random();
                            NumCaidoDado = ran.Next(1, 6);
                            tirardado = true;
                        }
                        if (AvanzarEquipo == true)
                        {
                            CronometroAvanza += gameTime.ElapsedGameTime.TotalSeconds;
                            if (CronometroAvanza > 1)
                            {
                                CronometroAvanza = 0;
                                AvanzarEquipo = false;
                                modo = "Avanzando";
                                cJugador[EstadoActualEquipo].jugadorActual = EstadoActualEquipo;
                                cJugador[EstadoActualEquipo].AvanzaJugador(NumCaidoDado);
                                Equipo[EstadoActualEquipo].NumeroVueltas = cJugador[EstadoActualEquipo].NumVueltas;
                                if (cJugador[EstadoActualEquipo].MensajePorPasarMexico == true)
                                {
                                    cJugador[EstadoActualEquipo].MensajePorPasarMexico = false;
                                    avisos("       Bonifición $200 al pasar Mexico", "Equipo : " + Equipo[EstadoActualEquipo].nombreequipo + "Fondo Total: " + Equipo[EstadoActualEquipo].Fondo, "", Color.Red, "Pasar_por_Mexico");
                                }
                            }
                        }
                        if (EstadoJugando == "MostrarMensajeEstado" || EstadoJugando == "MuestraPregunta" || tirardado == true)
                        {
                            //btn_TirarDado.Update(MouseAct, MouseAnt, ventanaAct);
                        }
                        else
                        {
                            btn_TirarDado.Update(MouseAct, MouseAnt, ventanaAct);
                        }
                        if (EstadoJugando == "MostrarMensajeEstado")
                        {
                            btn_si.Update(MouseAct, MouseAnt, ventanaAct);
                            btn_no.Update(MouseAct, MouseAnt, ventanaAct);
                            if (btn_si.isClicked == true && ColocarHotel == false)
                            {
                                btn_si.isClicked = false;
                                Equipo[EstadoActualEquipo].Fondo -= Convert.ToInt32(cJugador[EstadoActualEquipo].NombreEstadoRe[cJugador[EstadoActualEquipo].NumCaido - 1, 1]);
                                cJugador[EstadoActualEquipo].MostrarMensaje = false;
                                EstadosVendidos[cJugador[EstadoActualEquipo].NumCaido - 1, 0] = EstadoActualEquipo.ToString();
                                EstadosVendidos[cJugador[EstadoActualEquipo].NumCaido - 1, 1] = cJugador[EstadoActualEquipo].NombreEstadoRe[cJugador[EstadoActualEquipo].NumCaido - 1, 0];
                                EstadosVendidos[cJugador[EstadoActualEquipo].NumCaido - 1, 2] = "Vendido";
                                MuetraMensajeComprEStado = false;
                                ColocarHotel = true;
                                EstadoJugando = "Normal";
                            }
                            if (btn_no.isClicked == true)
                            {
                                btn_no.isClicked = false;
                                cJugador[EstadoActualEquipo].MostrarMensaje = false;
                                MuetraMensajeComprEStado = false;
                                EstadoActualEquipo = SiguienteEquipo(EstadoActualEquipo);
                                SiguienteEquipoActual();
                                EstadoJugando = "Normal";
                            }
                        }
                        if (EstadoJugando == "MensajeColocarHotel")
                        {
                            btn_si.Update(MouseAct, MouseAnt, ventanaAct);
                            btn_no.Update(MouseAct, MouseAnt, ventanaAct);

                            if (btn_si.isClicked == true)
                            {
                                btn_si.isClicked = false;
                                Equipo[EstadoActualEquipo].Fondo -= 100;
                                cHotel[IndiceHotel].MostrarHotel = true;
                                cHotel[IndiceHotel].ColocaHotelEnEstado(cJugador[EstadoActualEquipo].NumCaido);
                                ColacadosHoteles[cJugador[EstadoActualEquipo].NumCaido -1] = "ColocadoHotel";
                                EstadoActualEquipo = SiguienteEquipo(EstadoActualEquipo);
                                SiguienteEquipoActual();
                                EstadoJugando = "Normal";
                                ColocarHotel = false;
                                IndiceHotel++;
                            }
                            if (btn_no.isClicked == true) {
                                EstadoActualEquipo = SiguienteEquipo(EstadoActualEquipo);
                                SiguienteEquipoActual();
                                EstadoJugando = "Normal";
                                ColocarHotel = false;
                            }
                        }
                        if (activa != false)
                        {
                            VerificaRadioButon(gameTime);
                            foreach (Jugador jugador in cJugador)
                            {
                                jugador.Update(gameTime);
                            }
                            //if (cJugador[EstadoActualEquipo].MensajePorPasarMexico == true)
                            //{
                            //    cJugador[EstadoActualEquipo].MensajePorPasarMexico = false;
                            //    avisos("       Bonifición $200 al pasar Mexico", "Equipo : " + Equipo[EstadoActualEquipo].nombreequipo + "Fondo Total: " + Equipo[EstadoActualEquipo].Fondo, "", Color.Red, "Pasar_por_Mexico");
                            //}
                            if (cJugador[EstadoActualEquipo].MostrarMensaje == true)
                            {
                                MuetraMensajeComprEStado = true;
                            }
                            if (cJugador[EstadoActualEquipo].MostrarMensajePregunta == true)
                            {
                                EstadoJugando = "MuestraPregunta";
                                if (modoestado != "aviso")
                                {
                                    Cronometro += gameTime.ElapsedGameTime.TotalSeconds;
                                    guimanager.Update(gameTime);
                                }
                                vecesmuestra++;
                                if (vecesmuestra == 1)
                                {
                                    MuestraPregunta();
                                }
                                btn_Contestar.Update(MouseAct, MouseAnt, ventanaAct);
                                btnPreguntarEquipo.Update(MouseAct, MouseAnt, ventanaAct);
                                btn_penlizar.Update(MouseAct, MouseAnt, ventanaAct);
                                guimanager.Update(gameTime);
                                if (modojugador == "solo")
                                {
                                    if (TiempoMaximo - Cronometro < 1)
                                    {
                                        veMuestra++;
                                        if (veMuestra == 1)
                                        {
                                            avisos("                   ¡Tiempo Agotado! ", "        Equipo:  " + Equipo[EstadoActualEquipo].nombreequipo, "QuitarMensaje", Color.Red, "Tiempo_agotado_solo");
                                        }
                                    }
                                }
                                else
                                {
                                    if (modojugador == "equipo")
                                    {
                                        if (TiempoMaximoEquipo - Cronometro < 1)
                                        {
                                            veMuestra++;
                                            if (veMuestra == 1)
                                            {
                                                avisos("               ¡Tiempo Agotado!", "        Equipo:  " + Equipo[EstadoActualEquipo].nombreequipo, "QuitarMensaje", Color.Red, "Tiempo_agotado_equipo");
                                            }
                                        }
                                    }
                                }

                            }
                            if (cJugador[EstadoActualEquipo].CaidoEsquina == true && cJugador[EstadoActualEquipo].MensajePagar == true)
                            {

                                cJugador[EstadoActualEquipo].MensajePagar = false;
                                avisos("      Cubrir couta de $50 al Equipo: " + Equipo[EstadoActualEquipo].nombreequipo, "Fondo Total Equipo:  " + Equipo[EstadoActualEquipo].Fondo, "", Color.Red, "pagar_al_banco");

                                cJugador[EstadoActualEquipo].CaidoEsquina = false;
                            }
                            else
                            {
                                if (cJugador[EstadoActualEquipo].CaidoEsquina == true)
                                {
                                    cJugador[EstadoActualEquipo].CaidoEsquina = false;
                                    EstadoActualEquipo = SiguienteEquipo(EstadoActualEquipo);
                                    SiguienteEquipoActual();
                                }
                            }
                            if (cJugador[EstadoActualEquipo].MensajePagar == true)
                            {
                                cJugador[EstadoActualEquipo].MensajePagar = false;
                                avisos("       Cubrir couta de $50 al Equipo: " + Equipo[EstadoActualEquipo].nombreequipo, "Fondo Total Equipo:  " + Equipo[EstadoActualEquipo].Fondo, "", Color.Red, "pagar_al_banco");
                            }
                            if (cJugador[EstadoActualEquipo].Estado_suyo == true) {
                                cJugador[EstadoActualEquipo].Estado_suyo = false;
                                EstadoActualEquipo = SiguienteEquipo(EstadoActualEquipo);
                                SiguienteEquipoActual();
                            }
                            if (btnPreguntarEquipo.isClicked == true) {
                                avisos("                     ¡Modo Equipo !", "", "", Color.Red, "modo_equipo");
                                btnPreguntarEquipo.isClicked = false;
                            }
                            if (btn_penlizar.isClicked == true)
                            {
                                btn_penlizar.isClicked = false;
                                if (modojugador == "solo")
                                {
                                    int val = ((Int32.Parse(cJugador[EstadoActualEquipo].NombreEstadoRe[cJugador[EstadoActualEquipo].NumCaido - 1, 1]) * 25) / 100);
                                    Equipo[EstadoActualEquipo].Fondo -= val * 2;
                                    int x = Int32.Parse(EstadosVendidos[cJugador[EstadoActualEquipo].NumCaido - 1, 0]);
                                    Equipo[x].Fondo += val * 2;
                                    Salir();
                                }
                                else {
                                    if (modojugador == "equipo")
                                    {
                                        int val = ((Int32.Parse(cJugador[EstadoActualEquipo].NombreEstadoRe[cJugador[EstadoActualEquipo].NumCaido - 1, 1]) * 25) / 100);
                                        Equipo[EstadoActualEquipo].Fondo -= val * 2;
                                        int x = Int32.Parse(EstadosVendidos[cJugador[EstadoActualEquipo].NumCaido - 1, 0]);
                                        Equipo[x].Fondo += val * 2;
                                        Salir();
                                        PosicionOriginalBotones();
                                        modojugador = "solo";
                                    }
                                }
                            }
                            if (btnequipo == "Dandoclickbtnequipo")
                            {
                                btnequipo = "";
                                avisos("                     ¡En Equipo!", "", "", Color.Red, "click");
                            }
                            if (modoestado == "aviso")
                            {
                                cronometroAviso += gameTime.ElapsedGameTime.TotalSeconds;
                                cronometroParpadeo += gameTime.ElapsedGameTime.TotalSeconds;
                                if (cronometroAviso > 4)
                                {
                                    cronometroAviso = 0;
                                    if (ModoAviso == "Correcto_ModoSolo")
                                    {
                                        int val = ((Int32.Parse(cJugador[EstadoActualEquipo].NombreEstadoRe[cJugador[EstadoActualEquipo].NumCaido - 1, 1]) * 25) / 100);
                                        Equipo[EstadoActualEquipo].Fondo -= (val * 50) / 100;
                                        int x = Int32.Parse(EstadosVendidos[cJugador[EstadoActualEquipo].NumCaido - 1, 0]);
                                        if (ColacadosHoteles[cJugador[EstadoActualEquipo].NumCaido - 1] == "ColocadoHotel")
                                        {
                                            Equipo[EstadoActualEquipo].Fondo -= (PrecRentaHotel * 50) / 100;
                                            Equipo[x].Fondo += (PrecRentaHotel * 50) / 100;
                                        }
                                        Equipo[x].Fondo += (val * 50) / 100;
                                        Salir();
                                    }
                                    if (ModoAviso == "Incorrecto_ModoSolo")
                                    {
                                        Cronometro = 0;
                                        int val = ((Int32.Parse(cJugador[EstadoActualEquipo].NombreEstadoRe[cJugador[EstadoActualEquipo].NumCaido - 1, 1]) * 25) / 100);
                                        Equipo[EstadoActualEquipo].Fondo -= val;
                                        int x = Int32.Parse(EstadosVendidos[cJugador[EstadoActualEquipo].NumCaido - 1, 0]);
                                        if (ColacadosHoteles[cJugador[EstadoActualEquipo].NumCaido - 1] == "ColocadoHotel")
                                        {
                                            Equipo[EstadoActualEquipo].Fondo -= PrecRentaHotel;
                                            Equipo[x].Fondo += PrecRentaHotel;
                                        }
                                        Equipo[x].Fondo += val;
                                        Salir();
                                    }
                                    if (ModoAviso == "Correcto_ModoEquipo")
                                    {
                                        Cronometro = 0;
                                        int val = ((Int32.Parse(cJugador[EstadoActualEquipo].NombreEstadoRe[cJugador[EstadoActualEquipo].NumCaido - 1, 1]) * 25) / 100);
                                        Equipo[EstadoActualEquipo].Fondo -= (val * 75) / 100;
                                        int x = Int32.Parse(EstadosVendidos[cJugador[EstadoActualEquipo].NumCaido - 1, 0]);
                                        if (ColacadosHoteles[cJugador[EstadoActualEquipo].NumCaido - 1] == "ColocadoHotel")
                                        {
                                            Equipo[EstadoActualEquipo].Fondo -= (PrecRentaHotel * 75) / 100;
                                            Equipo[x].Fondo += (PrecRentaHotel * 75) / 100;
                                        }
                                        Equipo[x].Fondo += (val * 75) / 100;
                                        PosicionOriginalBotones();
                                        Salir();
                                        modojugador = "solo";
                                    }
                                    if (ModoAviso == "Incorrecto_ModoEquipo")
                                    {
                                        Cronometro = 0;
                                        int val = ((Int32.Parse(cJugador[EstadoActualEquipo].NombreEstadoRe[cJugador[EstadoActualEquipo].NumCaido - 1, 1]) * 25) / 100);
                                        Equipo[EstadoActualEquipo].Fondo -= val;
                                        int x = Int32.Parse(EstadosVendidos[cJugador[EstadoActualEquipo].NumCaido - 1, 0]);
                                        if (ColacadosHoteles[cJugador[EstadoActualEquipo].NumCaido - 1] == "ColocadoHotel")
                                        {
                                            Equipo[EstadoActualEquipo].Fondo -= PrecRentaHotel;
                                            Equipo[x].Fondo += PrecRentaHotel;
                                        }
                                        Equipo[x].Fondo += val;
                                        PosicionOriginalBotones();
                                        Salir();
                                        modojugador = "solo";
                                    }
                                    if (ModoAviso == "Tiempo_agotado_solo")
                                    {
                                        modoestado = "quitarmensaje";
                                        btnequipo = "Dandoclickbtnequipo";
                                        veMuestra = 0;
                                    }
                                    if (ModoAviso == "Tiempo_agotado_equipo")
                                    {
                                        Cronometro = 0;
                                        int val = ((Int32.Parse(cJugador[EstadoActualEquipo].NombreEstadoRe[cJugador[EstadoActualEquipo].NumCaido - 1, 1]) * 25) / 100);
                                        Equipo[EstadoActualEquipo].Fondo -= val + (val * 25 / 100);
                                        int x = Int32.Parse(EstadosVendidos[cJugador[EstadoActualEquipo].NumCaido - 1, 0]);
                                        if (ColacadosHoteles[cJugador[EstadoActualEquipo].NumCaido - 1] == "ColocadoHotel")
                                        {
                                            Equipo[EstadoActualEquipo].Fondo -= PrecRentaHotel + (PrecRentaHotel * 25 / 100);
                                            Equipo[x].Fondo += PrecRentaHotel + (PrecRentaHotel * 25 / 100);
                                        }
                                        Equipo[x].Fondo += val + (val * 25 / 100);
                                        Salir();
                                        PosicionOriginalBotones();
                                        modojugador = "solo";
                                        veMuestra = 0;
                                    }
                                    if (ModoAviso == "click")
                                    {
                                        modojugador = "equipo";
                                        modoestado = "quitarmensaje";
                                        cronometrobtnequipo = 0;
                                        Cronometro = 0;
                                        veMuestra = 0;
                                        btn_Contestar.setPosicion(new Vector2(540, 530));
                                        btn_Contestar.setPosicionRectanguloIsOver(new Vector2(540, 530));
                                        btn_penlizar.setPosicion(new Vector2(700, 530));
                                        btn_penlizar.setPosicionRectanguloIsOver(new Vector2(700, 530));
                                    }
                                    if (ModoAviso == "modo_equipo")
                                    {
                                        modoestado = "quitarmensaje";
                                        modojugador = "equipo";
                                        cronometroAviso = 0;
                                        cronometroParpadeo = 0;
                                        btn_Contestar.setPosicion(new Vector2(540, 530));
                                        btn_Contestar.setPosicionRectanguloIsOver(new Vector2(540, 530));
                                        btn_penlizar.setPosicion(new Vector2(700, 530));
                                        btn_penlizar.setPosicionRectanguloIsOver(new Vector2(700, 530));
                                        cronometrobtnequipo = 0;
                                        Cronometro = 0;
                                    }
                                    if (ModoAviso == "pagar_al_banco")
                                    {
                                        Cronometro = 0;
                                        FondoInicial += 50;
                                        Equipo[EstadoActualEquipo].Fondo -= 50;
                                        modoestado = "quitarmensaje";
                                        cronometroAviso = 0;
                                        cronometroParpadeo = 0;
                                        EstadoActualEquipo = SiguienteEquipo(EstadoActualEquipo);
                                        SiguienteEquipoActual();
                                    }
                                    if (ModoAviso == "Pasar_por_Mexico") {
                                        Cronometro = 0;
                                        FondoInicial -= 200;
                                        Equipo[EstadoActualEquipo].Fondo += 200;
                                        modoestado = "quitarmensaje";
                                        cronometroAviso = 0;
                                        cronometroParpadeo = 0;
                                    }
                                }
                            }
                            if (btn_Contestar.isClicked == true)
                            {
                                if (Respuesta == RespuestaCorrecta)
                                {
                                    if (modojugador == "solo")
                                    {
                                        avisos("  ¡Respuesta Correcta! Descuento 50% ", "  Equipo: " + Equipo[EstadoActualEquipo].nombreequipo + " Fondo Total: " + Equipo[EstadoActualEquipo].Fondo, "QuitarMensaje ", Color.Green, "Correcto_ModoSolo");
                                        btn_Contestar.isClicked = false;
                                        btnPreguntarEquipo.isClicked = false;
                                    }
                                    if (modojugador == "equipo")
                                    {
                                        avisos("  ¡Respuesta Correcta! Descuento 25% ", "  Equipo: " + Equipo[EstadoActualEquipo].nombreequipo + " Fondo: " + Equipo[EstadoActualEquipo].Fondo, "QuitarMensaje ", Color.Green, "Correcto_ModoEquipo");
                                        btn_Contestar.isClicked = false;
                                        btnPreguntarEquipo.isClicked = false;
                                    }
                                }
                                else
                                {
                                    if (modojugador == "solo")
                                    {
                                        avisos("  ¡Respuesta Incorrecta! Descuento 0%", "  Equipo: " + Equipo[EstadoActualEquipo].nombreequipo + " Fondo: " + Equipo[EstadoActualEquipo].Fondo, "QuitarMensaje ", Color.Red, "Incorrecto_ModoSolo");
                                        btn_Contestar.isClicked = false;
                                        btnPreguntarEquipo.isClicked = false;
                                    }
                                    if (modojugador == "equipo")
                                    {
                                        avisos("  ¡Respuesta Incorrecta! Descuento 0%", "  Equipo: " + Equipo[EstadoActualEquipo].nombreequipo + " Fondo: " + Equipo[EstadoActualEquipo].Fondo, "QuitarMensaje ", Color.Red, "Incorrecto_ModoEquipo");
                                        btn_Contestar.isClicked = false;
                                        btnPreguntarEquipo.isClicked = false;
                                    }
                                }
                            }
                            if (Keyboard.GetState().IsKeyDown(Keys.Tab))
                            {
                                VerTabla = true;
                            }
                        }
                    }
                    if (EstadoJugando == "finalizar_Juego")
                    {
                        if (MuestraTabla != true)
                        {
                            Crono += gameTime.ElapsedGameTime.TotalSeconds;
                            CronoAvanza += gameTime.ElapsedGameTime.TotalSeconds;
                            Contador++;
                            if (Contador == 1)
                            {
                                int con = 0;
                                int PosY = 120;

                                for (int x = 0; x < EstadosVendidos.Length / 3; x++)
                                {
                                    if (EstadosVendidos[x, 0] != null)
                                    {
                                        if (ActualEquipo == Int32.Parse(EstadosVendidos[x, 0]) && cJugador[ActualEquipo].NombreEstadoRe[x, 0] == EstadosVendidos[x, 1])
                                        {
                                            con++;
                                        }
                                    }
                                }
                                if (con == 0)
                                {
                                    Equipo[ActualEquipo].EdosComprados = false;
                                }
                                CantidadImagenes = con;
                                NomEstados = new string[con];
                                Nombreestados = new string[con];
                                precio = new int[con];
                                int cont = 0;
                                for (int x = 0; x < EstadosVendidos.Length / 3; x++)
                                {
                                    if (EstadosVendidos[x, 0] != null)
                                    {
                                        if (ActualEquipo == Int32.Parse(EstadosVendidos[x, 0]) && cJugador[ActualEquipo].NombreEstadoRe[x, 0] == EstadosVendidos[x, 1])
                                        {
                                            NomEstados[cont] = cJugador[ActualEquipo].NombreEstadoRe[x, 2];
                                            Nombreestados[cont] = cJugador[ActualEquipo].NombreEstadoRe[x, 0];
                                            precio[cont] = Int32.Parse(cJugador[EstadoActualEquipo].NombreEstadoRe[x, 1]);
                                            cont++;
                                        }
                                    }
                                }
                                cEstados = new DibujaEstados[con];
                                for (int x = 0; x < NomEstados.Length; x++)
                                {
                                    cEstados[x] = new DibujaEstados(Nombreestados[x], x, PosY, precio[x], fuente, ga.Content.Load<Texture2D>("Img/" + NomEstados[x]));
                                    PosY += 75;
                                }
                                btn_cerrar.Update(MouseAct, MouseAnt, ventanaAct);
                            }
                            if (Crono > 2)
                            {
                                if (CronoAvanza > 1)
                                {
                                    if (ActualImagen < CantidadImagenes)
                                    {
                                        cEstados[ActualImagen].Mover = true;
                                    }
                                    if (Equipo[ActualEquipo].EdosComprados == false)
                                    {
                                        ActualEquipo = siguienteEqui(ActualEquipo);
                                        SiguienteEquipoAct();
                                        Contador = 0;
                                        CronoAvanza = 0;
                                        ActualImagen = 0;
                                    }
                                }
                            }
                            foreach (DibujaEstados estados in cEstados)
                            {
                                estados.Update(gameTime, ActualImagen);
                            }
                            if (ActualImagen < CantidadImagenes)
                            {
                                if (cEstados[ActualImagen].ActualizarFondo == true)
                                {
                                    contador++;
                                    if (contador == 1)
                                    {
                                        cEstados[ActualImagen].ActualizarFondo = false;
                                        Equipo[ActualEquipo].Fondo += cEstados[ActualImagen].Fondo / 2;
                                    }
                                }
                                if (cEstados[ActualImagen].Quitar == true)
                                {
                                    contador = 0;
                                    cEstados[ActualImagen].Quitar = false;
                                    SiguienteImagen();
                                    CronoAvanza = 0;
                                }
                            }
                            if (EsUltimo == true)
                            {
                                ActualEquipo = siguienteEqui(ActualEquipo);
                                SiguienteEquipoAct();
                                Contador = 0;
                                CronoAvanza = 0;
                                ActualImagen = 0;
                                EsUltimo = false;
                            }
                            if (UltimoEquipo == true)
                            {
                                MuestraTabla = true;
                            }
                        }
                        if (MuestraTabla == true)
                        {
                            btn_cerrar.Update(MouseAct, MouseAnt, ventanaAct);
                        }
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                    {
                        if (EstadoJugando == "MuestraPregunta" || EstadoJugando == "finalizar_Juego")
                        {
                           
                        }
                        else {
                            Pausa = true;
                            sound_pasmouse.Play();
                            EstadoJuegoActual = EstadoJuego.Pausa;
                        }
                    }
                    break;
                case EstadoJuego.Pausa:
                    if (btn_ReanudarJuego.isClicked == true)
                    {
                        EstadoJuegoActual = EstadoJuego.Jugando;
                        Pausa = false;
                        veMuestra = 0;
                    }
                    if (btn_Opciones.isClicked == true)
                    {
                        Opc_jugando = new OpcionesJugando(ga, Equipo, EstadoActualEquipo);
                        EstadoJuegoActual = EstadoJuego.OpcionesJugando;
                        btn_Opciones.isClicked = false;
                    }
                    if (btn_Reiniciar.isClicked == true)
                    {
                        EstadoJuegoActual = EstadoJuego.Jugando;
                        EstadoJugando = "finalizar_Juego";
                        ActualEquipo = 0;
                    }
                    btn_ReanudarJuego.Update(MouseAct, MouseAnt, ventanaAct);
                    btn_Opciones.Update(MouseAct, MouseAnt, ventanaAct);
                    btn_Reiniciar.Update(MouseAct, MouseAnt, ventanaAct);
                    btn_Salir.Update(MouseAct, MouseAnt, ventanaAct);
                    break;
                case EstadoJuego.OpcionesJugando:
                    if (Opc_jugando.btn_cancelar.isClicked == true) {
                        EstadoJuegoActual = EstadoJuego.Jugando;
                        Pausa = false;
                        Opc_jugando.btn_cancelar.isClicked = false;
                    }
                    if (Opc_jugando.CambiosGuardados == true) {
                        Opc_jugando.CambiosGuardados = false;
                        EstadoJuegoActual = EstadoJuego.Jugando;
                        Pausa = false;
                        EstadoActualEquipo = Opc_jugando.Equipo_Actual;
                    }
                    Opc_jugando.Update(gameTime,MouseAct, MouseAnt, ventanaAct);
                    break;
            }
        }
        public void PosicionOriginalBotones()
        {
            btn_Contestar.setPosicion(new Vector2(395, 530));
            btn_Contestar.setPosicionRectanguloIsOver(new Vector2(395, 530));
            btn_penlizar.setPosicion(new Vector2(850, 530));
            btn_penlizar.setPosicionRectanguloIsOver(new Vector2(850, 530));
        }
        public void SiguienteImagen() {
            if (ActualImagen < CantidadImagenes - 1) {
                ActualImagen++;
            } else {
                EsUltimo = true;
            }
        }
        public int veMuestra = 0, ActualImagen = 0, CantidadImagenes = 0, ActualEquipo = 0, VecesAumenta = 0, VecesUltimo = 0, contador = 0;
        public double Crono = 0,CronoAvanza=0,cron =0;
        public bool EsUltimo = false, MuestraTabla = false, UltimoImagen = false;
        public void VerificaRadioButon(GameTime g)
        {
            if (rb_Respuesta1 != null || rb_Respuesta2 != null || rb_Respuesta3 != null)
            {
                if (rb_Respuesta1.Checked)
                {
                    Respuesta = "A";
                }
                if (rb_Respuesta2.Checked)
                {
                    Respuesta = "B";
                }
                if (rb_Respuesta3.Checked)
                {
                    Respuesta = "C";
                }
                if (rb_Respuesta4.Checked)
                {
                    Respuesta = "D";
                }
            }
        }
        public string[] equiposganadores = null,equiposperdedores =null;
        int ContadorPagaHoteles = 0;
        bool AvanzarEquipo = false;
        public void Draw(SpriteBatch batch)
        {
            Microsoft.Xna.Framework.Rectangle bgRect;
            bgRect = new Microsoft.Xna.Framework.Rectangle(0, 0, ga.Window.ClientBounds.Width, ga.Window.ClientBounds.Height);
            if (fondo1 != null)
            {
                DrawEstados(batch);
                DrawBank(batch);
                batch.Draw(td_FondobarraEquipo, new Rectangle(0, 0, ga.Window.ClientBounds.Width, 80), Color.White);
                batch.Draw(td_FondobarraEquipo, new Rectangle(0, 0, ga.Window.ClientBounds.Width, 80), Color.White);
                batch.Draw(td_FondobarraEquipo, new Rectangle(0, 0, ga.Window.ClientBounds.Width, 80), Color.White);
                btn_TirarDado.Draw(batch);
                if (activa != false)
                {
                    foreach (ColocarHotel hot in cHotel) {
                        hot.Draw(batch);
                    }
                    foreach (DibujaEquipo eq in Equipo) {
                        eq.Draw(batch);
                    }
                    batch.Draw(equipos[EstadoActualEquipo], new Rectangle(380, 250, 100, 200), Color.White);
                    for (int c = cJugador.Length -1; c >= 0; c--)
                    {
                        cJugador[c].Draw(batch);
                    }
                    if (MuetraMensajeComprEStado == true)
                    {
                        batch.Draw(td_FondoPausa, new Vector2(450,310), new Rectangle(0,0, 500, 200), Color.White);
                        batch.Draw(td_FondoPausa, new Vector2(450, 310), new Rectangle(0, 0, 500, 200), Color.White);
                        batch.DrawString(fuente, "¿Desea Comprar el Estado?", new Vector2(555, 350), Color.White);
                        btn_si.Draw(batch);
                        btn_no.Draw(batch);
                        EstadoJugando = "MostrarMensajeEstado";   
                    }
                    if (ColocarHotel == true)
                    {
                        batch.Draw(td_FondoPausa, new Vector2(450, 310), new Rectangle(0, 0, 500, 200), Color.White);
                        batch.Draw(td_FondoPausa, new Vector2(450, 310), new Rectangle(0, 0, 500, 200), Color.White);
                        batch.DrawString(fuente, "¿Desea colocar Hotel en el estado?", new Vector2(515, 350), Color.White);
                        btn_si.Draw(batch);
                        btn_no.Draw(batch);
                        EstadoJugando = "MensajeColocarHotel";
                    }
                    if (EstadoJugando == "MuestraPregunta")
                    {
                        batch.Draw(td_FondoPausa, new Vector2(330, 210), new Rectangle(0, 0, 750, 400), Color.White);
                        batch.Draw(td_FondoPausa, new Vector2(330, 210), new Rectangle(0, 0, 750, 400), Color.White);
                        if (modojugador == "solo")
                        {
                            double tiempo = TiempoMaximo - Cronometro;
                            int cantdigito = 0;
                            string espacio = "";
                            Color colordigito = Color.White;
                            if (tiempo < 10)
                            {
                                cantdigito = 1;
                                espacio = "0";
                                if (tiempo < 6)
                                {
                                    colordigito = Color.Yellow;
                                }
                            }
                            else
                            {
                                cantdigito = 2;
                            }
                            batch.DrawString(FuenteTiempo, "TIEMPO RESTANTE : " + " " + espacio + tiempo.ToString().Substring(0, cantdigito), new Vector2(389, 240), colordigito);
                        }
                        if (modojugador == "equipo")
                        {
                            double tiempo = TiempoMaximoEquipo - Cronometro;
                            int cantdigito = 0;
                            string espacio = "";
                            Color colordigito = Color.White;
                            if (tiempo < 10)
                            {
                                cantdigito = 1;
                                espacio = "0";
                                if (tiempo < 6)
                                {
                                    colordigito = Color.Yellow;
                                }
                            }
                            else
                            {
                                cantdigito = 2;
                            }
                            batch.DrawString(FuenteTiempo, "TIEMPO RESTANTE : " + "  " + espacio + tiempo.ToString().Substring(0, cantdigito), new Vector2(389, 240), colordigito);
                        }
                        batch.DrawString(fuente, parseText(StringPregunta), new Vector2(350, 340), Color.White);
                        guimanager.Draw(batch);
                        if (modojugador == "solo")
                        {
                            btnPreguntarEquipo.Draw(batch);
                        }
                        else { }
                        btn_Contestar.Draw(batch);
                        btn_penlizar.Draw(batch);
                       
                    }
                    if (modoestado == "aviso")
                    {
                        if (cronometroParpadeo > tiempoParpadeo)
                        {
                            cronometroParpadeo = 0;
                            if (colortemp != Color.White)
                            {
                                colortemp = Color.White;
                            }
                            else
                            {
                                colortemp = coloraviso;
                            }
                        }
                        batch.Draw(Img_Aviso, new Rectangle(210, 370, 960, 290), Color.White);
                        batch.Draw(Img_Aviso, new Rectangle(210, 370, 960, 290), Color.White);
                        batch.Draw(Img_Aviso, new Rectangle(210, 370, 960, 290), Color.White);
                        batch.DrawString(fuenteaviso, str_aviso, new Vector2(400, 400), colortemp);
                        batch.DrawString(fuenteaviso1, str_aviso2, new Vector2(450, 450), colortemp);
                    }
                }
                Vector3 mod = Vector3.Zero;
                foreach (ModelMesh mesh in ModeloDado.Meshes)
                {
                    foreach (BasicEffect effect in mesh.Effects)
                    {
                        effect.EnableDefaultLighting();
                        if (TiempoMover <= 365 && tirardado == true)
                        {
                            //effect.World = Matrix.CreateFromYawPitchRoll(angle, angle, angle);
                            if (TiempoMover < 203)
                            {
                                if (TiempoMover == 119 && NumCaidoDado == 2)
                                {
                                    tirardado = false;
                                    TiempoMover = 0;
                                    AvanzarEquipo = true;
                                }
                                if (TiempoMover == 158 && NumCaidoDado == 1)
                                {
                                    TiempoMover = 0;
                                    tirardado = false;
                                    AvanzarEquipo = true;
                                }
                                if (TiempoMover == 198 && NumCaidoDado == 4)
                                {
                                    tirardado = false;
                                    TiempoMover = 0;
                                    AvanzarEquipo = true;
                                }
                                effect.World = Matrix.CreateRotationX(angle);
                            }
                            else
                            {
                                if (TiempoMover == 236 && NumCaidoDado == 5)
                                {
                                    tirardado = false;
                                    TiempoMover = 0;
                                    AvanzarEquipo = true;
                                }
                                if (TiempoMover == 276 && NumCaidoDado == 6)
                                {
                                    tirardado = false;
                                    TiempoMover = 0;
                                    AvanzarEquipo = true;
                                }
                                if (TiempoMover == 354 && NumCaidoDado == 3)
                                {
                                    tirardado = false;
                                    TiempoMover = 0;
                                    AvanzarEquipo = true;
                                }
                                effect.World = Matrix.CreateRotationY(angle);
                            }
                        }
                        effect.View = Matrix.CreateLookAt(new Vector3(0.0f, 0.0f, 5000.0f), Vector3.Zero, Vector3.Up);
                        effect.Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(0.1f), aspectRatio, 1, 100000);
                    }
                    mesh.Draw();
                }
                if (EstadoJugando == "finalizar_Juego")
                {
                    if (MuestraTabla == false)
                    {
                        batch.Draw(td_FondoPausa, new Rectangle(0, 0, ga.Window.ClientBounds.Width, ga.Window.ClientBounds.Height), Color.White);
                        batch.Draw(td_FondoPausa, new Rectangle(0, 0, ga.Window.ClientBounds.Width, ga.Window.ClientBounds.Height), Color.White);
                        batch.DrawString(fuente, "Estados Comprados", new Vector2(900, 60), Color.Orange);
                        batch.DrawString(fuente, "Prec.  Nom.", new Vector2(1000, 90), Color.White);
                        batch.DrawString(fuente, "Equipo", new Vector2(680, 260), Color.Orange);
                        batch.DrawString(fuente, "Banco", new Vector2(290, 260), Color.Orange);
                        batch.Draw(banco, new Vector2(250, 270), Microsoft.Xna.Framework.Color.White);
                        batch.Draw(equipos[ActualEquipo], new Rectangle(680, 300, 90, 150), Color.White);
                        batch.DrawString(fuente, "Fondo Actual : $" + Equipo[ActualEquipo].Fondo, new Vector2(650, 480), Color.White);
                        if (cEstados != null)
                        {
                            foreach (DibujaEstados eq in cEstados)
                            {
                                eq.Draw(batch);
                            }
                        }
                    }
                    else
                    {
                        ContadorPagaHoteles++;
                        batch.Draw(td_FondoPausa, new Rectangle(0, 0, ga.Window.ClientBounds.Width, ga.Window.ClientBounds.Height), Color.White);
                        batch.Draw(td_FondoPausa, new Rectangle(0, 0, ga.Window.ClientBounds.Width, ga.Window.ClientBounds.Height), Color.White);
                        batch.DrawString(fuetepausa, "Juego Terminado", new Vector2(550, 130), Color.Orange);
                        btn_cerrar.Draw(batch);
                        equiposganadores = ListaGanadores();
                        equiposperdedores = ListaPerdedores();
                        if (ContadorPagaHoteles == 1)
                        {
                            BancoCompraHotelDeLosEquipos();
                        }

                        int PosY = 200;
                        batch.DrawString(fuente, "Posicion", new Vector2(350, PosY), Color.White);
                        batch.DrawString(fuente, "Equipo", new Vector2(500, PosY), Color.White);
                        batch.DrawString(fuente, "Fondo", new Vector2(820, PosY), Color.White);
                        batch.DrawString(fuente, "Vueltas", new Vector2(950, PosY), Color.White);
                        PosY += 40;
                        for (int x = 0; x < equiposganadores.Length; x++)
                        {
                            batch.Draw(td_barra, new Rectangle(350, PosY, 680, 40), Color.White);
                            batch.DrawString(fuenteaviso1, "1", new Vector2(370, PosY + 4), Color.Orange);
                            batch.DrawString(fuenteaviso1, "" + Equipo[Int32.Parse(equiposganadores[x])].nombreequipo, new Vector2(480, PosY + 4), Color.Orange);
                            batch.DrawString(fuenteaviso1, "" + Equipo[Int32.Parse(equiposganadores[x])].Fondo, new Vector2(820, PosY + 4), Color.Orange);
                            batch.DrawString(fuenteaviso1, "" + Equipo[Int32.Parse(equiposganadores[x])].NumeroVueltas, new Vector2(950, PosY + 4), Color.Orange);
                            PosY += 50;
                        }
                        if (equiposperdedores.Length > 0)
                        {
                            for (int x = 0; x < equiposperdedores.Length; x++)
                            {
                                batch.Draw(td_barra, new Rectangle(350, PosY, 680, 40), Color.White);
                                batch.DrawString(fuenteaviso1, "" + (x + 2), new Vector2(370, PosY + 4), Color.Orange);
                                batch.DrawString(fuenteaviso1, "" + Equipo[Int32.Parse(equiposperdedores[x])].nombreequipo, new Vector2(480, PosY + 4), Color.Orange);
                                batch.DrawString(fuenteaviso1, "" + Equipo[Int32.Parse(equiposperdedores[x])].Fondo, new Vector2(820, PosY + 4), Color.Orange);
                                batch.DrawString(fuenteaviso1, "" + Equipo[Int32.Parse(equiposperdedores[x])].NumeroVueltas, new Vector2(950, PosY + 4), Color.Orange);
                                PosY += 50;
                            }
                        }
                    }
                }
                if (VerTabla == true)
                {
                    VerTabla = false;
                    batch.Draw(td_FondoPausa, new Rectangle(0, 80, ga.Window.ClientBounds.Width, ga.Window.ClientBounds.Height), Color.White);
                    batch.Draw(td_FondoPausa, new Rectangle(0, 80, ga.Window.ClientBounds.Width, ga.Window.ClientBounds.Height), Color.White);
                    equiposganadores = ListaGanadores();
                    equiposperdedores = ListaPerdedores();

                    int PosY = 200;
                    batch.DrawString(fuente, "Posicion", new Vector2(350, PosY), Color.White);
                    batch.DrawString(fuente, "Equipo", new Vector2(500, PosY), Color.White);
                    batch.DrawString(fuente, "Fondo", new Vector2(820, PosY), Color.White);
                    batch.DrawString(fuente, "Vueltas", new Vector2(950, PosY), Color.White);
                    PosY += 40;
                    for (int x = 0; x < equiposganadores.Length; x++)
                    {
                        batch.Draw(td_barra, new Rectangle(350, PosY, 680, 40), Color.White);
                        batch.DrawString(fuenteaviso1, "1", new Vector2(370, PosY + 4), Color.Orange);
                        batch.DrawString(fuenteaviso1, "" + Equipo[Int32.Parse(equiposganadores[x])].nombreequipo, new Vector2(480, PosY), Color.Orange);
                        batch.DrawString(fuenteaviso1, "" + Equipo[Int32.Parse(equiposganadores[x])].Fondo, new Vector2(820, PosY), Color.Orange);
                        batch.DrawString(fuenteaviso1, "" + Equipo[Int32.Parse(equiposganadores[x])].NumeroVueltas, new Vector2(950, PosY), Color.Orange);
                        PosY += 50;
                    }
                    if (equiposperdedores.Length > 0)
                    {
                        for (int x = 0; x < equiposperdedores.Length; x++)
                        {
                            batch.Draw(td_barra, new Rectangle(350, PosY, 680, 30), Color.White);
                            batch.DrawString(fuenteaviso1, "" + (x + 2), new Vector2(370, PosY + 4), Color.Orange);
                            batch.DrawString(fuenteaviso1, "" + Equipo[Int32.Parse(equiposperdedores[x])].nombreequipo, new Vector2(480, PosY), Color.Orange);
                            batch.DrawString(fuenteaviso1, "" + Equipo[Int32.Parse(equiposperdedores[x])].Fondo, new Vector2(820, PosY), Color.Orange);
                            batch.DrawString(fuenteaviso1, "" + Equipo[Int32.Parse(equiposperdedores[x])].NumeroVueltas, new Vector2(950, PosY), Color.Orange);
                            PosY += 50;
                        }
                    }
                }

            }
            switch (EstadoJuegoActual)
            {
                case EstadoJuego.Pausa:
                    batch.Draw(td_FondoPausa, rec_pausa, Color.White);
                    batch.Draw(td_FondoPausa, rec_pausa, Color.White);
                    batch.DrawString(fuetepausa, "Pausa", new Vector2(1000, 100), Color.Orange);
                    btn_ReanudarJuego.Draw(batch);
                    btn_Opciones.Draw(batch);
                    btn_Reiniciar.Draw(batch);
                    btn_Salir.Draw(batch);
                    break;
                case EstadoJuego.OpcionesJugando:
                    Opc_jugando.Draw(batch);
                    break;
            }
        }
        public void DrawBank(SpriteBatch batch)
        {
            if (banco != null)
            {
                //batch.DrawString(fuente, "Banco", new Vector2(950, 290), Color.Black);
                batch.Draw(banco, new Vector2(830, 300), Microsoft.Xna.Framework.Color.White);
                //batch.DrawString(fuente, "Capital : $" + FondoInicial, new Vector2(900, 500), Color.Black);
            }
        }
        public void DrawEstados(SpriteBatch batch)
        {
            est = Estados.Count();
            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    if (Suelo[i, j] == 1)
                    {
                        est--;
                        if (est >= 0)
                        {
                            pos[est, 0] = Convert.ToInt32(tileDimensions.X * j);
                            pos[est, 1] = Convert.ToInt32(tileDimensions.Y * i);
                            variable = new Var();
                            posImagen = pos;
                            batch.Draw(Estados[est], new Vector2(tileDimensions.X * j, tileDimensions.Y * i), Microsoft.Xna.Framework.Color.White);
                        }
                    }
                    else
                    {
                        if (Suelo[i, j] == 2)
                        {
                            batch.Draw(mexico, new Vector2(tileDimensions.X * j, tileDimensions.Y * i), Microsoft.Xna.Framework.Color.White);
                            PosEsquinas1[0, 0] = Convert.ToInt32(tileDimensions.X * j);
                            PosEsquinas1[0, 1] = Convert.ToInt32(tileDimensions.Y * i);
                            variable = new Var();
                            PosEsquina = PosEsquinas1;
                        }
                        else
                        {
                            if (Suelo[i, j] == 3)
                            {
                                batch.Draw(goo, new Vector2(tileDimensions.X * j, tileDimensions.Y * i), Microsoft.Xna.Framework.Color.White);
                                batch.DrawString(fuente, "superior", new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 13), Color.Black);
                                batch.DrawString(fuente, "Izquierda", new Vector2(tileDimensions.X * j + 8, tileDimensions.Y * i + 35), Color.Black);
                                PosEsquinas2[0, 0] = Convert.ToInt32(tileDimensions.X * j);
                                PosEsquinas2[0, 1] = Convert.ToInt32(tileDimensions.Y * i);
                                PosEsquina1 = PosEsquinas2;
                            }
                            else
                            {
                                if (Suelo[i, j] == 4)
                                {
                                    batch.Draw(colmexico, new Vector2(tileDimensions.X * j, tileDimensions.Y * i), Microsoft.Xna.Framework.Color.White);
                                    batch.DrawString(fuente, "Viajar", new Vector2(tileDimensions.X * j + 25, tileDimensions.Y * i + 13), Color.Black);
                                    batch.DrawString(fuente, "Mexico", new Vector2(tileDimensions.X * j + 24, tileDimensions.Y * i + 35), Color.Black);
                                    PosEsquinas3[0, 0] = Convert.ToInt32(tileDimensions.X * j);
                                    PosEsquinas3[0, 1] = Convert.ToInt32(tileDimensions.Y * i);
                                    PosEsquina2 = PosEsquinas3;
                                }
                                else
                                {
                                    if (Suelo[i, j] == 5)
                                    {
                                        batch.Draw(paga, new Vector2(tileDimensions.X * j, tileDimensions.Y * i), Microsoft.Xna.Framework.Color.White);
                                        batch.DrawString(fuente, "Pagar", new Vector2(tileDimensions.X * j + 25, tileDimensions.Y * i + 13), Color.Black);
                                        batch.DrawString(fuente, "Banco", new Vector2(tileDimensions.X * j + 24, tileDimensions.Y * i + 35), Color.Black);
                                        PosEsquinas4[0, 0] = Convert.ToInt32(tileDimensions.X * j);
                                        PosEsquinas4[0, 1] = Convert.ToInt32(tileDimensions.Y * i);
                                        PosEsquina3 = PosEsquinas4;
                                    }
                                }
                            }
                        }
                    }
                    if (Suelo[i, j] == 6)
                    {
                        if (activa == true)
                        {
                            if (EstadosVendidos[0, 1] == "Durango" && EstadosVendidos[0, 2] == "Vendido")
                            {
                                batch.DrawString(fuete11,"Prop:"+Equipo[int.Parse(EstadosVendidos[0,0])].nombreequipo, new Vector2(tileDimensions.X * j + 2, tileDimensions.Y * i + 130), Color.White);
                                batch.DrawString(fuete11, "Renta: $" + Double.Parse(cJugador[EstadoActualEquipo].NombreEstadoRe[0,1]) * 25 / 100, new Vector2(tileDimensions.X * j + 15, tileDimensions.Y * i + 150), Color.White);
                            }
                            else
                            {
                                batch.DrawString(fuete11, "  Durango", new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 130), Color.Black);
                                batch.DrawString(fuete11, "Precio: $" + PreDurango, new Vector2(tileDimensions.X * j + 15, tileDimensions.Y * i + 150), Color.Black);
                            }
                        }
                        else
                        {
                            batch.DrawString(fuete11, "  Durango", new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 130), Color.Black);
                            batch.DrawString(fuete11, "Precio: $" + PreDurango, new Vector2(tileDimensions.X * j + 5, tileDimensions.Y * i + 150), Color.Black);
                        }
                    }
                    if (Suelo[i, j] == 7)
                    {
                        if (activa == true)
                        {
                            if (EstadosVendidos[1, 1] == "Colima" && EstadosVendidos[1, 2] == "Vendido")
                            {
                                batch.DrawString(fuete11,"Prop:"+Equipo[int.Parse(EstadosVendidos[1,0])].nombreequipo, new Vector2(tileDimensions.X * j +2, tileDimensions.Y * i + 130), Color.White);
                                batch.DrawString(fuete11, "Renta: $" + Double.Parse(cJugador[EstadoActualEquipo].NombreEstadoRe[1, 1]) * 25 / 100, new Vector2(tileDimensions.X * j + 15, tileDimensions.Y * i + 150), Color.White);
                            }
                            else
                            {
                                batch.DrawString(fuete11, "  Colima", new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 130), Color.Black);
                                batch.DrawString(fuete11, "Precio: $" + PreColima, new Vector2(tileDimensions.X * j + 15, tileDimensions.Y * i + 150), Color.Black);
                            }
                        }
                        else
                        {
                            batch.DrawString(fuete11, "  Colima", new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 130), Color.Black);
                            batch.DrawString(fuete11, "Precio: $" + PreColima, new Vector2(tileDimensions.X * j + 5, tileDimensions.Y * i + 150), Color.Black);
                        }
                    }
                    if (Suelo[i, j] == 8)
                    {
                        if (activa == true)
                        {
                            if (EstadosVendidos[2, 1] == "Coahuila" && EstadosVendidos[2, 2] == "Vendido")
                            {
                                batch.DrawString(fuete11,"Prop:"+Equipo[int.Parse(EstadosVendidos[2,0])].nombreequipo, new Vector2(tileDimensions.X * j + 2, tileDimensions.Y * i + 130), Color.White);
                                batch.DrawString(fuete11, "Renta: $" + Double.Parse(cJugador[EstadoActualEquipo].NombreEstadoRe[2, 1]) * 25 / 100, new Vector2(tileDimensions.X * j + 15, tileDimensions.Y * i + 150), Color.White);
                            }
                            else
                            {
                                batch.DrawString(fuete11, "  Coahuila", new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 130), Color.Black);
                                batch.DrawString(fuete11, "Precio: $" + PreCoahuila, new Vector2(tileDimensions.X * j + 5, tileDimensions.Y * i + 150), Color.Black);
                            }
                        }
                        else
                        {
                            batch.DrawString(fuete11, "  Coahuila", new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 130), Color.Black);
                            batch.DrawString(fuete11, "Precio: $" + PreCoahuila, new Vector2(tileDimensions.X * j + 5, tileDimensions.Y * i + 150), Color.Black);
                        }
                    }
                    if (Suelo[i, j] == 9)
                    {
                        if (activa == true)
                        {
                            if (EstadosVendidos[3, 1] == "Chihuahua" && EstadosVendidos[3, 2] == "Vendido")
                            {
                                batch.DrawString(fuete11,"Prop:"+Equipo[int.Parse(EstadosVendidos[3,0])].nombreequipo, new Vector2(tileDimensions.X * j + 2, tileDimensions.Y * i + 130), Color.White);
                                batch.DrawString(fuete11, "Renta: $" + Double.Parse(cJugador[EstadoActualEquipo].NombreEstadoRe[3, 1]) * 25 / 100, new Vector2(tileDimensions.X * j + 15, tileDimensions.Y * i + 150), Color.White);
                            }
                            else
                            {
                                batch.DrawString(fuete11, "  Chihuahua", new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 130), Color.Black);
                                batch.DrawString(fuete11, "Precio: $" + PreChihuahua, new Vector2(tileDimensions.X * j + 5, tileDimensions.Y * i + 150), Color.Black);
                            }
                        }
                        else
                        {
                            batch.DrawString(fuete11, "  Chihuahua", new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 130), Color.Black);
                            batch.DrawString(fuete11, "Precio: $" + PreChihuahua, new Vector2(tileDimensions.X * j + 5, tileDimensions.Y * i + 150), Color.Black);
                        }
                    }
                    if (Suelo[i, j] == 10)
                    {
                        if (activa == true)
                        {
                            if (EstadosVendidos[4, 1] == "Chiapas" && EstadosVendidos[4, 2] == "Vendido")
                            {
                                batch.DrawString(fuete11,"Prop:"+Equipo[int.Parse(EstadosVendidos[4,0])].nombreequipo, new Vector2(tileDimensions.X * j + 2, tileDimensions.Y * i + 130), Color.White);
                                batch.DrawString(fuete11, "Renta: $" + Double.Parse(cJugador[EstadoActualEquipo].NombreEstadoRe[4, 1]) * 25 / 100, new Vector2(tileDimensions.X * j + 15, tileDimensions.Y * i + 150), Color.White);
                            }
                            else
                            {
                                batch.DrawString(fuete11, "  Chiapas", new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 130), Color.Black);
                                batch.DrawString(fuete11, "Precio: $" + Prechiapas, new Vector2(tileDimensions.X * j + 5, tileDimensions.Y * i + 150), Color.Black);
                            }
                        }
                        else
                        {
                            batch.DrawString(fuete11, "  Chiapas", new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 130), Color.Black);
                            batch.DrawString(fuete11, "Precio: $" + Prechiapas, new Vector2(tileDimensions.X * j + 5, tileDimensions.Y * i + 150), Color.Black);
                        }
                    }
                    if (Suelo[i, j] == 11)
                    {
                        if (activa == true)
                        {
                            if (EstadosVendidos[5, 1] == "Campeche" && EstadosVendidos[5, 2] == "Vendido")
                            {
                                batch.DrawString(fuete11,"Prop:"+Equipo[int.Parse(EstadosVendidos[5,0])].nombreequipo, new Vector2(tileDimensions.X * j + 2, tileDimensions.Y * i + 130), Color.White);
                                batch.DrawString(fuete11, "Renta: $" + Double.Parse(cJugador[EstadoActualEquipo].NombreEstadoRe[5, 1]) * 25 / 100, new Vector2(tileDimensions.X * j + 15, tileDimensions.Y * i + 150), Color.White);
                            }
                            else
                            {
                                batch.DrawString(fuete11, "  Campeche", new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 130), Color.Black);
                                batch.DrawString(fuete11, "Precio: $" + PreCampeche, new Vector2(tileDimensions.X * j + 5, tileDimensions.Y * i + 150), Color.Black);
                            }
                        }
                        else
                        {
                            batch.DrawString(fuete11, "  Campeche", new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 130), Color.Black);
                            batch.DrawString(fuete11, "Precio: $" + PreCampeche, new Vector2(tileDimensions.X * j + 5, tileDimensions.Y * i + 150), Color.Black);
                        }
                    }
                    if (Suelo[i, j] == 12)
                    {
                        if (activa == true)
                        {
                            if (EstadosVendidos[6, 1] == "California Sur" && EstadosVendidos[6, 2] == "Vendido")
                            {
                                batch.DrawString(fuete11,"Prop:"+Equipo[int.Parse(EstadosVendidos[6,0])].nombreequipo, new Vector2(tileDimensions.X * j + 2, tileDimensions.Y * i + 130), Color.White);
                                batch.DrawString(fuete11, "Renta: $" + Double.Parse(cJugador[EstadoActualEquipo].NombreEstadoRe[6, 1]) * 25 / 100, new Vector2(tileDimensions.X * j + 15, tileDimensions.Y * i + 150), Color.White);
                            }
                            else
                            {
                                batch.DrawString(fuete11, " California Sur", new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 130), Color.Black);
                                batch.DrawString(fuete11, "Precio: $" + PreCaliforSur, new Vector2(tileDimensions.X * j + 5, tileDimensions.Y * i + 150), Color.Black);
                            }
                        }
                        else
                        {
                            batch.DrawString(fuete11, " California Sur", new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 130), Color.Black);
                            batch.DrawString(fuete11, "Precio: $" + PreCaliforSur, new Vector2(tileDimensions.X * j + 5, tileDimensions.Y * i + 150), Color.Black);
                        }
                    }
                    if (Suelo[i, j] == 13)
                    {
                        if (activa == true)
                        {
                            if (EstadosVendidos[7, 1] == "B. California" && EstadosVendidos[7, 2] == "Vendido")
                            {
                                batch.DrawString(fuete11,"Prop:"+Equipo[int.Parse(EstadosVendidos[7,0])].nombreequipo, new Vector2(tileDimensions.X * j + 2, tileDimensions.Y * i + 130), Color.White);
                                batch.DrawString(fuete11, "Renta: $" + Double.Parse(cJugador[EstadoActualEquipo].NombreEstadoRe[7, 1]) * 25 / 100, new Vector2(tileDimensions.X * j + 15, tileDimensions.Y * i + 150), Color.White);
                            }
                            else
                            {
                                batch.DrawString(fuete11, " B. California", new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 130), Color.Black);
                                batch.DrawString(fuete11, "Precio: $" + PreCaliforni, new Vector2(tileDimensions.X * j + 5, tileDimensions.Y * i + 150), Color.Black);
                            }
                        }
                        else
                        {
                            batch.DrawString(fuete11, " B. California", new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 130), Color.Black);
                            batch.DrawString(fuete11, "Precio: $" + PreCaliforni, new Vector2(tileDimensions.X * j + 5, tileDimensions.Y * i + 150), Color.Black);
                        }
                    }
                    if (Suelo[i, j] == 14)
                    {
                        if (activa == true)
                        {
                            if (EstadosVendidos[8, 1] == "Aguascaliestes" && EstadosVendidos[8, 2] == "Vendido")
                            {
                                batch.DrawString(fuete11,"Prop:"+Equipo[int.Parse(EstadosVendidos[8,0])].nombreequipo, new Vector2(tileDimensions.X * j + 2, tileDimensions.Y * i + 130), Color.White);
                                batch.DrawString(fuete11, "Renta: $" + Double.Parse(cJugador[EstadoActualEquipo].NombreEstadoRe[8, 1]) * 25 / 100, new Vector2(tileDimensions.X * j + 15, tileDimensions.Y * i + 150), Color.White);
                            }
                            else
                            {
                                batch.DrawString(fuete11, "Aguascaliestes", new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 130), Color.Black);
                                batch.DrawString(fuete11, "Precio: $" + PreAguascali, new Vector2(tileDimensions.X * j + 5, tileDimensions.Y * i + 150), Color.Black);
                            }
                        }
                        else
                        {
                            batch.DrawString(fuete11, "Aguascaliestes", new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 130), Color.Black);
                            batch.DrawString(fuete11, "Precio: $" + PreAguascali, new Vector2(tileDimensions.X * j + 5, tileDimensions.Y * i + 150), Color.Black);
                        }
                    }
                    if (Suelo[i, j] == 15)
                    {
                        if (activa == true)
                        {
                            if (EstadosVendidos[10, 1] == "Edo. Mexico" && EstadosVendidos[10, 2] == "Vendido")
                            {
                                batch.DrawString(fuete11,"Prop:"+Equipo[int.Parse(EstadosVendidos[10,0])].nombreequipo, new Vector2(tileDimensions.X * j - 216, tileDimensions.Y * i + 10), Color.White);
                                batch.DrawString(fuete11, "Renta: $" + Double.Parse(cJugador[EstadoActualEquipo].NombreEstadoRe[10, 1]) * 25 / 100, new Vector2(tileDimensions.X * j - 215, tileDimensions.Y * i + 30), Color.White);
                            }
                            else
                            {
                                batch.DrawString(fuete11, "Edo. Mexico", new Vector2(tileDimensions.X * j - 215, tileDimensions.Y * i + 10), Color.Black);
                                batch.DrawString(fuete11, "Precio: $" + PreEdoMexico, new Vector2(tileDimensions.X * j -215, tileDimensions.Y * i + 30), Color.Black);
                            }
                        }
                        else
                        {
                            batch.DrawString(fuete11, "Edo. Mexico", new Vector2(tileDimensions.X * j - 215, tileDimensions.Y * i + 10), Color.Black);
                            batch.DrawString(fuete11, "Precio: $" + PreEdoMexico, new Vector2(tileDimensions.X * j - 215, tileDimensions.Y * i + 30), Color.Black);
                        }
                    }
                    if (Suelo[i, j] == 16)
                    {
                        if (activa == true)
                        {
                            if (EstadosVendidos[11, 1] == "Guerrero" && EstadosVendidos[11, 2] == "Vendido")
                            {
                                batch.DrawString(fuete11,"Prop:"+Equipo[int.Parse(EstadosVendidos[11,0])].nombreequipo, new Vector2(tileDimensions.X * j - 215, tileDimensions.Y * i + 10), Color.White);
                                batch.DrawString(fuete11, "Renta: $" + Double.Parse(cJugador[EstadoActualEquipo].NombreEstadoRe[11, 1]) * 25 / 100, new Vector2(tileDimensions.X * j - 215, tileDimensions.Y * i + 30), Color.White);
                            }
                            else
                            {
                                batch.DrawString(fuete11, "  Guerrero", new Vector2(tileDimensions.X * j - 215, tileDimensions.Y * i + 10), Color.Black);
                                batch.DrawString(fuete11, "Precio: $" + PreGuerrero, new Vector2(tileDimensions.X * j - 215, tileDimensions.Y * i + 30), Color.Black);
                            }
                        }
                        else
                        {
                            batch.DrawString(fuete11, "  Guerrero", new Vector2(tileDimensions.X * j - 215, tileDimensions.Y * i + 10), Color.Black);
                            batch.DrawString(fuete11, "Precio: $" + PreGuerrero, new Vector2(tileDimensions.X * j - 215, tileDimensions.Y * i + 30), Color.Black);
                        }
                    }
                    if (Suelo[i, j] == 17)
                    {
                        if (activa == true)
                        {
                            if (EstadosVendidos[12, 1] == "Jalisco" && EstadosVendidos[12, 2] == "Vendido")
                            {
                                batch.DrawString(fuete11,"Prop:"+Equipo[int.Parse(EstadosVendidos[12,0])].nombreequipo, new Vector2(tileDimensions.X * j - 215, tileDimensions.Y * i + 10), Color.White);
                                batch.DrawString(fuete11, "Renta: $" + Double.Parse(cJugador[EstadoActualEquipo].NombreEstadoRe[12, 1]) * 25 / 100, new Vector2(tileDimensions.X * j - 215, tileDimensions.Y * i + 30), Color.White);
                            }
                            else
                            {
                                batch.DrawString(fuete11, "  Jalisco", new Vector2(tileDimensions.X * j - 215, tileDimensions.Y * i + 10), Color.Black);
                                batch.DrawString(fuete11, "Precio: $" + PreJalisco, new Vector2(tileDimensions.X * j - 215, tileDimensions.Y * i + 30), Color.Black);
                            }
                        }
                        else
                        {
                            batch.DrawString(fuete11, "  Jalisco", new Vector2(tileDimensions.X * j - 215, tileDimensions.Y * i + 10), Color.Black);
                            batch.DrawString(fuete11, "Precio: $" + PreJalisco, new Vector2(tileDimensions.X * j - 215, tileDimensions.Y * i + 30), Color.Black);
                        }
                    }
                    if (Suelo[i, j] == 18)
                    {
                        if (activa == true)
                        {
                            if (EstadosVendidos[13, 1] == "Morelos" && EstadosVendidos[13, 2] == "Vendido")
                            {
                                batch.DrawString(fuete11,"Prop:"+Equipo[int.Parse(EstadosVendidos[13,0])].nombreequipo, new Vector2(tileDimensions.X * j - 215, tileDimensions.Y * i + 10), Color.White);
                                batch.DrawString(fuete11, "Renta: $" + Double.Parse(cJugador[EstadoActualEquipo].NombreEstadoRe[13, 1]) * 25 / 100, new Vector2(tileDimensions.X * j - 215, tileDimensions.Y * i + 30), Color.White);
                            }
                            else
                            {
                                batch.DrawString(fuete11, "  Morelos", new Vector2(tileDimensions.X * j - 215, tileDimensions.Y * i + 10), Color.Black);
                                batch.DrawString(fuete11, "Precio: $" + PreMorelos, new Vector2(tileDimensions.X * j - 215, tileDimensions.Y * i + 30), Color.Black);
                            }
                        }
                        else
                        {
                            batch.DrawString(fuete11, "  Morelos", new Vector2(tileDimensions.X * j - 215, tileDimensions.Y * i + 10), Color.Black);
                            batch.DrawString(fuete11, "Precio: $" + PreMorelos, new Vector2(tileDimensions.X * j - 215, tileDimensions.Y * i + 30), Color.Black);
                        }
                    }
                    if (Suelo[i, j] == 19)
                    {
                        if (activa == true)
                        {
                            if (EstadosVendidos[14, 1] == "Nuevo Leon" && EstadosVendidos[14, 2] == "Vendido")
                            {
                                batch.DrawString(fuete11,"Prop:"+Equipo[int.Parse(EstadosVendidos[14,0])].nombreequipo, new Vector2(tileDimensions.X * j - 215, tileDimensions.Y * i + 10), Color.White);
                                batch.DrawString(fuete11, "Renta: $" + Double.Parse(cJugador[EstadoActualEquipo].NombreEstadoRe[14, 1]) * 25 / 100, new Vector2(tileDimensions.X * j - 215, tileDimensions.Y * i + 30), Color.White);
                            }
                            else
                            {
                                batch.DrawString(fuete11, " Nuevo Leon", new Vector2(tileDimensions.X * j - 215, tileDimensions.Y * i + 10), Color.Black);
                                batch.DrawString(fuete11, "Precio: $" + PreNuevoL, new Vector2(tileDimensions.X * j -215, tileDimensions.Y * i + 30), Color.Black);
                            }
                        }
                        else
                        {
                            batch.DrawString(fuete11, " Nuevo Leon", new Vector2(tileDimensions.X * j - 215, tileDimensions.Y * i + 10), Color.Black);
                            batch.DrawString(fuete11, "Precio: $" + PreNuevoL, new Vector2(tileDimensions.X * j - 215, tileDimensions.Y * i + 30), Color.Black);
                        }
                    }
                    if (Suelo[i, j] == 20)
                    {
                        if (activa == true)
                        {
                            if (EstadosVendidos[15, 1] == "Puebla" && EstadosVendidos[15, 2] == "Vendido")
                            {
                                batch.DrawString(fuete11,"Prop:"+Equipo[int.Parse(EstadosVendidos[15,0])].nombreequipo, new Vector2(tileDimensions.X * j - 215, tileDimensions.Y * i + 10), Color.White);
                                batch.DrawString(fuete11, "Renta: $" + Double.Parse(cJugador[EstadoActualEquipo].NombreEstadoRe[15, 1]) * 25 / 100, new Vector2(tileDimensions.X * j - 215, tileDimensions.Y * i + 30), Color.White);
                            }
                            else
                            {
                                batch.DrawString(fuete11, "  Puebla", new Vector2(tileDimensions.X * j - 215, tileDimensions.Y * i + 10), Color.Black);
                                batch.DrawString(fuete11, "Precio: $" + PrePuebla, new Vector2(tileDimensions.X * j - 215, tileDimensions.Y * i + 30), Color.Black);
                            }
                        }
                        else
                        {
                            batch.DrawString(fuete11, "  Puebla", new Vector2(tileDimensions.X * j - 215, tileDimensions.Y * i + 10), Color.Black);
                            batch.DrawString(fuete11, "Precio: $" + PrePuebla, new Vector2(tileDimensions.X * j - 215, tileDimensions.Y * i + 30), Color.Black);
                        }
                    }
                    if (Suelo[i, j] == 21)
                    {
                        if (activa == true)
                        {
                            if (EstadosVendidos[16, 1] == "Quintanarro" && EstadosVendidos[16, 2] == "Vendido")
                            {
                                batch.DrawString(fuete11,"Prop:"+Equipo[int.Parse(EstadosVendidos[16,0])].nombreequipo, new Vector2(tileDimensions.X * j - 215, tileDimensions.Y * i + 10), Color.White);
                                batch.DrawString(fuete11, "Renta: $" + Double.Parse(cJugador[EstadoActualEquipo].NombreEstadoRe[16, 1]) * 25 / 100, new Vector2(tileDimensions.X * j - 215, tileDimensions.Y * i + 30), Color.White);
                            }
                            else
                            {
                                batch.DrawString(fuete11, " Quintanarro", new Vector2(tileDimensions.X * j - 215, tileDimensions.Y * i + 10), Color.Black);
                                batch.DrawString(fuete11, "Precio: $" + PreQuintanaro, new Vector2(tileDimensions.X * j - 215, tileDimensions.Y * i + 30), Color.Black);
                            }
                        }
                        else
                        {
                            batch.DrawString(fuete11, " Quintanarro", new Vector2(tileDimensions.X * j - 215, tileDimensions.Y * i + 10), Color.Black);
                            batch.DrawString(fuete11, "Precio: $" + PreQuintanaro, new Vector2(tileDimensions.X * j - 215, tileDimensions.Y * i + 30), Color.Black);
                        }
                    }
                    if (Suelo[i, j] == 22)
                    {
                        if (activa == true)
                        {
                            if (EstadosVendidos[18, 1] == "Sinaloa" && EstadosVendidos[18, 2] == "Vendido")
                            {
                                batch.DrawString(fuete11,"Prop:"+Equipo[int.Parse(EstadosVendidos[18,0])].nombreequipo, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i - 110), Color.White);
                                batch.DrawString(fuete11, "Renta: $" + Double.Parse(cJugador[EstadoActualEquipo].NombreEstadoRe[18, 1]) * 25 / 100, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i - 90), Color.White);
                            }
                            else
                            {
                                batch.DrawString(fuete11, " Sinaloa", new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i - 110), Color.Black);
                                batch.DrawString(fuete11, "Precio: $" + PreSinaloa, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i - 90), Color.Black);
                            }
                        }
                        else
                        {
                            batch.DrawString(fuete11, " Sinaloa", new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i - 110), Color.Black);
                            batch.DrawString(fuete11, "Precio: $" + PreSinaloa, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i - 90), Color.Black);
                        }
                    }
                    if (Suelo[i, j] == 23)
                    {
                        if (activa == true)
                        {
                            if (EstadosVendidos[19, 1] == "Sonora" && EstadosVendidos[19, 2] == "Vendido")
                            {
                                batch.DrawString(fuete11,"Prop:"+Equipo[int.Parse(EstadosVendidos[19,0])].nombreequipo, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i - 110), Color.White);
                                batch.DrawString(fuete11, "Renta: $" + Double.Parse(cJugador[EstadoActualEquipo].NombreEstadoRe[19, 1]) * 25 / 100, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i - 90), Color.White);
                            }
                            else
                            {
                                batch.DrawString(fuete11, "  Sonora", new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i - 110), Color.Black);
                                batch.DrawString(fuete11, "Precio: $" + PreSonora, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i - 90), Color.Black);
                            }
                        }
                        else
                        {
                            batch.DrawString(fuete11, "  Sonora", new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i - 110), Color.Black);
                            batch.DrawString(fuete11, "Precio: $" + PreSonora, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i - 90), Color.Black);
                        }
                    }
                    if (Suelo[i, j] == 24)
                    {
                        if (activa == true)
                        {
                            if (EstadosVendidos[20, 1] == "Tabasco" && EstadosVendidos[20, 2] == "Vendido")
                            {
                                batch.DrawString(fuete11,"Prop:"+Equipo[int.Parse(EstadosVendidos[20,0])].nombreequipo, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i - 110), Color.White);
                                batch.DrawString(fuete11, "Renta: $" + Double.Parse(cJugador[EstadoActualEquipo].NombreEstadoRe[20, 1]) * 25 / 100, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i - 90), Color.White);
                            }
                            else
                            {
                                batch.DrawString(fuete11, "  Tabasco", new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i - 110), Color.Black);
                                batch.DrawString(fuete11, "Precio: $" + PreTabasco, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i - 90), Color.Black);
                            }
                        }
                        else
                        {
                            batch.DrawString(fuete11, "  Tabasco", new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i - 110), Color.Black);
                            batch.DrawString(fuete11, "Precio: $" + PreTabasco, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i - 90), Color.Black);
                        }
                    }
                    if (Suelo[i, j] == 25)
                    {
                        if (activa == true)
                        {
                            if (EstadosVendidos[21, 1] == "Tamaulipas" && EstadosVendidos[21, 2] == "Vendido")
                            {
                                batch.DrawString(fuete11,"Prop:"+Equipo[int.Parse(EstadosVendidos[21,0])].nombreequipo, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i - 110), Color.White);
                                batch.DrawString(fuete11, "Renta: $" + Double.Parse(cJugador[EstadoActualEquipo].NombreEstadoRe[21, 1]) * 25 / 100, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i - 90), Color.White);
                            }
                            else
                            {
                                batch.DrawString(fuete11, "  Tamaulipas", new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i - 110), Color.Black);
                                batch.DrawString(fuete11, "Precio: $" + PreTamaul, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i - 90), Color.Black);
                            }
                        }
                        else
                        {
                            batch.DrawString(fuete11, "  Tamaulipas", new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i - 110), Color.Black);
                            batch.DrawString(fuete11, "Precio: $" + PreTamaul, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i - 90), Color.Black);
                        }
                    }
                    if (Suelo[i, j] == 26)
                    {
                        if (activa == true)
                        {
                            if (EstadosVendidos[22, 1] == "Tlaxcala" && EstadosVendidos[22, 2] == "Vendido")
                            {
                                batch.DrawString(fuete11,"Prop:"+Equipo[int.Parse(EstadosVendidos[22,0])].nombreequipo, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i - 110), Color.White);
                                batch.DrawString(fuete11, "Renta: $" + Double.Parse(cJugador[EstadoActualEquipo].NombreEstadoRe[22, 1]) * 25 / 100, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i - 90), Color.White);
                            }
                            else
                            {
                                batch.DrawString(fuete11, "  Tlaxcala", new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i - 110), Color.Black);
                                batch.DrawString(fuete11, "Precio: $" + PreTlaxcala, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i - 90), Color.Black);
                            }
                        }
                        else
                        {
                            batch.DrawString(fuete11, "  Tlaxcala", new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i - 110), Color.Black);
                            batch.DrawString(fuete11, "Precio: $" + PreTlaxcala, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i - 90), Color.Black);
                        }
                    }
                    if (Suelo[i, j] == 27)
                    {
                        if (activa == true)
                        {
                            if (EstadosVendidos[23, 1] == "Veracruz" && EstadosVendidos[23, 2] == "Vendido")
                            {
                                batch.DrawString(fuete11,"Prop:"+Equipo[int.Parse(EstadosVendidos[23,0])].nombreequipo, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i - 110), Color.White);
                                batch.DrawString(fuete11, "Renta: $" + Double.Parse(cJugador[EstadoActualEquipo].NombreEstadoRe[23, 1]) * 25 / 100, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i - 90), Color.White);
                            }
                            else
                            {
                                batch.DrawString(fuete11, "  Veracruz", new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i - 110), Color.Black);
                                batch.DrawString(fuete11, "Precio: $" + PreVeracruz, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i - 90), Color.Black);
                            }
                        }
                        else
                        {
                            batch.DrawString(fuete11, "  Veracruz", new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i - 110), Color.Black);
                            batch.DrawString(fuete11, "Precio: $" + PreVeracruz, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i - 90), Color.Black);
                        }
                    }
                    if (Suelo[i, j] == 28)
                    {
                        if (activa == true)
                        {
                            if (EstadosVendidos[24, 1] == "Yucatan" && EstadosVendidos[24, 2] == "Vendido")
                            {
                                batch.DrawString(fuete11,"Prop:"+Equipo[int.Parse(EstadosVendidos[24,0])].nombreequipo, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i - 110), Color.White);
                                batch.DrawString(fuete11, "Renta: $" + Double.Parse(cJugador[EstadoActualEquipo].NombreEstadoRe[24, 1]) * 25 / 100, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i - 90), Color.White);
                            }
                            else
                            {
                                batch.DrawString(fuete11, "  Yucatan", new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i - 110), Color.Black);
                                batch.DrawString(fuete11, "Precio: $" + PreYucatan, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i - 90), Color.Black);
                            }
                        }
                        else
                        {
                            batch.DrawString(fuete11, "  Yucatan", new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i - 110), Color.Black);
                            batch.DrawString(fuete11, "Precio: $" + PreYucatan, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i - 90), Color.Black);
                        }
                    }
                    if (Suelo[i, j] == 29)
                    {
                        if (activa == true)
                        {
                            if (EstadosVendidos[25, 1] == "Zacatecas" && EstadosVendidos[25, 2] == "Vendido")
                            {
                                batch.DrawString(fuete11,"Prop:"+Equipo[int.Parse(EstadosVendidos[25,0])].nombreequipo, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i - 110), Color.White);
                                batch.DrawString(fuete11, "Renta: $" + Double.Parse(cJugador[EstadoActualEquipo].NombreEstadoRe[25, 1]) * 25 / 100, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i - 90), Color.White);
                            }
                            else
                            {
                                batch.DrawString(fuete11, "  Zacatecas", new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i - 110), Color.Black);
                                batch.DrawString(fuete11, "Precio: $" + PreZacatecas, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i - 90), Color.Black);
                            }
                        }
                        else
                        {
                            batch.DrawString(fuete11, "  Zacatecas", new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i - 110), Color.Black);
                            batch.DrawString(fuete11, "Precio: $" + PreZacatecas, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i - 90), Color.Black);
                        }
                    }
                    if (Suelo[i, j] == 30)
                    {
                        if (activa == true)
                        {
                            if (EstadosVendidos[26, 1] == "Distrito" && EstadosVendidos[26, 2] == "Vendido")
                            {
                                batch.DrawString(fuete11,"Prop:"+Equipo[int.Parse(EstadosVendidos[26,0])].nombreequipo, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i - 110), Color.White);
                                batch.DrawString(fuete11, "Renta: $" + Double.Parse(cJugador[EstadoActualEquipo].NombreEstadoRe[26, 1]) * 25 / 100, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i - 90), Color.White);
                            }
                            else
                            {
                                batch.DrawString(fuete11, " Distrito", new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i - 110), Color.Black);
                                batch.DrawString(fuete11, "Precio: $" + PreDistrito, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i - 90), Color.Black);
                            }
                        }
                        else
                        {
                            batch.DrawString(fuete11, " Distrito", new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i - 110), Color.Black);
                            batch.DrawString(fuete11, "Precio: $" + PreDistrito, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i - 90), Color.Black);
                        }
                    }
                    if (Suelo[i, j] == 31)
                    {
                        if (activa == true)
                        {
                            if (EstadosVendidos[28, 1] == "San Luis" && EstadosVendidos[28, 2] == "Vendido")
                            {
                                batch.DrawString(fuete11,"Prop:"+Equipo[int.Parse(EstadosVendidos[28,0])].nombreequipo, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 10), Color.White);
                                batch.DrawString(fuete11, "Renta: $" + Double.Parse(cJugador[EstadoActualEquipo].NombreEstadoRe[28, 1]) * 25 / 100, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 30), Color.White);
                            }
                            else
                            {
                                batch.DrawString(fuete11, "San Luis ", new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 10), Color.Black);
                                batch.DrawString(fuete11, "Precio: $" + PreSanLuis, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 30), Color.Black);
                            }
                        }
                        else
                        {
                            batch.DrawString(fuete11, "San Luis ", new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 10), Color.Black);
                            batch.DrawString(fuete11, "Precio: $" + PreSanLuis, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 30), Color.Black);
                        }
                    }
                    if (Suelo[i, j] == 32)
                    {
                        if (activa == true)
                        {
                            if (EstadosVendidos[29, 1] == "Queretaro" && EstadosVendidos[29, 2] == "Vendido")
                            {
                                batch.DrawString(fuete11,"Prop:"+Equipo[int.Parse(EstadosVendidos[29,0])].nombreequipo, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 10), Color.White);
                                batch.DrawString(fuete11, "Renta: $" + Double.Parse(cJugador[EstadoActualEquipo].NombreEstadoRe[29, 1]) * 25 / 100, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 30), Color.White);
                            }
                            else
                            {
                                batch.DrawString(fuete11, "  Queretaro", new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 10), Color.Black);
                                batch.DrawString(fuete11, "Precio: $" + PreQueretaro, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 30), Color.Black);
                            }
                        }
                        else
                        {
                            batch.DrawString(fuete11, "  Queretaro", new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 10), Color.Black);
                            batch.DrawString(fuete11, "Precio: $" + PreQueretaro, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 30), Color.Black);
                        }
                    }
                    if (Suelo[i, j] == 33)
                    {
                        if (activa == true)
                        {
                            if (EstadosVendidos[30, 1] == "Oaxaca" && EstadosVendidos[30, 2] == "Vendido")
                            {
                                batch.DrawString(fuete11,"Prop:"+Equipo[int.Parse(EstadosVendidos[30,0])].nombreequipo, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 10), Color.White);
                                batch.DrawString(fuete11, "Renta: $" + Double.Parse(cJugador[EstadoActualEquipo].NombreEstadoRe[30, 1]) * 25 / 100, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 30), Color.White);
                            }
                            else
                            {
                                batch.DrawString(fuete11, "  Oaxaca", new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 10), Color.Black);
                                batch.DrawString(fuete11, "Precio: $" + PreOxaca, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 30), Color.Black);
                            }
                        }
                        else
                        {
                            batch.DrawString(fuete11, "  Oaxaca", new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 10), Color.Black);
                            batch.DrawString(fuete11, "Precio: $" + PreOxaca, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 30), Color.Black);
                        }
                    }
                    if (Suelo[i, j] == 34)
                    {
                        if (activa == true)
                        {
                            if (EstadosVendidos[31, 1] == "Nayarit" && EstadosVendidos[31, 2] == "Vendido")
                            {
                                batch.DrawString(fuete11,"Prop:"+Equipo[int.Parse(EstadosVendidos[31,0])].nombreequipo, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 10), Color.White);
                                batch.DrawString(fuete11, "Renta: $" + Double.Parse(cJugador[EstadoActualEquipo].NombreEstadoRe[31, 1]) * 25 / 100, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 30), Color.White);
                            }
                            else
                            {
                                batch.DrawString(fuete11, "  Nayarit", new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 10), Color.Black);
                                batch.DrawString(fuete11, "Precio: $" + PreNayarit, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 30), Color.Black);
                            }
                        }
                        else
                        {
                            batch.DrawString(fuete11, "  Nayarit", new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 10), Color.Black);
                            batch.DrawString(fuete11, "Precio: $" + PreNayarit, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 30), Color.Black);
                        }
                    }
                    if (Suelo[i, j] == 35)
                    {
                        if (activa == true)
                        {
                            if (EstadosVendidos[32, 1] == "Michoacan" && EstadosVendidos[32, 2] == "Vendido")
                            {
                                batch.DrawString(fuete11,"Prop:"+Equipo[int.Parse(EstadosVendidos[32,0])].nombreequipo, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 10), Color.White);
                                batch.DrawString(fuete11, "Renta: $" + Double.Parse(cJugador[EstadoActualEquipo].NombreEstadoRe[32, 1]) * 25 / 100, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 30), Color.White);
                            }
                            else
                            {
                                batch.DrawString(fuete11, "  Michoacan", new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 10), Color.Black);
                                batch.DrawString(fuete11, "Precio: $" + PreMichoacan, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 30), Color.Black);
                            }
                        }
                        else
                        {
                            batch.DrawString(fuete11, "  Michoacan", new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 10), Color.Black);
                            batch.DrawString(fuete11, "Precio: $" + PreMichoacan, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 30), Color.Black);
                        }
                    }
                    if (Suelo[i, j] == 36)
                    {
                        if (activa == true)
                        {
                            if (EstadosVendidos[33, 1] == "Hidalgo" && EstadosVendidos[33, 2] == "Vendido")
                            {
                                batch.DrawString(fuete11,"Prop:"+Equipo[int.Parse(EstadosVendidos[33,0])].nombreequipo, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 10), Color.White);
                                batch.DrawString(fuete11, "Renta: $" + Double.Parse(cJugador[EstadoActualEquipo].NombreEstadoRe[33, 1]) * 25 / 100, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 30), Color.White);
                            }
                            else
                            {
                                batch.DrawString(fuete11, "  Hidalgo", new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 10), Color.Black);
                                batch.DrawString(fuete11, "Precio: $" + PreHidalgo, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 30), Color.Black);
                            }
                        }
                        else
                        {
                            batch.DrawString(fuete11, "  Hidalgo", new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 10), Color.Black);
                            batch.DrawString(fuete11, "Precio: $" + PreHidalgo, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 30), Color.Black);
                        }
                    }
                    if (Suelo[i, j] == 37)
                    {
                        if (activa == true)
                        {
                            if (EstadosVendidos[34, 1] == "Guanajuato" && EstadosVendidos[34, 2] == "Vendido")
                            {
                                batch.DrawString(fuete11,"Prop:"+Equipo[int.Parse(EstadosVendidos[34,0])].nombreequipo, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 10), Color.White);
                                batch.DrawString(fuete11, "Renta: $" + Double.Parse(cJugador[EstadoActualEquipo].NombreEstadoRe[34, 1]) * 25 / 100, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 30), Color.White);
                            }
                            else
                            {
                                batch.DrawString(fuete11, "  Guanajuato", new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 10), Color.Black);
                                batch.DrawString(fuete11, "Precio: $" + PreGuanajuato, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 30), Color.Black);
                            }
                        }
                        else
                        {
                            batch.DrawString(fuete11, "  Guanajuato", new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 10), Color.Black);
                            batch.DrawString(fuete11, "Precio: $" + PreGuanajuato, new Vector2(tileDimensions.X * j + 10, tileDimensions.Y * i + 30), Color.Black);
                        }
                    }
                }
            }
        }
        int PosicionIndice = 0;
        public void MuestraPregunta()
        {
            PosicionIndice++;
            VentanaWindows.Controls.Clear();
            EstadoJugando = "MuestraPregunta";
            Random indice = new Random();
            if (PosicionIndice >= Pregun_Resp.Length / 8) {
                PosicionIndice = 0;
            }
            int indiceAleatorio = indice.Next(0,Pregun_Resp.Length/7);
            lbl_Pregunta = new Label(new Rectangle(350, 300, 500, 100), Pregun_Resp[PosicionIndice, 1], "lbl_Pregunta");
            StringPregunta = Pregun_Resp[PosicionIndice, 1];
            lbl_Pregunta.TextColor = Color.White;
            rb_Respuesta1 = new RadioButton(new Rectangle(350, 370, 20, 20), Pregun_Resp[PosicionIndice, 2], "rb_Respuesta1");
            rb_Respuesta1.TextColor = Color.White;
            rb_Respuesta2 = new RadioButton(new Rectangle(350, 400, 20, 20), Pregun_Resp[PosicionIndice, 3], "rb_Respuesta2");
            rb_Respuesta2.TextColor = Color.White;
            rb_Respuesta3 = new RadioButton(new Rectangle(350, 430, 20, 20), Pregun_Resp[PosicionIndice, 4], "rb_Respuesta3");
            rb_Respuesta3.TextColor = Color.White;
            rb_Respuesta4 = new RadioButton(new Rectangle(350, 460, 20, 20), Pregun_Resp[PosicionIndice, 5], "rb_Respuesta4");
            rb_Respuesta4.TextColor = Color.White;

            RespuestaCorrecta = Pregun_Resp[PosicionIndice, 6];

            VentanaWindows.Controls.Add(rb_Respuesta1);
            VentanaWindows.Controls.Add(rb_Respuesta2);
            VentanaWindows.Controls.Add(rb_Respuesta3);
            VentanaWindows.Controls.Add(rb_Respuesta4);
        }
        public int siguienteEqui(int val) {
            int actual = val;
            int v = 0;
            if (actual <= equipos.Count)
            {
                v = actual;
            }
            else {
                UltimoEquipo = true;
            }
            return v;
        }
        public bool UltimoEquipo =false;
        public void SiguienteEquipoAct()
        {
            if (ActualEquipo < Equipo.Length - 1)
            {
                ActualEquipo++;
            }
            else {
                UltimoEquipo = true;
            }
            for (int i = 0; i < Equipo.Length; i++)
            {
                if (i == ActualEquipo)
                {
                    Equipo[i].ActualEquipo = true;
                }
                else
                {
                    Equipo[i].ActualEquipo = false;
                }
            }

        }
        public int SiguienteEquipo(int val)
        {
            int actual = val;
            if (actual >= equipos.Count)
            {
                actual = 0;
            }
            return actual;
        }
        public void SiguienteEquipoActual() {
            EstadoActualEquipo++;
            if (EstadoActualEquipo >= Equipo.Length)
            {
                EstadoActualEquipo = 0;
            }
            for (int i = 0; i < Equipo.Length; i++)
            {
                if (i == EstadoActualEquipo)
                {
                    Equipo[i].ActualEquipo = true;
                }
                else
                {
                    Equipo[i].ActualEquipo = false;
                }
            }
        }
        public void SiguienteJugadro() {
            if (EstadoActualEquipo >= cJugador.Length) {
                EstadoActualEquipo = 0;
            }
            for (int i = 0; i < cJugador.Length; i++)
            {
                if (i == EstadoActualEquipo)
                {
                    cJugador[i].ActualJugador = true;
                }
                else
                {
                    cJugador[i].ActualJugador = false;
                }
            }
        }
        public string[] ListaGanadores()
        {
            string[] EquiposGanadores = null;
            int Maximofondo =Convert.ToInt32(Equipo[0].Fondo);
            for (int x = 0; x < Equipo.Length; x++) {
                if (Equipo[x].Fondo > Maximofondo) {
                    Maximofondo = Convert.ToInt32(Equipo[x].Fondo);
                }
            }
            string ganadores = "";
            for (int x = 0; x < Equipo.Length; x++) {
                if (Equipo[x].Fondo == Maximofondo) {
                    ganadores += x + ",";
                }
            }
            ganadores = ganadores.Substring(0, ganadores.Length - 1);
            EquiposGanadores = ganadores.Split(',');
            return EquiposGanadores;
        }
        public string[] ListaPerdedores()
        {
            string[] EquiposPerdedores = null;
            int Maximofondo = Convert.ToInt32(Equipo[0].Fondo);
            for (int x = 0; x < Equipo.Length; x++)
            {
                if (Equipo[x].Fondo > Maximofondo)
                {
                    Maximofondo = Convert.ToInt32(Equipo[x].Fondo);
                }
            }
            //sacar los equipos con menor dinero
            string perdedores = "";
            for (int x = 0; x < Equipo.Length; x++)
            {
                if (Equipo[x].Fondo < Maximofondo)
                {
                    perdedores += x + ",";
                }
            }
            if (perdedores != "")
            {
                perdedores = perdedores.Substring(0, perdedores.Length - 1);
                EquiposPerdedores = perdedores.Split(',');
                EquiposPerdedores = QuickSort(EquiposPerdedores, 0, EquiposPerdedores.Length - 1);
            }
            else {
                EquiposPerdedores = new string[0];
            }

            return EquiposPerdedores;
        }
        public string[] QuickSort(string[] ListaPerdedores, int primero, int ultimo)
        {
            int i, j, central;
            double pivote;
            central = (primero + ultimo) / 2;
            pivote = Convert.ToDouble(Equipo[Int32.Parse(ListaPerdedores[central])].Fondo);
            i = primero;
            j = ultimo;
            do
            {
                while (Convert.ToDouble(Equipo[Int32.Parse(ListaPerdedores[i])].Fondo) > pivote) i++;
                while (Convert.ToDouble(Equipo[Int32.Parse(ListaPerdedores[j])].Fondo) < pivote) j--;
                if (i <= j)
                {
                    int temp;
                    temp = Int32.Parse(ListaPerdedores[i]);
                    ListaPerdedores[i] = ListaPerdedores[j];
                    ListaPerdedores[j] = Convert.ToString(temp);
                    i++;
                    j--;
                }
            } while (i <= j);

            if (primero < j)
            {
                QuickSort(ListaPerdedores, primero, j);
            }
            if (i < ultimo)
            {
                QuickSort(ListaPerdedores, i, ultimo);
            }
            return ListaPerdedores;
        }
        public void BancoCompraHotelDeLosEquipos()
        {
            int estados = EstadosVendidos.Length / 3;
            for (int x = 0; x < estados; x++)
            {
                for (int y = 0; y < Equipo.Length; y++)
                {
                    if (Equipo[y].Indice == EstadosVendidos[x, 0] && ColacadosHoteles[x] == "ColocadoHotel")
                    {
                        Equipo[y].Fondo += 100 / 2;
                    }
                }
            }
        }
        private String parseText(String text)
        {
            String line = String.Empty;
            String returnString = String.Empty;
            String[] wordArray = text.Split(' ');

            foreach (String word in wordArray)
            {
                if (fuente.MeasureString(line + word).Length() > td_FondoPausa.Width -20)
                {
                    returnString = returnString + line + '\n';
                    line = String.Empty;
                }

                line = line + word + ' ';
            }

            return returnString + line;
        }
        public void Salir() {
            modoestado = "quitarmensaje";
            EstadoJugando = "Normal";
            cJugador[EstadoActualEquipo].MostrarMensajePregunta = false;
            EstadoActualEquipo = SiguienteEquipo(EstadoActualEquipo);
            SiguienteEquipoActual();
            vecesmuestra = 0;
            cronometroParpadeo = 0;
            cronometroAviso = 0;
            Cronometro = 0;
        }
        double cronometroAviso = 0, tiempoParpadeo = .3, cronometroParpadeo = 0;
        string str_aviso, str_aviso2,ModoAviso,Modoaccion;
        Color coloraviso, colortemp;
        public void avisos(string aviso, string aviso2,string accion, Color color, string modo)
        {
            str_aviso = aviso;
            str_aviso2 = aviso2; 
            coloraviso = color;
            colortemp = color;
            ModoAviso = modo;
            Modoaccion = accion;
            modoestado = "aviso";
            cronometroParpadeo = 0;
            cronometroAviso = 0;
        }
    }
}
