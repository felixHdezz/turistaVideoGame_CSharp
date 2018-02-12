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
using System.Configuration;

namespace Turista
{
    class Botones
    {
        Texture2D textura;
        Vector2 posicion;
        SoundEffect sound_Pasmouse, 
                    sound_Click;
        Rectangle rectanguloBoton, 
                  rectanguloIsOver;
        Color color = new Color(255, 255, 255, 255),
        colorSeleccionado = new Color(137, 144, 158),
        colorDeseleccionado = new Color(255, 255, 255, 255);
        public Vector2 tamanio;
        int veces = 0;
        public Botones(Texture2D text, SoundEffect sound, SoundEffect sound_click, GraphicsDevice grafics)
        {
            textura = text;
            sound_Pasmouse = sound;
            sound_Click = sound_click;
            tamanio = new Vector2(textura.Width, textura.Height);
        }

        public bool isClicked;
        public bool Forzar_isClicked, Reproducir = Convert.ToBoolean(ConfigurationManager.AppSettings["Sonido"]);
        public void Update(MouseState mouseAct, MouseState mouseAnt, bool ventanaActiva)
        {
            Rectangle RectanguloMouse = new Rectangle(mouseAct.X, mouseAct.Y, 1, 1);
            if (RectanguloMouse.Intersects(rectanguloIsOver)) {
                color = colorSeleccionado;
                veces = veces + 1;
                if (veces == 1 && Reproducir == true) {
                    sound_Pasmouse.Play();
                }
                if (mouseAct.LeftButton == ButtonState.Pressed && mouseAnt.LeftButton == ButtonState.Released && ventanaActiva) {
                    isClicked = true;
                    if (Reproducir == true){
                        sound_Click.Play();
                    }
                }
            } else {
                veces = 0;
                if (Forzar_isClicked) {
                    Forzar_isClicked = false;
                    isClicked = true;
                } else {
                    color = colorDeseleccionado;
                    isClicked = false;
                    Forzar_isClicked = false;
                }
            }
        }
        public void setPosicion(Vector2 newPosicion)
        {
            posicion = newPosicion;
            rectanguloBoton = new Rectangle((int)posicion.X, (int)posicion.Y, (int)tamanio.X, (int)tamanio.Y);
        }

        public void setPosicionRectanguloIsOver(Vector2 newPosicion)
        {
            rectanguloIsOver = new Rectangle((int)newPosicion.X, (int)newPosicion.Y, (int)tamanio.X, (int)tamanio.Y);
        }
        public void Draw(SpriteBatch batch)
        {
            batch.Draw(textura, rectanguloBoton, color);
        }
    }
}
