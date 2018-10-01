using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Printing;
using System.Runtime.InteropServices;
using Ticket;

namespace capaDatos
{
    public class clsCrearTicket
    {
        StringBuilder linea = new StringBuilder();
        int maxCar = 40, contar;

        public string lineasGuio()
        {
            string lineasGuion = "";
            for (int i = 0; i < maxCar; i++)
            {
                lineasGuion += "-";
            }
            return linea.AppendLine(lineasGuion).ToString();
        }
        public string lineasAsteriscos()
        {
            string lineasAsterisco = "";
            for (int i = 0; i < maxCar; i++)
            {
                lineasAsterisco += "*";
            }
            return linea.AppendLine(lineasAsterisco).ToString();
        }
        public string lineasIgual()
        {
            string lineasIgual = "";
            for (int i = 0; i < maxCar; i++)
            {
                lineasIgual += "=";
            }
            return linea.AppendLine(lineasIgual).ToString();
        }
        public void Ecabezado()
        {
            linea.AppendLine("Producto      |  Cant | Precio  |  Total");
        }
        public void TextoIzquierda(string texto)
        {
            if (texto.Length > maxCar)
            {
                int caracterActual = 0;
                for (int l = texto.Length; l > maxCar; l -= maxCar)
                {
                    linea.AppendLine(texto.Substring(caracterActual, maxCar));
                    caracterActual += maxCar;
                }
                linea.AppendLine(texto.Substring(caracterActual, texto.Length - caracterActual));
            }
            else
            {
                linea.AppendLine(texto);
            }
        }
        public void TextoDerecha(string texto)
        {
            if (texto.Length > maxCar)
            {
                int caracterActual = 0;
                for (int l = texto.Length; l > maxCar; l -= maxCar)
                {
                    linea.AppendLine(texto.Substring(caracterActual, maxCar));
                    caracterActual += maxCar;
                }

                string espacio = "";
                for (int i = 0; i < (maxCar - texto.Substring(caracterActual, texto.Length - caracterActual).Length); i++)
                {
                    espacio += " ";
                }
                linea.AppendLine(espacio + texto.Substring(caracterActual, texto.Length - caracterActual));
            }
            else
            {
                string espacios = "";
                for (int i = 0; i < (maxCar - texto.Length); i++)
                {
                    espacios += " ";
                }
                linea.AppendLine(espacios + texto);
            }
        }

        public void Textocentro(string texto)
        {
            if (texto.Length > maxCar)
            {
                int caracterActual = 0;
                for (int l = texto.Length; l > maxCar; l -= maxCar)
                {
                    linea.AppendLine(texto.Substring(caracterActual, maxCar));
                    caracterActual += maxCar;
                }

                string espacio = "";
                int centrar = (maxCar - texto.Substring(caracterActual, texto.Length - caracterActual).Length) / 2;
                for (int i = 0; i < centrar; i++)
                {
                    espacio += " ";
                }
                linea.AppendLine(espacio + texto.Substring(caracterActual, texto.Length - caracterActual));
            }
            else
            {
                string espacio = "";
                int centrar = (maxCar - texto.Length) / 2;
                for (int i = 0; i < centrar; i++)
                {
                    espacio += " ";
                }
                linea.AppendLine(espacio + texto);
            }
        }
        public void textoExtremos(string textIzquierdo, string textoDerecho)
        {
            string textIzq, textoDer, textCompleto = "", espacio = "";
            if (textIzquierdo.Length > 18)
            {
                contar = textIzquierdo.Length - 18;
                textIzq = textIzquierdo.Remove(18, contar);
            }
            else
            {
                textIzq = textIzquierdo;
            }
            textCompleto = textIzq;

            if (textoDerecho.Length > 14)
            {
                contar = textoDerecho.Length - 14;
                textoDer = textoDerecho.Remove(14, contar);
            }
            else
            {
                textoDer = textoDerecho;
            }

            int nroEspacios = maxCar - (textIzq.Length + textoDer.Length);
            for (int i = 0; i < nroEspacios; i++)
            {
                espacio += " ";
            }
            textCompleto += espacio + textoDerecho;
            linea.AppendLine(textCompleto);
        }
        public void AgregarTotales(string texto, decimal total)
        {
            string resumen, valor, textoCompleto, espacios = "";
            if (texto.Length > 25)
            {
                contar = texto.Length - 25;
                resumen = texto.Remove(25, contar);
            }
            else
            {
                resumen = texto;
            }
            textoCompleto = resumen;
            valor = total.ToString("#,#.00");

            int nroEspacios = maxCar - (resumen.Length + valor.Length);

            for (int i = 0; i < nroEspacios; i++)
            {
                espacios += " ";
            }
            textoCompleto += espacios + valor;
            linea.AppendLine(textoCompleto);
        }

