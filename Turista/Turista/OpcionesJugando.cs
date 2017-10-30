using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RamGecXNAControls;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;

namespace Turista
{
    class OpcionesJugando
    {
        GUIManager guimanager;
        Window VentanaWindos;
        DibujaEquipo[] Equipos;
        SpriteFont fuente;
        Game game;
        public Botones btn_modificar, btn_cancelar,btn_penalizacion;
        Texture2D t2d_fondo;
        public int Equipo_Actual;
        string[] NomEquipos, FondoEquipos;
        public OpcionesJugando(Game g, DibujaEquipo[] new_equipos, int equipo_actual)
        {
            game = g;
            Equipos = new_equipos;
            Equipo_Actual = equipo_actual;
            NomEquipos = new string[Equipos.Length];
            FondoEquipos = new string[Equipos.Length];
            t2d_fondo = g.Content.Load<Texture2D>("Img/opaco");
            fuente = g.Content.Load<SpriteFont>("fuente");
            for (int con = 0; con < Equipos.Length; con++)
            {
                NomEquipos[con] = Equipos[con].nombreequipo;
                FondoEquipos[con] = Equipos[con].Fondo.ToString();
            }
            guimanager = new GUIManager(g, "Themes", "Default");
            VentanaWindos = new Window(new Rectangle(0, 80, 1000, 1000), "turista");

            VentanaWindos.Transparency = 0; VentanaWindos.Movable = false;
            guimanager.Controls.Add(VentanaWindos);
            GroupBox groupBoxEquipos = new GroupBox(new Rectangle(450, 210, 390, 250), "");
            groupBoxEquipos.Transparency = 0;
            VentanaWindos.Controls.Add(groupBoxEquipos);
            int posY = 15;
            for (int con = 0; con < Equipos.Length; con++)
            {
                TextBox txtNombreEquipo = new TextBox(new Rectangle(20, posY, 200, 24), Equipos[con].nombreequipo, "txt" + con);
                TextBox txtFondoEquipo = new TextBox(new Rectangle(250, posY, 100, 24), Convert.ToString(Equipos[con].Fondo), "txtF" + con);
                RadioButton RadioButton_Turno = new RadioButton(new Rectangle(400, posY + 2, 20, 20), "", "rdb" + con);
                RadioButton_Turno.Group = 10;
                if (con == Equipo_Actual)
                {
                    RadioButton_Turno.Checked = true;
                }
                else
                {
                    RadioButton_Turno.Checked = false;
                }
                txtNombreEquipo.OnTextChanged += (hola) =>
                {
                    int Numcaja = int.Parse(txtNombreEquipo.Name.Substring(3, 1));
                    if (txtNombreEquipo.Text.Length > 10)
                    {
                        txtNombreEquipo.Text = txtNombreEquipo.Text.Substring(0, 10);
                    }
                    NomEquipos[Numcaja] = txtNombreEquipo.Text;
                };
                txtFondoEquipo.OnTextChanged += (hola) =>
                {
                    int NumCaja = Convert.ToInt32(txtFondoEquipo.Name.Substring(4, 1));
                    FondoEquipos[NumCaja] = txtFondoEquipo.Text;
                };
                posY += 30;
                groupBoxEquipos.Controls.Add(RadioButton_Turno);
                groupBoxEquipos.Controls.Add(txtNombreEquipo);
                groupBoxEquipos.Controls.Add(txtFondoEquipo);
            }
            Label lblEquipos = new Label(new Rectangle(20, -5, 100, 30), "Equipos", "lblEquipos");
            Label lblFondos = new Label(new Rectangle(250, -5, 100, 30), "Fondos", "lblFondos");
            Label lblTurno = new Label(new Rectangle(390, -5, 100, 30), "Turno", "lblTurno");
            lblEquipos.TextColor = Color.White;
            lblFondos.TextColor = Color.White;
            lblTurno.TextColor = Color.White;
            groupBoxEquipos.Controls.Add(lblEquipos);
            groupBoxEquipos.Controls.Add(lblFondos);
            groupBoxEquipos.Controls.Add(lblTurno);

            Label lblAviso = new Label(new Rectangle(20, posY + 50, 100, 30), "El Aviso Aqui", "lblaviso");
            lblAviso.TextColor = Color.Red;
            lblAviso.Visible = false;
            groupBoxEquipos.Controls.Add(lblAviso);

            btn_modificar = new Botones(game.Content.Load<Texture2D>("Img/btn_modificar"), game.Content.Load<SoundEffect>("Sounds/PasarMouse"), game.Content.Load<SoundEffect>("Sounds/sound_click"), game.GraphicsDevice);
            btn_modificar.setPosicion(new Vector2(500, posY + 305));
            btn_modificar.setPosicionRectanguloIsOver(new Vector2(500, posY + 303));
            btn_cancelar = new Botones(game.Content.Load<Texture2D>("Img/btn_Cancelar"), game.Content.Load<SoundEffect>("Sounds/PasarMouse"), game.Content.Load<SoundEffect>("Sounds/sound_click"), game.GraphicsDevice);
            btn_cancelar.setPosicion(new Vector2(700, posY + 305));
            btn_cancelar.setPosicionRectanguloIsOver(new Vector2(700, posY + 303));
        }
        public void Update(GameTime gt, MouseState mouseAct, MouseState mouseAnt, bool ventanaActiva)
        {
            guimanager.Update(gt);
            if (btn_modificar.isClicked == true)
            {
                Modificar();
                btn_modificar.isClicked = false;
                CambiosGuardados = true;
            }
            btn_modificar.Update(mouseAct, mouseAnt, ventanaActiva);
            btn_cancelar.Update(mouseAct, mouseAnt, ventanaActiva);
        }
        public void Draw(SpriteBatch batch)
        {
            batch.Draw(t2d_fondo, new Rectangle(430, 240, 490, 300), Color.White);
            batch.Draw(t2d_fondo, new Rectangle(430, 240, 490, 300), Color.White);
            batch.DrawString(fuente, "Opciones", new Vector2(620, 250), Color.Orange);
            btn_modificar.Draw(batch);
            btn_cancelar.Draw(batch);
            guimanager.Draw(batch);
        }
        public bool CambiosGuardados = false;
        public void Modificar()
        {
            bool HayUnPuntajeMal = false;
            string EquipoConPuntMal = "";
            for (int i = 0; i < FondoEquipos.Length; i++)
            {
                if (FondoEquipos[i] != null)
                {
                    int num;
                    bool sePuedeConvertir = int.TryParse(FondoEquipos[i], out num);
                    if (sePuedeConvertir)
                    {
                        Equipos[i].Fondo = num;
                    }
                    else
                    {
                        HayUnPuntajeMal = true;
                        EquipoConPuntMal = (VentanaWindos.GetControl("txt" + i) as TextBox).Text;
                        i = FondoEquipos.Length;
                    }
                }
            }

            if (HayUnPuntajeMal)
            {
                (VentanaWindos.GetControl("lblaviso") as Label).Text = "El equipo \"" + EquipoConPuntMal + "\" tiene un puntaje no válido!";
                (VentanaWindos.GetControl("lblaviso") as Label).Visible = true;
            }
            else
            {
                (VentanaWindos.GetControl("lblaviso") as Label).Visible = false;
            }
            for (int i = 0; i < NomEquipos.Length; i++)
            {
                Equipos[i].nombreequipo = NomEquipos[i];
                if ((VentanaWindos.GetControl("rdb" + i) as RadioButton).Checked == true)
                {
                    Equipo_Actual = i;
                }
            }
            for (int i = 0; i < Equipos.Length; i++)
            {
                if (i == Equipo_Actual)
                {
                    Equipos[i].ActualEquipo = true;
                }
                else
                {
                    Equipos[i].ActualEquipo = false;
                }
            }
        }
    }
}
