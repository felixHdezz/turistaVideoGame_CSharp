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
using System.Data.SQLite;

namespace Turista
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        enum EstadoJuego
        {
            MenuPrincipal,
            NuevoJuego,
            Jugando,
            Opciones,
            OpcionesJugando,
            Creditos,
            Ayuda,
            Salir
        }
        EstadoJuego EstadoDelJuegoActual = new EstadoJuego();
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D imagenfondo, avion;
        KeyboardState tecladoActual, tecladoAnterior;
        MouseState mouseActual, mouseAnterior;
        SpriteFont fuente;
        SpriteFont fuentegrande;
        Texture2D imgLogo;
        SoundEffect sound_click, sound_PasMouse;
        Rectangle recLogo;
        //saliendo
        Texture2D td_FondoMensaje, td_FondoJuego, td_texto, td_titulo;
        Rectangle rec_mensaje;
        Botones btn_Si, btn_No;

        Botones btnNuevoJuego, btnOpciones, btnCredito, btnAyuda, btnSalir, btnBasedatos;
        ConfigJuego OpcionJuego;
        Juego Jugar;
        Credito creditos;
        Opciones opciones;
        Ayuda ayuda;
        KeyboardState newState;
        KeyboardState oldState;
        List<Texture2D> estado = new List<Texture2D>();
        bool VentanaActiva;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Window.AllowUserResizing = true;
            //this.graphics.PreferredBackBufferWidth = 800;
            //this.graphics.PreferredBackBufferHeight = 600;
            Content.RootDirectory = "Content";
        }
        protected override void Initialize()
        {
            base.Initialize();
        }
        protected override void LoadContent()
        {
            this.graphics.PreferredBackBufferWidth = Convert.ToInt32(ConfigurationManager.AppSettings["AnchoPantalla"]);
            this.graphics.PreferredBackBufferHeight = Convert.ToInt32(ConfigurationManager.AppSettings["AltoPantalla"]);
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Services.AddService(typeof(SpriteBatch), spriteBatch);
            Services.AddService(typeof(ContentManager), Content);
            graphics.IsFullScreen = Convert.ToBoolean(ConfigurationManager.AppSettings["PantallaCompleta"]);
            graphics.ApplyChanges();
            IsMouseVisible = true;
            this.Window.Title = "Turista Mexico";
            imgLogo = Content.Load<Texture2D>("Img/Img_Mundo");
            recLogo = new Rectangle(0, 0, 600, 600);
            imagenfondo = Content.Load<Texture2D>("Img/ImagenFondo");
            avion = Content.Load<Texture2D>("Img/font2");
            fuentegrande = Content.Load<SpriteFont>("fuenteGrande");

            td_FondoMensaje = Content.Load<Texture2D>("Img/opaco");
            rec_mensaje = new Rectangle(0, 0, 450, 170);
            fuente = Content.Load<SpriteFont>("fuente");
            td_texto = Content.Load<Texture2D>("Img/Texto");
            td_titulo = Content.Load<Texture2D>("Img/Titulo");
            td_FondoJuego = Content.Load<Texture2D>("Img/img_pausa");
            try
            {
                sound_PasMouse = Content.Load<SoundEffect>("Sounds/PasarMouse");
                sound_click = Content.Load<SoundEffect>("Sounds/sound_click");
                btnNuevoJuego = new Botones(Content.Load<Texture2D>("Img/NuevoJuego"), sound_PasMouse, sound_click, graphics.GraphicsDevice);
                btnNuevoJuego.setPosicion(new Vector2(20, 300));
                btnNuevoJuego.setPosicionRectanguloIsOver(new Vector2(20, 300));

                btnOpciones = new Botones(Content.Load<Texture2D>("Img/Opciones"), sound_PasMouse, sound_click, graphics.GraphicsDevice);
                btnOpciones.setPosicion(new Vector2(20, 330 + 30));
                btnOpciones.setPosicionRectanguloIsOver(new Vector2(20, 325 + 30));

                btnBasedatos = new Botones(Content.Load<Texture2D>("Img/BaseDatos"), sound_PasMouse, sound_click, graphics.GraphicsDevice);
                btnBasedatos.setPosicion(new Vector2(20, 360 + 60));
                btnBasedatos.setPosicionRectanguloIsOver(new Vector2(20, 354 + 60));

                btnCredito = new Botones(Content.Load<Texture2D>("Img/Creditos"), sound_PasMouse, sound_click, graphics.GraphicsDevice);
                btnCredito.setPosicion(new Vector2(20, 390 + 90));
                btnCredito.setPosicionRectanguloIsOver(new Vector2(20, 378 + 90));

                btnAyuda = new Botones(Content.Load<Texture2D>("Img/Ayuda"), sound_PasMouse, sound_click, graphics.GraphicsDevice);
                btnAyuda.setPosicion(new Vector2(20, 420 + 120));
                btnAyuda.setPosicionRectanguloIsOver(new Vector2(20, 409 + 120));

                btnSalir = new Botones(Content.Load<Texture2D>("Img/Salir"), sound_PasMouse, sound_click, graphics.GraphicsDevice);
                btnSalir.setPosicion(new Vector2(20, 450 + 150));
                btnSalir.setPosicionRectanguloIsOver(new Vector2(20, 438 + 150));

                btn_Si = new Botones(Content.Load<Texture2D>("Img/btn_Si"), sound_PasMouse, sound_click, graphics.GraphicsDevice);
                btn_Si.setPosicion(new Vector2(520, 370));
                btn_Si.setPosicionRectanguloIsOver(new Vector2(470, 366));

                btn_No = new Botones(Content.Load<Texture2D>("Img/btn_No"), sound_PasMouse, sound_click, graphics.GraphicsDevice);
                btn_No.setPosicion(new Vector2(520, 415));
                btn_No.setPosicionRectanguloIsOver(new Vector2(470, 409));
            }
            catch
            {
                Environment.Exit(0);
            }
        }
        protected override void UnloadContent()
        {

        }
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exi
            VentanaActiva = this.IsActive;
            mouseActual = Mouse.GetState();
            tecladoActual = Keyboard.GetState();
            switch (EstadoDelJuegoActual)
            {
                case EstadoJuego.MenuPrincipal:

                    if (btnNuevoJuego.isClicked == true)
                    {
                        IrAlJuego();
                    }
                    if (btnOpciones.isClicked == true)
                    {
                        IrOpciones();
                    }
                    if (btnBasedatos.isClicked == true)
                    {
                        System.Diagnostics.Process p = new System.Diagnostics.Process();
                        p.StartInfo.FileName = "AdministradorBD.exe";
                        p.StartInfo.UseShellExecute = false;
                        p.StartInfo.RedirectStandardInput = true;
                        p.StartInfo.RedirectStandardOutput = true;
                        p.StartInfo.RedirectStandardError = true;
                        p.StartInfo.CreateNoWindow = true;
                        p.Start();
                        Exit();
                    }
                    if (btnCredito.isClicked == true)
                    {
                        IrCreditos();
                    }
                    if (btnAyuda.isClicked == true)
                    {
                        IrAyuda();
                    }
                    if (btnSalir.isClicked == true)
                    {
                        IrSalir();
                    }
                    btnNuevoJuego.Update(mouseActual, mouseAnterior, VentanaActiva);
                    btnOpciones.Update(mouseActual, mouseAnterior, VentanaActiva);
                    btnBasedatos.Update(mouseActual, mouseAnterior, VentanaActiva);
                    btnCredito.Update(mouseActual, mouseAnterior, VentanaActiva);
                    btnAyuda.Update(mouseActual, mouseAnterior, VentanaActiva);
                    btnSalir.Update(mouseActual, mouseAnterior, VentanaActiva);
                    break;
                case EstadoJuego.NuevoJuego:
                    if (tecladoActual.IsKeyDown(Keys.Escape) && tecladoAnterior.IsKeyUp(Keys.Escape))
                    {
                        IrMenuPrincipal();
                    }
                    if (OpcionJuego.CargarJuego == true)
                    {
                        IrJuego();

                    }
                    if (OpcionJuego.BtnRegresar.isClicked == true)
                    {
                        IrMenuPrincipal();
                    }
                    Jugar.Update(gameTime, mouseActual, mouseAnterior, VentanaActiva);
                    OpcionJuego.Update(gameTime, mouseActual, mouseAnterior, VentanaActiva);
                    break;
                case EstadoJuego.Jugando:
                    if (Jugar.btn_Salir.isClicked == true)
                    {
                        IrMenuPrincipal();
                        Jugar.btn_Salir.isClicked = false;
                    }
                    if (Jugar.btn_cerrar.isClicked == true)
                    {
                        IrMenuPrincipal();
                        Jugar.btn_cerrar.isClicked = false;
                    }
                    Jugar.Update(gameTime, mouseActual, mouseAnterior, VentanaActiva);
                    break;
                case EstadoJuego.Opciones:
                    opciones.Update(gameTime, mouseActual, mouseAnterior, VentanaActiva);
                    if (opciones.volver == true)
                    {
                        IrMenuPrincipal();
                        //btnOpciones.isClicked = false;
                    }
                    if (opciones.Modificar == true)
                    {
                        opciones.btn_aplicar.isClicked = false;
                        if (opciones.AplicarIsFullScreen != graphics.IsFullScreen) {
                            string valor = opciones.AplicarIsFullScreen.ToString();
                            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                            config.AppSettings.Settings.Remove("PantallaCompleta");
                            config.AppSettings.Settings.Add("PantallaCompleta", valor);
                            config.Save(ConfigurationSaveMode.Modified);

                            graphics.IsFullScreen = opciones.AplicarIsFullScreen;
                            graphics.ApplyChanges();
                        }
                        if (opciones.AplicarSonido != Convert.ToBoolean(ConfigurationManager.AppSettings["Sonido"])) {
                            string valor = opciones.AplicarSonido.ToString();
                            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                            config.AppSettings.Settings.Remove("Sonido");
                            config.AppSettings.Settings.Add("Sonido", valor);
                            config.Save(ConfigurationSaveMode.Modified);
                            btnNuevoJuego.Reproducir = opciones.AplicarSonido;

                        }
                        if (opciones.Ancho != Convert.ToInt32(ConfigurationManager.AppSettings["AnchoPantalla"]))
                        {
                            string valor = opciones.Ancho.ToString();
                            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                            config.AppSettings.Settings.Remove("AnchoPantalla");
                            config.AppSettings.Settings.Add("AnchoPantalla", valor);
                            config.Save(ConfigurationSaveMode.Modified);

                            graphics.PreferredBackBufferWidth = opciones.Ancho;

                        }
                        System.Diagnostics.Process p = new System.Diagnostics.Process();
                        p.StartInfo.FileName = "Turista.exe";
                        p.Start();
                        Exit();
                        IrMenuPrincipal();
                    }
                    break;
                case EstadoJuego.Creditos:
                    creditos.Update(gameTime, mouseActual, mouseAnterior, VentanaActiva);
                    if (creditos.btnsalir.isClicked == true)
                    {
                        IrMenuPrincipal();
                    }
                    if (creditos.termina == true)
                    {
                        creditos.termina = false;
                        IrMenuPrincipal();
                    }
                    break;
                case EstadoJuego.Ayuda:
                    if (tecladoActual.IsKeyDown(Keys.Escape) && tecladoAnterior.IsKeyUp(Keys.Escape))
                    {
                        IrMenuPrincipal();
                    }
                    ayuda.Update(gameTime,mouseActual,mouseAnterior,VentanaActiva);
                    break;
                case EstadoJuego.Salir:
                    if (btn_Si.isClicked == true)
                    {
                        Exit();
                    }
                    if (btn_No.isClicked == true)
                    {
                        IrMenuPrincipal();
                    }
                    btn_Si.Update(mouseActual, mouseAnterior, VentanaActiva);
                    btn_No.Update(mouseActual, mouseAnterior, VentanaActiva);
                    break;
            }
            mouseAnterior = mouseActual;
            tecladoAnterior = tecladoActual;
            base.Update(gameTime);
        }
        private bool verificarTeclado(Keys tecla)
        {
            return oldState.IsKeyDown(tecla) && newState.IsKeyUp(tecla);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            switch (EstadoDelJuegoActual)
            {
                case EstadoJuego.Salir:
                    spriteBatch.Draw(imagenfondo, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                    btnNuevoJuego.Draw(spriteBatch);
                    btnOpciones.Draw(spriteBatch);
                    btnBasedatos.Draw(spriteBatch);
                    btnCredito.Draw(spriteBatch);
                    btnAyuda.Draw(spriteBatch);
                    btnSalir.Draw(spriteBatch);
                    spriteBatch.Draw(imgLogo, new Vector2(500, 100), recLogo, Color.White, 0f, Vector2.Zero, 1.0f, SpriteEffects.None, .9f);
                    spriteBatch.Draw(td_titulo, new Vector2(475, 50), new Rectangle(0, 0, 600, 300), Color.White);
                    spriteBatch.Draw(avion, new Vector2(475, 70), new Rectangle(0, 0, 700, 400), Color.White, 0f, Vector2.Zero, 1.0f, SpriteEffects.None, .9f);
                    spriteBatch.Draw(td_FondoMensaje, new Vector2(465, 300), rec_mensaje, Color.White);
                    spriteBatch.Draw(td_texto, new Vector2(500, 320), new Rectangle(0, 0, td_texto.Width, td_texto.Height), Color.White);
                    btn_Si.Draw(spriteBatch);
                    btn_No.Draw(spriteBatch);
                    break;
                case EstadoJuego.MenuPrincipal:
                    spriteBatch.Draw(imagenfondo, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                    btnNuevoJuego.Draw(spriteBatch);
                    btnOpciones.Draw(spriteBatch);
                    btnBasedatos.Draw(spriteBatch);
                    btnCredito.Draw(spriteBatch);
                    btnAyuda.Draw(spriteBatch);
                    btnSalir.Draw(spriteBatch);
                    spriteBatch.Draw(imgLogo, new Vector2(500, 100), recLogo, Color.White, 0f, Vector2.Zero, 1.0f, SpriteEffects.None, .9f);
                    spriteBatch.Draw(td_titulo, new Vector2(475, 50), new Rectangle(0, 0, 600, 300), Color.White);
                    spriteBatch.Draw(avion, new Vector2(475, 70), new Rectangle(0, 0, 700, 400), Color.White, 0f, Vector2.Zero, 1.0f, SpriteEffects.None, .9f);
                    break;
                case EstadoJuego.NuevoJuego:
                    spriteBatch.End();
                    spriteBatch.Begin();
                    Jugar.Draw(spriteBatch);
                    OpcionJuego.Draw(spriteBatch);
                    break;
                case EstadoJuego.Jugando:
                    Jugar.Draw(spriteBatch);
                    break;
                case EstadoJuego.OpcionesJugando:
                    //Opc_jugando.Draw(spriteBatch);
                    break;
                case EstadoJuego.Opciones:
                    spriteBatch.Draw(imagenfondo, new Rectangle(0, 0, Window.ClientBounds.Width, Window.ClientBounds.Height), Color.White);
                    opciones.Draw(spriteBatch);
                    break;
                case EstadoJuego.Creditos:
                    creditos.Draw(spriteBatch);
                    break;
                case EstadoJuego.Ayuda:
                    ayuda.Draw(spriteBatch);
                    break;
            }
            base.Draw(gameTime);
            spriteBatch.End();
        }
        public void IrMenuPrincipal()
        {
            EstadoDelJuegoActual = EstadoJuego.MenuPrincipal;
        }
        public void IrOpciones()
        {
            opciones = new Opciones(this, graphics.IsFullScreen);
            btnOpciones.isClicked = false;
            EstadoDelJuegoActual = EstadoJuego.Opciones;
        }
        public void IrCreditos()
        {
            creditos = new Credito(this, imagenfondo, fuente, fuentegrande, td_FondoMensaje, sound_PasMouse, sound_click);
            EstadoDelJuegoActual = EstadoJuego.Creditos;
            btnCredito.isClicked = false;
        }
        public void IrAyuda()
        {
            ayuda = new Ayuda(this);
            EstadoDelJuegoActual = EstadoJuego.Ayuda;
            btnAyuda.isClicked = false;
        }
        public void IrAlJuego()
        {
            Jugar = new Juego(this, sound_PasMouse, sound_click);
            OpcionJuego = new ConfigJuego(this, sound_PasMouse, sound_click);
            EstadoDelJuegoActual = EstadoJuego.NuevoJuego;
            btnNuevoJuego.isClicked = false;
        }
        public void IrJuego()
        {
            Jugar = new Juego(this, OpcionJuego.ArrayEquipos, OpcionJuego.temaSeleccionado, OpcionJuego.idTema_Seleccionado, OpcionJuego.ArrayPreguntas_Respuestas, sound_PasMouse, sound_click, fuentegrande);
            EstadoDelJuegoActual = EstadoJuego.Jugando;
        }
        public void IrSalir()
        {
            EstadoDelJuegoActual = EstadoJuego.Salir;
        }
        public void IrOpcionJuego()
        {
            OpcionJuego = new ConfigJuego(this, sound_PasMouse, sound_click);
            EstadoDelJuegoActual = EstadoJuego.NuevoJuego;
            btnNuevoJuego.isClicked = false;
        }
    }
}