        public void AgregarArticulo(decimal cant, string espacios1, string nombre, string espacios2, decimal precio, string espacios3, decimal total)
        {
            if (cant.ToString().Length <= 4 && precio.ToString().Length <= 6 && total.ToString().Length <= 7)
            {
                string elemento = "", espacios = "";
                bool bandera = false;
                int nroEspacios = 0;

                if (nombre.Length > 16)
                {
                    nroEspacios = (4 - cant.ToString().Length);
                    espacios = "  ";
                    for (int i = 0; i < nroEspacios; i++)
                    {
                        espacios += "  ";
                    }
                    elemento += espacios + cant.ToString() + " x ";

                    nroEspacios = (5 - precio.ToString().Length);
                    espacios = "   ";
                    for (int i = 0; i < nroEspacios; i++)
                    {
                        espacios += "   ";
                    }
                    elemento += espacios + "$" + precio.ToString();

                    nroEspacios = (6 - precio.ToString().Length);
                    espacios = "";
                    for (int i = 0; i < nroEspacios; i++)
                    {
                        espacios += "  ";
                    }
                    elemento += espacios + "     $" + total.ToString();

                    int caracterActual = 0;
                    for (int longT = nombre.Length; longT > 12; longT -= 12)
                    {
                        if (bandera == false)
                        {
                            linea.AppendLine(nombre.Substring(caracterActual, 12) + elemento);
                            bandera = true;
                        }
                        else
                            linea.AppendLine(nombre.Substring(caracterActual, 12));

                        caracterActual += 12;
                    }

                    linea.AppendLine(nombre.Substring(caracterActual, nombre.Length - caracterActual));
                }
                else
                {
                    for (int i = 0; i < (12 - nombre.Length); i++)
                    {
                        espacios += "  ";
                    }
                    elemento = nombre + espacios;

                    nroEspacios = (3 - cant.ToString().Length);
                    espacios = "";
                    for (int i = 0; i < nroEspacios; i++)
                    {
                        espacios += "    ";
                    }
                    elemento += espacios + cant.ToString() ;

                    nroEspacios = (5 - precio.ToString().Length);
                    espacios = "";
                    for (int i = 0; i < nroEspacios; i++)
                    {
                        espacios += "  ";
                    }
                    elemento += espacios + "$" + precio.ToString();

                    nroEspacios = (6 - precio.ToString().Length);
                    espacios = "  ";
                    for (int i = 0; i < nroEspacios; i++)
                    {
                        espacios += "  ";
                    }
                    elemento += espacios + "$" + total.ToString();

                    linea.AppendLine(elemento);
                }
            }
            else
            {
                linea.AppendLine("Los Valores ingresados para esta fila");
                linea.AppendLine("Superan la columnas soportadoas por este.");
                throw new Exception("Los valores ingresados para algunas filas del ticket\nsuperan las columnas");
            }
        }

        public void cortaTicket()
        {
            //esto puede cambiar dependiedo de la impresora 
            linea.AppendLine("\x1B" + "m");
            linea.AppendLine("\x1B" + "d" + "\x09");
        }

        /*
         *Este no funciona pero dejalo
         * public void AbreCajon()
         {
             linea.AppendLine("\x1B" + "p" + "\x00"+"\0F"+"\x96");//cajon 0
             //linea.AppendLine("\x1B" + "p" + "\x01" + "\0F" + "\x96"); //cajon 1
         }*/

        //va a resivir el nombre de la impresora 
        public void ImprimirTicket(string impresora)
        { //este lo vas a descomentar cuando pruebes la impresora 
            RawPrinterHelper.SendStringToPrinter(impresora, linea.ToString());

            //y comentas esto
             Form1 ob = new Form1();
            ob.lblticket.Text = "" + linea.ToString();
            ob.Show();

            //esto no
            linea.Clear();
        }
    }
}
