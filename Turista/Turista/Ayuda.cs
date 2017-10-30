using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using RamGecXNAControls;
using System.Configuration;

namespace Turista
{
    class Ayuda
    {
        Texture2D Fondo;
        List<Texture2D> Instrucciones = new List<Texture2D>();
        Game ga;
        SpriteFont fuenteTitulo,fuente;
        Botones btn_siguiente, btn_atras;
        SoundEffect sound_click, sound_pasmouse;
        int IndiceInstru = 0;
        public Ayuda(Game game)
        {
            Fondo = game.Content.Load<Texture2D>("Img/ImagenFondo");
            fuenteTitulo = game.Content.Load<SpriteFont>("fuenteGrande");
            fuente = game.Content.Load<SpriteFont>("fuente");
            sound_pasmouse = game.Content.Load<SoundEffect>("Sounds/PasarMouse");
            sound_click = game.Content.Load<SoundEffect>("Sounds/sound_click");
            ga = game;
            for (int x = 0; x < 6; x++)
            {
                Instrucciones.Add(game.Content.Load<Texture2D>("Img/Pres" + (x + 1)));
            }

            btn_siguiente = new Botones(game.Content.Load<Texture2D>("Img/btn_siguiente"), sound_pasmouse, sound_click, game.GraphicsDevice);
            btn_siguiente.setPosicion(new Vector2(320, 680));
            btn_siguiente.setPosicionRectanguloIsOver(new Vector2(320, 680));

            btn_atras = new Botones(game.Content.Load<Texture2D>("Img/btn_atras"), sound_pasmouse, sound_click, game.GraphicsDevice);
            btn_atras.setPosicion(new Vector2(500, 680));
            btn_atras.setPosicionRectanguloIsOver(new Vector2(500, 680));
        }
        public void Update(GameTime time, MouseState MouseAct, MouseState MouseAnt, bool ventanaAct)
        {
            if (btn_siguiente.isClicked == true)
            {
                btn_siguiente.isClicked = false;
                if (IndiceInstru < Instrucciones.Count -1) {
                    IndiceInstru++;
                }
            }
            if (btn_atras.isClicked == true)
            {
                btn_atras.isClicked = false;
                if (IndiceInstru > 0)
                {
                    IndiceInstru--;
                }
            }
            btn_siguiente.Update(MouseAct, MouseAnt, ventanaAct);
            btn_atras.Update(MouseAct, MouseAnt, ventanaAct);
        }
        public void Draw(SpriteBatch batch)
        {
            batch.Draw(Fondo, new Rectangle(0, 0, ga.Window.ClientBounds.Width, ga.Window.ClientBounds.Height), Color.White);
            batch.DrawString(fuenteTitulo, "INSTRUCCIONES", new Vector2(600, 90), Color.Orange);
            batch.Draw(Instrucciones[IndiceInstru], new Rectangle(300, 150, 800, 500), Color.White);
            btn_siguiente.Draw(batch);
            if (IndiceInstru > 0)
            {
                btn_atras.Draw(batch);
            }
        }
    }
}
