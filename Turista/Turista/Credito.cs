using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Turista
{
    class Credito
    {
        enum estado
        {
            Inicio,
            Pausa
        }
        estado EstadodelCredito = new estado();
        Texture2D imagenfondo, td_fondopausa,logo_uthh,logo_tic;
        Game Game;
        SpriteFont fuenteTexto;
        SpriteFont fuentepausa;
        SoundEffect sound_clik, sound_pasmouse;
        public Botones btnReanudar, btnsalir;
        int xTexto = 420, yTexto = 780;
        int incY = 1;
        public bool termina = false;
        private bool pausa = false;
        public Credito(Game game, Texture2D fondo, SpriteFont fuente, SpriteFont fuentepaus, Texture2D pausa, SoundEffect sound, SoundEffect sound_clic)
        {
            Game = game;
            imagenfondo = fondo;
            fuenteTexto = fuente;
            td_fondopausa = pausa;
            fuentepausa = fuentepaus;
            sound_pasmouse = sound;
            sound_clik = sound_clic;

            logo_uthh = game.Content.Load<Texture2D>("Img/logo_uthh");
            logo_tic = game.Content.Load<Texture2D>("Img/logo_tic");

            btnReanudar = new Botones(game.Content.Load<Texture2D>("Img/btn_Reanudar"), sound_pasmouse, sound_clik, game.GraphicsDevice);
            btnReanudar.setPosicion(new Vector2(1000, 140 + 20));
            btnReanudar.setPosicionRectanguloIsOver(new Vector2(1000, 140 + 30));

            btnsalir = new Botones(game.Content.Load<Texture2D>("Img/btn_Salir"), sound_pasmouse, sound_clik, game.GraphicsDevice);
            btnsalir.setPosicion(new Vector2(1000, 170 + 40));
            btnsalir.setPosicionRectanguloIsOver(new Vector2(1000, 170 + 60));
        }
        public void Update(GameTime gameTime, MouseState MouseAct, MouseState MouseAnt, bool ventanaAct)
        {
            switch (EstadodelCredito)
            {
                case estado.Inicio:
                    if (pausa == false)
                    {
                        yTexto -= incY;
                        if (termina != true)
                        {
                            if ((xTexto < 100) || (yTexto > 520))
                                if ((yTexto < 500) || (xTexto > 560)) incY = +incY;
                        }
                        if (yTexto < - 800)
                        {
                            termina = true;
                        }
                    }
                    if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                    {
                        pausa = true;
                        sound_pasmouse.Play();
                        EstadodelCredito = estado.Pausa;
                    }
                    break;
                case estado.Pausa:
                    if (btnReanudar.isClicked == true)
                    {
                        pausa = false;
                        EstadodelCredito = estado.Inicio;
                    }
                    btnReanudar.Update(MouseAct, MouseAnt, ventanaAct);
                    btnsalir.Update(MouseAct, MouseAnt, ventanaAct);
                    break;
            }
        }
        public void Draw(SpriteBatch batch)
        {
            batch.Draw(imagenfondo, new Rectangle(0, 0, Game.Window.ClientBounds.Width, Game.Window.ClientBounds.Height), Color.White);
            batch.DrawString(fuenteTexto, "Turista Mexico: Viaja, invierte y gana", new Vector2(xTexto + 85, yTexto - 10), Color.WhiteSmoke);
            batch.Draw(logo_uthh, new Rectangle(xTexto + 100, yTexto + 40, 300, 200), Color.White);
            batch.DrawString(fuenteTexto, "Universidad tecnologica dela Huasteca Hidalguense", new Vector2(xTexto, yTexto + 260), Color.WhiteSmoke);
            batch.DrawString(fuenteTexto, "......................................................", new Vector2(xTexto - 20, yTexto + 290), Color.WhiteSmoke);
            batch.Draw(logo_tic, new Rectangle(xTexto + 100, yTexto + 320, 300, 200), Color.White);
            batch.DrawString(fuenteTexto, "Carrera:  ", new Vector2(xTexto, yTexto + 530), Color.WhiteSmoke);
            batch.DrawString(fuenteTexto, "               Tecnologias de la Informacion y Comunicacion", new Vector2(xTexto, yTexto + 550), Color.WhiteSmoke);
            batch.DrawString(fuenteTexto, "Coordinador del proyecto: ", new Vector2(xTexto, yTexto + 580), Color.WhiteSmoke);
            batch.DrawString(fuenteTexto, "               M.C. Rafael Martinez Casanova", new Vector2(xTexto, yTexto + 610), Color.WhiteSmoke);
            batch.DrawString(fuenteTexto, "Programador: ", new Vector2(xTexto, yTexto + 640), Color.WhiteSmoke);
            batch.DrawString(fuenteTexto, "               Felix Hernandez Hernandez", new Vector2(xTexto, yTexto + 660), Color.WhiteSmoke);
            batch.DrawString(fuenteTexto, "Diseñador:  ", new Vector2(xTexto, yTexto + 690), Color.WhiteSmoke);
            batch.DrawString(fuenteTexto, "               Felix Hernandez Hernandez", new Vector2(xTexto, yTexto + 710), Color.WhiteSmoke);
            switch (EstadodelCredito)
            {
                case estado.Pausa:
                    batch.Draw(td_fondopausa, new Rectangle(0, 0, Game.Window.ClientBounds.Width, Game.Window.ClientBounds.Height), Color.White);
                    batch.DrawString(fuentepausa, "Pausa", new Vector2(1000, 100), Color.Orange);
                    btnReanudar.Draw(batch);
                    btnsalir.Draw(batch);
                    break;
            }
        }
    }
}
