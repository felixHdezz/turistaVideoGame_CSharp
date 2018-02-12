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
using System.Configuration;

namespace Turista
{
    class Opciones
    {
        GUIManager guimanager;
        Window windows;
        SpriteFont fuete,
                   fuenteTitulo;
        SoundEffect sound_click, 
                    sound_pasmouse;
        Texture2D Resolucion, 
                  ModoVideo, 
                  Pausar,
                  Vertabla;
        public Botones btn_Resolucion, 
                       btn_ModoVideo, 
                       btn_sonido, 
                       btn_aplicar, 
                       btn_volver;
        public bool PantallaCompleta, volver = false, aplicar = false, AplicarSonido = false, AplicarIsFullScreen = false, Modificar = false;
        string[] Resoluciones = new string[3];
        string[] ModoPantalla = new string[2];
        string[] Sonido = new string[2];
        public int IndiceResolucion = 0, IndiceModoPantalla = 0, IndiceSonido = 0, Ancho = 0, Alto = 0;
        public Opciones(Game game, bool isfullscreen)
        {
            Resoluciones[0] = "1366 x 768";
            Resoluciones[1] = "1360 x 768";
            Resoluciones[2] = "1280 x 768";
            ModoPantalla[0] = "Pantalla Completa";
            ModoPantalla[1] = "Ventana";
            Sonido[0] = "Si";
            Sonido[1] = "No";
            PantallaCompleta = isfullscreen;
            if (PantallaCompleta == true) {
                IndiceModoPantalla = 0;
            } else {
                IndiceModoPantalla = 1;
            }
            if (Convert.ToBoolean(ConfigurationManager.AppSettings["Sonido"]) == true) {
                IndiceSonido = 0;
            } else {
                IndiceSonido = 1;
            }
            for (int x = 0; x < Resoluciones.Length; x++) {
                if (Convert.ToInt32(ConfigurationManager.AppSettings["AnchoPantalla"]) == Int32.Parse(Resoluciones[x].Substring(0, 4))) {
                    IndiceResolucion = x;
                }
            }
            sound_pasmouse = game.Content.Load<SoundEffect>("Sounds/PasarMouse");
            sound_click = game.Content.Load<SoundEffect>("Sounds/sound_click");
            fuete = game.Content.Load<SpriteFont>("fuente");
            fuenteTitulo = game.Content.Load<SpriteFont>("fuenteGrande");
            btn_Resolucion = new Botones(game.Content.Load<Texture2D>("Img/btn_resolucion"), sound_pasmouse, sound_click, game.GraphicsDevice);
            btn_Resolucion.setPosicion(new Vector2(300, 200));
            btn_Resolucion.setPosicionRectanguloIsOver(new Vector2(300, 200));
            btn_ModoVideo = new Botones(game.Content.Load<Texture2D>("Img/btn_modovideo"), sound_pasmouse, sound_click, game.GraphicsDevice);
            btn_ModoVideo.setPosicion(new Vector2(300, 250));
            btn_ModoVideo.setPosicionRectanguloIsOver(new Vector2(300, 250));
            btn_sonido = new Botones(game.Content.Load<Texture2D>("Img/btn_sonido"), sound_pasmouse, sound_click, game.GraphicsDevice);
            btn_sonido.setPosicion(new Vector2(300, 300));
            btn_sonido.setPosicionRectanguloIsOver(new Vector2(300, 300));

            btn_aplicar = new Botones(game.Content.Load<Texture2D>("Img/btn_aplicar"), sound_pasmouse, sound_click, game.GraphicsDevice);
            btn_aplicar.setPosicion(new Vector2(430,600));
            btn_aplicar.setPosicionRectanguloIsOver(new Vector2(430, 600));

            btn_volver = new Botones(game.Content.Load<Texture2D>("Img/btn_VolverOpciones"), sound_pasmouse, sound_click, game.GraphicsDevice);
            btn_volver.setPosicion(new Vector2(760, 600));
            btn_volver.setPosicionRectanguloIsOver(new Vector2(760, 600));

            Pausar = game.Content.Load<Texture2D>("Img/btn_pausar");
            Vertabla = game.Content.Load<Texture2D>("Img/btn_vertabla");
        }
        public void Update(GameTime time, MouseState MouseAct, MouseState MouseAnt, bool ventanaAct)
        {
            if (btn_Resolucion.isClicked == true) {
                btn_Resolucion.isClicked = false;
                if (IndiceResolucion < Resoluciones.Length - 1) {
                    IndiceResolucion++;
                } else {
                    IndiceResolucion = 0;
                }
            }
            if (btn_ModoVideo.isClicked == true) {
                btn_ModoVideo.isClicked = false;
                if (IndiceModoPantalla < ModoPantalla.Length - 1) {
                    IndiceModoPantalla++;
                } else {
                    IndiceModoPantalla = 0;
                }
            }
            if (btn_sonido.isClicked == true) {
                btn_sonido.isClicked = false;
                if (IndiceSonido < Sonido.Length - 1) {
                    IndiceSonido++;
                } else {
                    IndiceSonido = 0;
                }
            }
            if (Sonido[IndiceSonido] == "Si") {
                AplicarSonido = true;
            } else {
                AplicarSonido = false;
            }
            if (ModoPantalla[IndiceModoPantalla] == "Pantalla Completa"){
                AplicarIsFullScreen = true;
            } else {
                if (ModoPantalla[IndiceModoPantalla] == "Ventana") {
                    AplicarIsFullScreen = false;
                }
            }
            if (btn_volver.isClicked == true) {
                btn_volver.isClicked = false;
                volver = true;
            }
            if (btn_aplicar.isClicked == true) {
                VerificaSeleccion();
                Modificar = true;
            }
            btn_Resolucion.Update(MouseAct, MouseAnt, ventanaAct);
            btn_ModoVideo.Update(MouseAct, MouseAnt, ventanaAct);
            btn_sonido.Update(MouseAct, MouseAnt, ventanaAct);
            btn_aplicar.Update(MouseAct, MouseAnt, ventanaAct);
            btn_volver.Update(MouseAct, MouseAnt, ventanaAct);
        }
        public void VerificaSeleccion()
        {
            for (int x = 0; x < Resoluciones.Length; x++) {
                if (IndiceResolucion == x) {
                    Ancho = Convert.ToInt32(Resoluciones[x].Substring(0, 4));
                    Alto = Convert.ToInt32(Resoluciones[x].Substring(7, 3));
                }
            }
        }
        public void Draw(SpriteBatch batch) {
            batch.DrawString(fuenteTitulo, "OPCIONES", new Vector2(650, 90), Color.Orange);
            batch.DrawString(fuete, "Grafico", new Vector2(200, 150), Color.White);
            batch.DrawString(fuete, "Controles", new Vector2(200, 380), Color.White);
            btn_Resolucion.Draw(batch);
            btn_ModoVideo.Draw(batch);
            btn_sonido.Draw(batch);
            batch.DrawString(fuete, Resoluciones[IndiceResolucion], new Vector2(595, 205), Color.White);
            batch.DrawString(fuete, ModoPantalla[IndiceModoPantalla], new Vector2(595, 255), Color.White);
            batch.DrawString(fuete, Sonido[IndiceSonido], new Vector2(595, 305), Color.White);
            batch.Draw(Pausar, new Rectangle(300, 430, Pausar.Width, Pausar.Height),Color.White);
            batch.Draw(Vertabla, new Rectangle(300, 480, Vertabla.Width, Vertabla.Height), Color.White);
            batch.DrawString(fuete, "ESC", new Vector2(595, 435), Color.White);
            batch.DrawString(fuete, "TAB", new Vector2(595, 485), Color.White);
            btn_aplicar.Draw(batch);
            btn_volver.Draw(batch);
        }
    }
}
