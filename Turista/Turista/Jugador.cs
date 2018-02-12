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
    class Jugador : Var
    {
        Texture2D Equipos,Avion;
        int[,] Tablero;
        public string Modojuagando = "PosicionInicio";
        int[,] PosicionEstados;
        int[,] PosEs;
        public bool ActualJugador = false, CompradoHotel = false;
        public int jugadorActual = 0;
        int CantidadEquipos;
        public int NumCaido = 0;
        int conn = 0;
        public int PosicionXOriginal = 0;
        public int PosicionYOriginal = 0, PosicionXavion = 1243, PosicionYavion = 120;
        public int PosicionX = 0;
        public int PosicionY = 0;
        public string ModoEstado = "";
        public bool MostrarMensaje = false,MostrarMensajePregunta= false,Estadovendido = false;
        public bool EstaCompradoEstado = false, MostrarAvion = false;
        int  VecesLanzado =0;
        public int[,] PosicionAsignados = new int[35, 2];
        public string[,] NombreEstadoRe = new string[35, 3];
        public Jugador(Game game,Texture2D a)
        {
            Avion = a;
        }
        public Jugador(int[,]NuevoTablero,int[,]NuevoPosicionEstados, int[,]PosicionEsquina1,Texture2D Equi,int cantEqui, int con) {
            Tablero = NuevoTablero;
            PosicionEstados = NuevoPosicionEstados;
            PosEs = PosicionEsquina1;
            Equipos = Equi;
            CantidadEquipos = cantEqui;
            AsignarPosiciones();
            conn = con;
            PosicionX = Convert.ToInt32(PosicionEsquina1[0,0] + conn);
            PosicionY = Convert.ToInt32(PosicionEsquina1[0,1]);
            PosicionXOriginal = PosicionX;
            PosicionYOriginal = PosicionY;
            NombreEstado();
        }
        public void Update(GameTime time)
        {
            if (avanza == true) {
                if (NumCaido != 18) {
                    if (PosicionX < (PosicionAsignados[NumCaido - 1, 0])) {
                        PosicionX += 36;
                    }
                    if (PosicionX > PosicionAsignados[NumCaido - 1, 0]) {
                        PosicionX -= 35;
                    }
                    if (PosicionY < PosicionAsignados[NumCaido - 1, 1]) {
                        PosicionY += 10;
                    }
                    if (PosicionY > PosicionAsignados[NumCaido - 1, 1]) {
                        PosicionY -= 10;
                    }
                }
            }
            if (IrEsquina == true) {
                if (PosicionX >= PosicionAsignados[27, 0] && PosicionY >= PosicionAsignados[27, 1]) {
                    PosicionX -= 36;
                    PosicionY -= 25;
                } else {
                    IrEsquina =false;
                }
            }
            if (ViajarMexico == true) {
                if (PosicionXavion > PosicionXOriginal && PosicionYavion < PosicionYOriginal) {
                    PosicionXavion -= 35;
                    PosicionYavion += 17;
                } else {
                    ViajarMexico = false;
                    PosicionXavion = 1243;
                    PosicionYavion = 130;
                    MostrarAvion = false;
                }
            }
        }
        public void Draw(SpriteBatch batch)
        {
            if (Modojuagando == "PosicionInicio") {
                batch.Draw(Equipos, new Rectangle(PosicionX, PosicionY, 40, 70), Color.White);
            }
            if (MostrarAvion == true) {
                batch.Draw(Avion, new Rectangle(PosicionXavion, PosicionYavion, 100, 80), Color.White);
            }
        }
        int valorMax = 35,val;
        public int  NumVueltas =0;
        public bool CaidoEsquina = false, MensajePagar = false, MensajePorPasarMexico = false, IrEsquina = false, IrEsquina1 = false, ViajarMexico = false;
        public bool Estado_suyo = false,avanza = false;
        public void AvanzaJugador(int valor)
        {
            VecesLanzado++;
            if (VecesLanzado == 1) {
                NumCaido = valor;
            } else {
                if (NumCaido + valor <= 35) {
                    NumCaido += valor;
                } else {
                    val = valorMax - NumCaido;
                    valor = valor - val;
                    NumCaido = valor;
                    MensajePorPasarMexico = true;
                    NumVueltas++;
                }
            }
            for (int f = 0; f < 11; f++) {
                for (int c = 0; c < 13; c++) {
                    if (Tablero[f, c] == NumCaido) {
                        if (NumCaido == 10 || NumCaido == 18) {
                            if (NumCaido == 10) {
                                PosicionX = PosicionAsignados[NumCaido -1, 0];
                                PosicionY = PosicionAsignados[NumCaido -1, 1];
                                NumCaido = 28;
                                CaidoEsquina = true;
                                IrEsquina = true;
                                MensajePagar = true;
                            }
                            if (NumCaido == 18) {
                                PosicionX = PosicionXOriginal;
                                PosicionY = PosicionYOriginal;
                                VecesLanzado = 0;
                                CaidoEsquina = true;
                                ViajarMexico = true;
                                MostrarAvion = true;
                            }
                        } else {
                            if (EstadosVendidos[NumCaido - 1, 2] != "Vendido") {
                                if (NumCaido == 28) {
                                    MostrarMensaje = false;
                                    MensajePagar = true;
                                } else {
                                    MostrarMensaje = true;
                                }
                            } else {
                                if (EstadosVendidos[NumCaido - 1, 2] == "Vendido" && int.Parse(EstadosVendidos[NumCaido - 1, 0]) == jugadorActual) {
                                    MostrarMensaje = false;
                                    MostrarMensajePregunta = false;
                                    Estado_suyo = true;
                                } else {
                                    MostrarMensaje = false;
                                    MostrarMensajePregunta = true;
                                }
                            }
                            avanza = true;
                        }
                    }
                }
            }
        }
        public void AsignarPosiciones()
        {
            PosicionAsignados[0, 0] = PosicionEstados[8, 0];
            PosicionAsignados[0, 1] = PosicionEstados[8, 1];
            PosicionAsignados[1, 0] = PosicionEstados[7, 0];
            PosicionAsignados[1, 1] = PosicionEstados[7, 1];
            PosicionAsignados[2, 0] = PosicionEstados[6, 0];
            PosicionAsignados[2, 1] = PosicionEstados[6, 1];
            PosicionAsignados[3 ,0] = PosicionEstados[5, 0];
            PosicionAsignados[3, 1] = PosicionEstados[5, 1];
            PosicionAsignados[4, 0] = PosicionEstados[4, 0];
            PosicionAsignados[4, 1] = PosicionEstados[4, 1];
            PosicionAsignados[5, 0] = PosicionEstados[3, 0];
            PosicionAsignados[5, 1] = PosicionEstados[3, 1];
            PosicionAsignados[6, 0] = PosicionEstados[2, 0];
            PosicionAsignados[6, 1] = PosicionEstados[2, 1];
            PosicionAsignados[7, 0] = PosicionEstados[1, 0];
            PosicionAsignados[7, 1] = PosicionEstados[1, 1];
            PosicionAsignados[8, 0] = PosicionEstados[0, 0];
            PosicionAsignados[8, 1] = PosicionEstados[0, 1];

            PosicionAsignados[9, 0] = PosEsquina1[0,0];
            PosicionAsignados[9, 1] = PosEsquina1[0,1];
            PosicionAsignados[10, 0] = PosicionEstados[9, 0];
            PosicionAsignados[10, 1] = PosicionEstados[9, 1];
            PosicionAsignados[11, 0] = PosicionEstados[11, 0];
            PosicionAsignados[11, 1] = PosicionEstados[11, 1];
            PosicionAsignados[12, 0] = PosicionEstados[13, 0];
            PosicionAsignados[12, 1] = PosicionEstados[13, 1];
            PosicionAsignados[13, 0] = PosicionEstados[15, 0];
            PosicionAsignados[13, 1] = PosicionEstados[15, 1];
            PosicionAsignados[14, 0] = PosicionEstados[17, 0];
            PosicionAsignados[14, 1] = PosicionEstados[17, 1];
            PosicionAsignados[15, 0] = PosicionEstados[19, 0];
            PosicionAsignados[15, 1] = PosicionEstados[19, 1];

            PosicionAsignados[16, 0] = PosicionEstados[21, 0];
            PosicionAsignados[16, 1] = PosicionEstados[21, 1];
            PosicionAsignados[17, 0] = PosEsquina2[0, 0];
            PosicionAsignados[17, 1] = PosEsquina2[0, 1];
            PosicionAsignados[18, 0] = PosicionEstados[23, 0];
            PosicionAsignados[18, 1] = PosicionEstados[23, 1];
            PosicionAsignados[19, 0] = PosicionEstados[24, 0];
            PosicionAsignados[19, 1] = PosicionEstados[24, 1];

            PosicionAsignados[20, 0] = PosicionEstados[25, 0];
            PosicionAsignados[20, 1] = PosicionEstados[25, 1];
            PosicionAsignados[21, 0] = PosicionEstados[26, 0];
            PosicionAsignados[21, 1] = PosicionEstados[26, 1];
            PosicionAsignados[22, 0] = PosicionEstados[27, 0];
            PosicionAsignados[22, 1] = PosicionEstados[27, 1];
            PosicionAsignados[23, 0] = PosicionEstados[28, 0];
            PosicionAsignados[23, 1] = PosicionEstados[28, 1];
            PosicionAsignados[24, 0] = PosicionEstados[29, 0];
            PosicionAsignados[24, 1] = PosicionEstados[29, 1];
            PosicionAsignados[25, 0] = PosicionEstados[30, 0];
            PosicionAsignados[25, 1] = PosicionEstados[30, 1];
            PosicionAsignados[26, 0] = PosicionEstados[31, 0];
            PosicionAsignados[26, 1] = PosicionEstados[31, 1];
            PosicionAsignados[27, 0] = PosEsquina3[0, 0];
            PosicionAsignados[27, 1] = PosEsquina3[0, 1];
            PosicionAsignados[28, 0] = PosicionEstados[22, 0];
            PosicionAsignados[28, 1] = PosicionEstados[22, 1];
            PosicionAsignados[29, 0] = PosicionEstados[20, 0];
            PosicionAsignados[29, 1] = PosicionEstados[20, 1];
            PosicionAsignados[30, 0] = PosicionEstados[18, 0];
            PosicionAsignados[30, 1] = PosicionEstados[18, 1];
            PosicionAsignados[31, 0] = PosicionEstados[16, 0];
            PosicionAsignados[31, 1] = PosicionEstados[16, 1];
            PosicionAsignados[32, 0] = PosicionEstados[14, 0];
            PosicionAsignados[32, 1] = PosicionEstados[14, 1];
            PosicionAsignados[33, 0] = PosicionEstados[12, 0];
            PosicionAsignados[33, 1] = PosicionEstados[12, 1];
            PosicionAsignados[34, 0] = PosicionEstados[10, 0];
            PosicionAsignados[34, 1] = PosicionEstados[10, 1];
            Posiciones = PosicionAsignados;
        }
        public void NombreEstado()
        {
            NombreEstadoRe[0, 0] = "Durango";
            NombreEstadoRe[0, 1] = "150";
            NombreEstadoRe[0, 2] = "09";
            NombreEstadoRe[1, 0] = "Colima";
            NombreEstadoRe[1, 1] = "200";
            NombreEstadoRe[1, 2] = "08";
            NombreEstadoRe[2, 0] = "Coahuila";
            NombreEstadoRe[2, 1] = "100";
            NombreEstadoRe[2, 2] = "07";
            NombreEstadoRe[3, 0] = "Chihuahua";
            NombreEstadoRe[3, 1] = "200";
            NombreEstadoRe[3, 2] = "06";
            NombreEstadoRe[4, 0] = "Chiapas";
            NombreEstadoRe[4, 1] = "250";
            NombreEstadoRe[4, 2] = "05";
            NombreEstadoRe[5, 0] = "Campeche";
            NombreEstadoRe[5, 1] = "200";
            NombreEstadoRe[5, 2] = "04";
            NombreEstadoRe[6, 0] = "California Sur";
            NombreEstadoRe[6, 1] = "250";
            NombreEstadoRe[6, 2] = "03";
            NombreEstadoRe[7, 0] = "B. California";
            NombreEstadoRe[7, 1] = "300";
            NombreEstadoRe[7, 2] = "02";
            NombreEstadoRe[8, 0] = "Aguascaliestes";
            NombreEstadoRe[8, 1] = "200";
            NombreEstadoRe[8, 2] = "01";
            NombreEstadoRe[10, 0] = "Edo. Mexico";
            NombreEstadoRe[10, 1] = "300";
            NombreEstadoRe[10, 2] = "010";
            NombreEstadoRe[11, 0] = "Guerrero";
            NombreEstadoRe[11, 1] = "150";
            NombreEstadoRe[11, 2] = "012";
            NombreEstadoRe[12, 0] = "Jalisco";
            NombreEstadoRe[12, 1] = "200";
            NombreEstadoRe[12, 2] = "014";
            NombreEstadoRe[13, 0] = "Morelos";
            NombreEstadoRe[13, 1] = "100";
            NombreEstadoRe[13, 2] = "016";
            NombreEstadoRe[14, 0] = "Nuevo Leon";
            NombreEstadoRe[14, 1] = "200";
            NombreEstadoRe[14, 2] = "018";
            NombreEstadoRe[15, 0] = "Puebla";
            NombreEstadoRe[15, 1] = "300";
            NombreEstadoRe[15, 2] = "020";
            NombreEstadoRe[16, 0] = "Quintanarro";
            NombreEstadoRe[16, 1] = "300";
            NombreEstadoRe[16, 2] = "022";
            NombreEstadoRe[18, 0] = "Sinaloa";
            NombreEstadoRe[18, 1] = "250";
            NombreEstadoRe[18, 2] = "024";
            NombreEstadoRe[19, 0] = "Sonora";
            NombreEstadoRe[19, 1] = "300";
            NombreEstadoRe[19, 2] = "025";
            NombreEstadoRe[20, 0] = "Tabasco";
            NombreEstadoRe[20, 1] = "200";
            NombreEstadoRe[20, 2] = "026";
            NombreEstadoRe[21, 0] = "Tamaulipas";
            NombreEstadoRe[21, 1] = "150";
            NombreEstadoRe[21, 2] = "027";
            NombreEstadoRe[22, 0] = "Tlaxcala";
            NombreEstadoRe[22, 1] = "200";
            NombreEstadoRe[22, 2] = "028";
            NombreEstadoRe[23, 0] = "Veracruz";
            NombreEstadoRe[23, 1] = "250";
            NombreEstadoRe[23, 2] = "029";
            NombreEstadoRe[24, 0] = "Yucatan";
            NombreEstadoRe[24, 1] = "250";
            NombreEstadoRe[24, 2] = "030";
            NombreEstadoRe[25, 0] = "Zacatecas";
            NombreEstadoRe[25, 1] = "150";
            NombreEstadoRe[25, 2] = "031";
            NombreEstadoRe[26, 0] = "Distrito";
            NombreEstadoRe[26, 1] = "150";
            NombreEstadoRe[26, 2] = "032";
            NombreEstadoRe[28, 0] = "San Luis";
            NombreEstadoRe[28, 1] = "200";
            NombreEstadoRe[28, 2] = "023";
            NombreEstadoRe[29, 0] = "Queretaro";
            NombreEstadoRe[29, 1] = "200";
            NombreEstadoRe[29, 2] = "021";
            NombreEstadoRe[30, 0] = "Oaxaca";
            NombreEstadoRe[30, 1] = "100";
            NombreEstadoRe[30, 2] = "019";
            NombreEstadoRe[31, 0] = "Nayarit";
            NombreEstadoRe[31, 1] = "150";
            NombreEstadoRe[31, 2] = "017";
            NombreEstadoRe[32, 0] = "Michoacan";
            NombreEstadoRe[32, 1] = "150";
            NombreEstadoRe[32, 2] = "015";
            NombreEstadoRe[33, 0] = "Hidalgo";
            NombreEstadoRe[33, 1] = "100";
            NombreEstadoRe[33, 2] = "013";
            NombreEstadoRe[34, 0] = "Guanajuato";
            NombreEstadoRe[34, 1] = "250";
            NombreEstadoRe[34, 2] = "011";
        }
    }
}
