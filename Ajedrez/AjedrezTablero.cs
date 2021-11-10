using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;


namespace Ajedrez {

    class AjedrezTablero {
        public AjedrezFichas[,] tablero;

        public AjedrezTablero(Canvas gameCanvas, int turno) {
            if(turno == 0)
            {
                //initialise, populate and draw all peices
                tablero = new AjedrezFichas[8, 8];
                
                ColocaPiezasTablero();
                GeneraTablero(gameCanvas);
                AsignaPos();
                AsignaColor();
            }
        }

        void ColocaPiezasTablero() {
            tablero[0, 0] = new AjedrezFichas("torreN");
            tablero[1, 0] = new AjedrezFichas("caballoN");
            tablero[2, 0] = new AjedrezFichas("alfilN");
            tablero[3, 0] = new AjedrezFichas("reinaN");
            tablero[4, 0] = new AjedrezFichas("reyN");
            tablero[5, 0] = new AjedrezFichas("alfilN");
            tablero[6, 0] = new AjedrezFichas("caballoN");
            tablero[7, 0] = new AjedrezFichas("torreN");
            tablero[0, 1] = new AjedrezFichas("peonN");
            tablero[1, 1] = new AjedrezFichas("peonN");
            tablero[2, 1] = new AjedrezFichas("peonN");
            tablero[3, 1] = new AjedrezFichas("peonN");
            tablero[4, 1] = new AjedrezFichas("peonN");
            tablero[5, 1] = new AjedrezFichas("peonN");
            tablero[6, 1] = new AjedrezFichas("peonN");
            tablero[7, 1] = new AjedrezFichas("peonN");

            tablero[0, 2] = new AjedrezFichas("null");
            tablero[1, 2] = new AjedrezFichas("null");
            tablero[2, 2] = new AjedrezFichas("null");
            tablero[3, 2] = new AjedrezFichas("null");
            tablero[4, 2] = new AjedrezFichas("null");
            tablero[5, 2] = new AjedrezFichas("null");
            tablero[6, 2] = new AjedrezFichas("null");
            tablero[7, 2] = new AjedrezFichas("null");
            tablero[0, 3] = new AjedrezFichas("null");
            tablero[1, 3] = new AjedrezFichas("null");
            tablero[2, 3] = new AjedrezFichas("null");
            tablero[3, 3] = new AjedrezFichas("null");
            tablero[4, 3] = new AjedrezFichas("null");
            tablero[5, 3] = new AjedrezFichas("null");
            tablero[6, 3] = new AjedrezFichas("null");
            tablero[7, 3] = new AjedrezFichas("null");
            tablero[0, 4] = new AjedrezFichas("null");
            tablero[1, 4] = new AjedrezFichas("null");
            tablero[2, 4] = new AjedrezFichas("null");
            tablero[3, 4] = new AjedrezFichas("null");
            tablero[4, 4] = new AjedrezFichas("null");
            tablero[5, 4] = new AjedrezFichas("null");
            tablero[6, 4] = new AjedrezFichas("null");
            tablero[7, 4] = new AjedrezFichas("null");
            tablero[0, 5] = new AjedrezFichas("null");
            tablero[1, 5] = new AjedrezFichas("null");
            tablero[2, 5] = new AjedrezFichas("null");
            tablero[3, 5] = new AjedrezFichas("null");
            tablero[4, 5] = new AjedrezFichas("null");
            tablero[5, 5] = new AjedrezFichas("null");
            tablero[6, 5] = new AjedrezFichas("null");
            tablero[7, 5] = new AjedrezFichas("null");

            tablero[0, 7] = new AjedrezFichas("torreB");
            tablero[1, 7] = new AjedrezFichas("caballoB");
            tablero[2, 7] = new AjedrezFichas("alfilB");
            tablero[3, 7] = new AjedrezFichas("reinaB");
            tablero[4, 7] = new AjedrezFichas("reyB");
            tablero[5, 7] = new AjedrezFichas("alfilB");
            tablero[6, 7] = new AjedrezFichas("caballoB");
            tablero[7, 7] = new AjedrezFichas("torreB");
            tablero[0, 6] = new AjedrezFichas("peonB");
            tablero[1, 6] = new AjedrezFichas("peonB");
            tablero[2, 6] = new AjedrezFichas("peonB");
            tablero[3, 6] = new AjedrezFichas("peonB");
            tablero[4, 6] = new AjedrezFichas("peonB");
            tablero[5, 6] = new AjedrezFichas("peonB");
            tablero[6, 6] = new AjedrezFichas("peonB");
            tablero[7, 6] = new AjedrezFichas("peonB");
        }
        
        void GeneraTablero(Canvas gameCanvas) {
            //clear all peices
            gameCanvas.Children.Clear();
            //redraw all peices
            for (int y = 7; y >= 0; y--) {
                for (int x = 7; x >= 0; x--) {
                    Image tableroImage = tablero[x, 7 - y].fichaImage;
                    Canvas.SetLeft(tableroImage, x * 51 + 55);
                    Canvas.SetRight(tableroImage, x * 10 + 0);
                    Canvas.SetBottom(tableroImage, y * 10 + 0);
                    Canvas.SetTop(tableroImage, y * 51 + 75);
                    gameCanvas.Children.Add(tableroImage);
                }
            }
        }

        void AsignaPos()
        {
            for(int y = 0; y < 8; y++) {
                for(int x = 0; x < 8; x++) {
                    tablero[x, y].posX = x;
                    tablero[x, y].posY = y;
                }
            }
        }

        void AsignaColor()
        {
            for (int y = 0; y < 2; y++) {
                for (int x = 0; x < 8; x++) {
                    tablero[x, y].color = AjedrezFichas.Color_fichas.NEGRAS;
                }
            }

            for (int y = 2; y < 6; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    tablero[x, y].color = AjedrezFichas.Color_fichas.NULO;
                }
            }

            for (int y = 6; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    tablero[x, y].color = AjedrezFichas.Color_fichas.BLANCAS;
                }
            }
        }
        
        public void MuevePiezas(string destinoLetra, string destinoNum, string origenLetra, string origenNum, Canvas gameCanvas)
        {
            bool mueve;

            int letra1 = Conversor(destinoLetra);
            int num1 = Conversor(destinoNum);

            int letra2 = Conversor(origenLetra);
            int num2 = Conversor(origenNum);

            AjedrezFichas destino = tablero[letra1, num1];
            AjedrezFichas fichaorigen = tablero[letra2, num2];
            AjedrezFichas fichadestino = new AjedrezFichas("null");
            fichadestino.color = AjedrezFichas.Color_fichas.NULO;
            AsignaPos();

            mueve = Movimiento(fichaorigen, destino);

            if ((fichaorigen.tipo_ficha != "null") && (mueve == true))
            {
                if(destino.posX != -1 && destino.posX != -1){
                    if (tablero[letra1, num1].tipo_ficha == "null")
                    {
                        tablero[letra1, num1] = fichaorigen;
                        tablero[letra2, num2] = fichadestino;
                    }
                    else if ((tablero[letra1, num1].color != tablero[letra2, num2].color) && (mueve == true))
                    {
                        tablero[letra1, num1] = fichaorigen;
                        tablero[letra2, num2] = fichadestino;
                    }
                    
                    GeneraTablero(gameCanvas);
                }
            }
            else
            {
                MessageBox.Show("Movimiento no permitido");
            }
        }

        int Conversor(string gridID) {
            int valor = -1;
            if (gridID == "1" || gridID == "A")
            {
                valor = 0;
            }
            else if (gridID == "2" || gridID == "B")
            {
                valor = 1;
            }
            else if (gridID == "3" || gridID == "C")
            {
                valor = 2;
            }
            else if (gridID == "4" || gridID == "D")
            {
                valor = 3;
            }
            else if (gridID == "5" || gridID == "E")
            {
                valor = 4;
            }
            else if (gridID == "6" || gridID == "F")
            {
                valor = 5;
            }
            else if (gridID == "7" || gridID == "G")
            {
                valor = 6;
            }
            else if (gridID == "8" || gridID == "H")
            {
                valor = 7;
            }
            return valor;
        }

        bool Movimiento(AjedrezFichas origen, AjedrezFichas destino)
        {
            bool mueve = false;
            if (origen.tipo_ficha == "peonN")
            {
                if (origen.posY == 1)
                {
                    if ((destino.posY == 2 || destino.posY == 3) && (destino.posX == origen.posX))
                    {
                        mueve = true;
                    }
                    else if ((destino.posX == origen.posX + 1 || destino.posX == origen.posX - 1) & (destino.posY == origen.posY + 1))
                    {
                        if (destino.color == AjedrezFichas.Color_fichas.BLANCAS)
                        {
                            mueve = true;
                        }
                        else
                        {
                            MessageBox.Show("Movimiento no permitido");
                            mueve = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Movimiento no permitido");
                        mueve = false;
                    }
                }
                else if(origen.posY+1 == destino.posY)
                {
                    if (origen.posX == destino.posX)
                    {
                        mueve = true;
                    }
                    else if ((destino.posX == origen.posX + 1 || destino.posX == origen.posX - 1) & (destino.posY == origen.posY + 1))
                    {
                        if ((destino.color == AjedrezFichas.Color_fichas.BLANCAS))
                        {
                            mueve = true;
                        }
                        else
                        {

                            MessageBox.Show("Movimiento no permitido");
                            mueve = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Movimiento no permitido");
                        mueve = false;
                    }
                }
               
            }
            else if (origen.tipo_ficha == "torreN")
            {
                int cont_num = 1;
                int cont_let = 1;
                if ((destino.posX != origen.posX) && (destino.posY == origen.posY))
                {
                    if (destino.posX > origen.posX)
                    {
                        while ((tablero[origen.posX+cont_let, origen.posY].color != AjedrezFichas.Color_fichas.NEGRAS) && (origen.posX + cont_let != destino.posX))
                        {
                            cont_let++;
                        }
                        if (origen.posX + cont_let == destino.posX)
                        {
                            mueve = true;
                        }
                        else if (origen.posX + cont_let != destino.posX)
                        {                            
                            MessageBox.Show("Movimiento no permitido");
                            mueve = false;
                        }
                    }
                    if (destino.posX < origen.posX)
                    {
                        while ((tablero[origen.posX - cont_let, origen.posY].color != AjedrezFichas.Color_fichas.NEGRAS) && (origen.posX - cont_let != destino.posX))
                        {
                            cont_let++;
                        }
                        if (origen.posX - cont_let == destino.posX)
                        {
                            mueve = true;
                        }
                        else if (origen.posX - cont_let != destino.posX)
                        {
                            MessageBox.Show("Movimiento no permitido");
                            mueve = false;
                        }
                    }
                }
                else if ((destino.posX == origen.posX) && (destino.posY != origen.posY))
                {
                    if (destino.posY > origen.posY)
                    {
                        while ((tablero[origen.posX, origen.posY + cont_num].color != AjedrezFichas.Color_fichas.NEGRAS) && (origen.posY + cont_num != destino.posY))
                        {
                            cont_num++;
                        }
                        if (origen.posY + cont_num == destino.posY)
                        {
                            mueve = true;
                        }
                        else if (origen.posY + cont_num != destino.posY)
                        {
                            MessageBox.Show("Movimiento no permitido");
                            mueve = false;
                        }
                    }
                    if (destino.posY < origen.posY)
                    {
                        while ((tablero[origen.posX, origen.posY - cont_num].color != AjedrezFichas.Color_fichas.NEGRAS) && (origen.posY - cont_num != destino.posY))
                        {
                            cont_num++;
                        }
                        if (origen.posY - cont_num == destino.posY)
                        {
                            mueve = true;
                        }
                        else if (origen.posY - cont_num != destino.posY)
                        {
                            MessageBox.Show("Movimiento no permitido");
                            mueve = false;
                        }
                    }
                }
            }
            else if (origen.tipo_ficha == "caballoN")
            {

                if (destino.posY == origen.posY + 1)
                {
                    if (destino.posX == origen.posX + 2)
                    {
                        mueve = true;
                    }
                    else if (destino.posY == origen.posY - 2)
                    {
                        mueve = true;
                    }
                    else
                    {
                        MessageBox.Show("Movimiento no permitido");
                        mueve = false;
                    }
                }
                else if (destino.posY == origen.posY + 2)
                {
                    if (destino.posX == origen.posX + 1)
                    {
                        mueve = true;
                    }
                    else if (destino.posX == origen.posX - 1)
                    {
                        mueve = true;
                    }
                    else
                    {
                        MessageBox.Show("Movimiento no permitido");
                        mueve = false;
                    }
                }
                else if (destino.posY == origen.posY - 1)
                {
                    if (destino.posX == origen.posX + 2)
                    {
                        mueve = true;
                    }
                    else if (destino.posX == origen.posX - 2)
                    {
                        mueve = true;
                    }
                    else
                    {
                        MessageBox.Show("Movimiento no permitido");
                        mueve = false;
                    }
                }
                else if (destino.posY == origen.posY - 2)
                {
                    if (destino.posX == origen.posX + 1)
                    {
                        mueve = true;
                    }
                    else if (destino.posX == origen.posX - 1)
                    {
                        mueve = true;
                    }
                    else
                    {
                        MessageBox.Show("Movimiento no permitido");
                        mueve = false;
                    }
                }
                else
                {
                    MessageBox.Show("Movimiento no permitido");
                    mueve = false;
                }
            }
            else if (origen.tipo_ficha == "alfilN")
            {
                int cont = 1;
                if((origen.posX != destino.posX) && (origen.posY != destino.posY))
                {
                    if ((origen.posX < destino.posX) && (origen.posY < destino.posY))
                    {
                        while ((tablero[origen.posX + cont, origen.posY + cont].color != AjedrezFichas.Color_fichas.NEGRAS) && (origen.posX + cont != destino.posX))
                        {
                            cont++;
                        }
                        if (origen.posX + cont == destino.posX)
                        {
                            mueve = true;
                        }
                        else if (origen.posX + cont != destino.posX)
                        {
                            MessageBox.Show("Movimiento no permitido");
                            mueve = false;
                        }
                    }else if ((origen.posX > destino.posX) && (origen.posY > destino.posY))
                    {
                        while ((tablero[origen.posX - cont, origen.posY - cont].color != AjedrezFichas.Color_fichas.NEGRAS) && (origen.posX - cont != destino.posX))
                        {
                            cont++;
                        }
                        if (origen.posX - cont == destino.posX)
                        {
                            mueve = true;
                        }
                        else if (origen.posX - cont != destino.posX)
                        {
                            MessageBox.Show("Movimiento no permitido");
                            mueve = false;
                        }
                    }else if ((origen.posX > destino.posX) && (origen.posY < destino.posY))
                    {
                        while ((tablero[origen.posX - cont, origen.posY + cont].color != AjedrezFichas.Color_fichas.NEGRAS) && (origen.posX - cont != destino.posX))
                        {
                            cont++;
                        }
                        if (origen.posX - cont == destino.posX)
                        {
                            mueve = true;
                        }
                        else if (origen.posX - cont != destino.posX)
                        {
                            MessageBox.Show("Movimiento no permitido");
                            mueve = false;
                        }
                    }else if ((origen.posX < destino.posX) && (origen.posY > destino.posY))
                    {
                        while ((tablero[origen.posX + cont, origen.posY - cont].color != AjedrezFichas.Color_fichas.NEGRAS) && (origen.posX + cont != destino.posX))
                        {
                            cont++;
                        }
                        if (origen.posX + cont == destino.posX)
                        {
                            mueve = true;
                        }
                        else if (origen.posX + cont != destino.posX)
                        {
                            MessageBox.Show("Movimiento no permitido");
                            mueve = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Movimiento no permitido");
                        mueve = false;
                    }
                }
                else
                {
                    MessageBox.Show("Movimiento no permitido");
                    mueve = false;
                }
            }
            else if (origen.tipo_ficha == "reinaN")
            {
                int cont_num = 1;
                int cont_let = 1;
                int cont = 1;
                if ((destino.posX != origen.posX) && (destino.posY == origen.posY))
                {
                    if (destino.posX > origen.posX)
                    {
                        while ((tablero[origen.posX + cont_let, origen.posY].color != AjedrezFichas.Color_fichas.NEGRAS) && (origen.posX + cont_let != destino.posX))
                        {
                            cont_let++;
                        }
                        if (origen.posX + cont_let == destino.posX)
                        {
                            mueve = true;
                        }
                        else if (origen.posX + cont_let != destino.posX)
                        {
                            MessageBox.Show("Movimiento no permitido");
                            mueve = false;
                        }
                    }
                    if (destino.posX < origen.posX)
                    {
                        while ((tablero[origen.posX - cont_let, origen.posY].color != AjedrezFichas.Color_fichas.NEGRAS) && (origen.posX - cont_let != destino.posX))
                        {
                            cont_let++;
                        }
                        if (origen.posX - cont_let == destino.posX)
                        {
                            mueve = true;
                        }
                        else if (origen.posX - cont_let != destino.posX)
                        {
                            MessageBox.Show("Movimiento no permitido");
                            mueve = false;
                        }
                    }
                }
                else if ((destino.posX == origen.posX) && (destino.posY != origen.posY))
                {
                    if (destino.posY > origen.posY)
                    {
                        while ((tablero[origen.posX, origen.posY + cont_num].color != AjedrezFichas.Color_fichas.NEGRAS) && (origen.posY + cont_num != destino.posY))
                        {
                            cont_num++;
                        }
                        if (origen.posY + cont_num == destino.posY)
                        {
                            mueve = true;
                        }
                        else if (origen.posY + cont_num != destino.posY)
                        {
                            MessageBox.Show("Movimiento no permitido");
                            mueve = false;
                        }
                    }
                    if (destino.posY < origen.posY)
                    {
                        while ((tablero[origen.posX, origen.posY - cont_num].color != AjedrezFichas.Color_fichas.NEGRAS) && (origen.posY - cont_num != destino.posY))
                        {
                            cont_num++;
                        }
                        if (origen.posY - cont_num == destino.posY)
                        {
                            mueve = true;
                        }
                        else if (origen.posY - cont_num != destino.posY)
                        {
                            MessageBox.Show("Movimiento no permitido");
                            mueve = false;
                        }
                    }
                }
                else if ((origen.posX != destino.posX) && (origen.posY != destino.posY))
                {
                    if ((origen.posX < destino.posX) && (origen.posY < destino.posY))
                    {
                        while ((tablero[origen.posX + cont, origen.posY + cont].color != AjedrezFichas.Color_fichas.NEGRAS) && (origen.posX + cont != destino.posX))
                        {
                            cont++;
                        }
                        if (origen.posX + cont == destino.posX)
                        {
                            mueve = true;
                        }
                        else if (origen.posX + cont != destino.posX)
                        {
                            MessageBox.Show("Movimiento no permitido");
                            mueve = false;
                        }
                    }
                    else if ((origen.posX > destino.posX) && (origen.posY > destino.posY))
                    {
                        while ((tablero[origen.posX - cont, origen.posY - cont].color != AjedrezFichas.Color_fichas.NEGRAS) && (origen.posX - cont != destino.posX))
                        {
                            cont++;
                        }
                        if (origen.posX - cont == destino.posX)
                        {
                            mueve = true;
                        }
                        else if (origen.posX - cont != destino.posX)
                        {
                            MessageBox.Show("Movimiento no permitido");
                            mueve = false;
                        }
                    }
                    else if ((origen.posX > destino.posX) && (origen.posY < destino.posY))
                    {
                        while ((tablero[origen.posX - cont, origen.posY + cont].color != AjedrezFichas.Color_fichas.NEGRAS) && (origen.posX - cont != destino.posX))
                        {
                            cont++;
                        }
                        if (origen.posX - cont == destino.posX)
                        {
                            mueve = true;
                        }
                        else if (origen.posX - cont != destino.posX)
                        {
                            MessageBox.Show("Movimiento no permitido");
                            mueve = false;
                        }
                    }
                    else if ((origen.posX < destino.posX) && (origen.posY > destino.posY))
                    {
                        while ((tablero[origen.posX + cont, origen.posY - cont].color != AjedrezFichas.Color_fichas.NEGRAS) && (origen.posX + cont != destino.posX))
                        {
                            cont++;
                        }
                        if (origen.posX + cont == destino.posX)
                        {
                            mueve = true;
                        }
                        else if (origen.posX + cont != destino.posX)
                        {
                            MessageBox.Show("Movimiento no permitido");
                            mueve = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Movimiento no permitido");
                        mueve = false;
                    }
                }
                else
                {
                    MessageBox.Show("Movimiento no permitido");
                    mueve = false;
                }
            }
            else if (origen.tipo_ficha == "reyN")
            {
                if ((destino.posX == origen.posX + 1) && (destino.posY == origen.posY))
                {
                    mueve = true;
                }
                else if ((destino.posX == origen.posX - 1) && (destino.posY == origen.posY))
                {
                    mueve = true;
                }
                else if ((destino.posY == origen.posY + 1) && (destino.posX == origen.posX))
                {
                    mueve = true;
                }
                else if ((destino.posY == origen.posY - 1) && (destino.posX == origen.posX))
                {
                    mueve = true;
                }
                else if ((destino.posX == origen.posX + 1) && (destino.posY == origen.posY + 1))
                {
                    mueve = true;
                }
                else if ((destino.posX == origen.posX - 1) && (destino.posY == origen.posY + 1))
                {
                    mueve = true;
                }
                else if ((destino.posY == origen.posY + 1) && (destino.posX == origen.posX - 1))
                {
                    mueve = true;
                }
                else if ((destino.posY == origen.posY - 1) && (destino.posX == origen.posX - 1))
                {
                    mueve = true;
                }
                else
                {
                    mueve = false;
                    MessageBox.Show("Movimiento no permitido");
                }
            }
            else if (origen.tipo_ficha == "peonB")
            {
                if (origen.posY == 6)
                {
                    if ((destino.posY == 5 || destino.posY == 4) && (destino.posX == origen.posX))
                    {
                        mueve = true;
                    }
                    else if ((destino.posX == origen.posX + 1 || destino.posX == origen.posX - 1) && (destino.posY == origen.posY - 1))
                    {
                        if ((destino.color == AjedrezFichas.Color_fichas.NEGRAS))
                        {
                            mueve = true;
                        }
                        else
                        {
                            MessageBox.Show("Movimiento no permitido");
                            mueve = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Movimiento no permitido");
                        mueve = false;
                    }
                }
                else if (origen.posY-1 == destino.posY)
                {
                    if (origen.posX == destino.posX)
                    {
                        mueve = true;
                    }
                    else if ((destino.posX == origen.posX + 1 || destino.posX == origen.posX - 1) && (destino.posY == origen.posY - 1))
                    {
                        if ((destino.color == AjedrezFichas.Color_fichas.NEGRAS))
                        {
                            mueve = true;
                        }
                        else
                        {
                            MessageBox.Show("Movimiento no permitido");
                            mueve = false;
                        }
                    }
                    else
                    {
                        mueve = false;
                    }
                }
            }
            else if (origen.tipo_ficha == "torreB")
            {
                int cont_num = 1;
                int cont_let = 1;
                if ((destino.posX != origen.posX) && (destino.posY == origen.posY))
                {
                    if (destino.posX > origen.posX)
                    {
                        while ((tablero[origen.posX + cont_let, origen.posY].color != AjedrezFichas.Color_fichas.BLANCAS) && (origen.posX + cont_let != destino.posX))
                        {
                            cont_let++;
                        }
                        if (origen.posX + cont_let == destino.posX)
                        {
                            mueve = true;
                        }
                        else if (origen.posX + cont_let != destino.posX)
                        {
                            MessageBox.Show("Movimiento no permitido");
                            mueve = false;
                        }
                    }
                    if (destino.posX < origen.posX)
                    {
                        while ((tablero[origen.posX - cont_let, origen.posY].color != AjedrezFichas.Color_fichas.BLANCAS) && (origen.posX - cont_let != destino.posX))
                        {
                            cont_let++;
                        }
                        if (origen.posX - cont_let == destino.posX)
                        {
                            mueve = true;
                        }
                        else if (origen.posX - cont_let != destino.posX)
                        {
                            MessageBox.Show("Movimiento no permitido");
                            mueve = false;
                        }
                    }
                }
                else if ((destino.posX == origen.posX) && (destino.posY != origen.posY))
                {
                    if (destino.posY > origen.posY)
                    {
                        while ((tablero[origen.posX, origen.posY + cont_num].color != AjedrezFichas.Color_fichas.BLANCAS) && (origen.posY + cont_num != destino.posY))
                        {
                            cont_num++;
                        }
                        if (origen.posY + cont_num == destino.posY)
                        {
                            mueve = true;
                        }
                        else if (origen.posY + cont_num != destino.posY)
                        {
                            MessageBox.Show("Movimiento no permitido");
                            mueve = false;
                        }
                    }
                    if (destino.posY < origen.posY)
                    {
                        while ((tablero[origen.posX, origen.posY - cont_num].color != AjedrezFichas.Color_fichas.BLANCAS) && (origen.posY - cont_num != destino.posY))
                        {
                            cont_num++;
                        }
                        if (origen.posY - cont_num == destino.posY)
                        {
                            mueve = true;
                        }
                        else if (origen.posY - cont_num != destino.posY)
                        {
                            MessageBox.Show("Movimiento no permitido");
                            mueve = false;
                        }
                    }
                }
            }
            else if (origen.tipo_ficha == "caballoB")
            {

                if (destino.posY == origen.posY + 1)
                {
                    if (destino.posX == origen.posX + 2)
                    {
                        mueve = true;
                    }
                    else if (destino.posY == origen.posY - 2)
                    {
                        mueve = true;
                    }
                    else
                    {
                        MessageBox.Show("Movimiento no permitido");
                        mueve = false;
                    }
                }
                else if (destino.posY == origen.posY + 2)
                {
                    if (destino.posX == origen.posX + 1)
                    {
                        mueve = true;
                    }
                    else if (destino.posX == origen.posX - 1)
                    {
                        mueve = true;
                    }
                    else
                    {
                        MessageBox.Show("Movimiento no permitido");
                        mueve = false;
                    }
                }
                else if (destino.posY == origen.posY - 1)
                {
                    if (destino.posX == origen.posX + 2)
                    {
                        mueve = true;
                    }
                    else if (destino.posX == origen.posX - 2)
                    {
                        mueve = true;
                    }
                    else
                    {
                        MessageBox.Show("Movimiento no permitido");
                        mueve = false;
                    }
                }
                else if (destino.posY == origen.posY - 2)
                {
                    if (destino.posX == origen.posX + 1)
                    {
                        mueve = true;
                    }
                    else if (destino.posX == origen.posX - 1)
                    {
                        mueve = true;
                    }
                    else
                    {
                        MessageBox.Show("Movimiento no permitido");
                        mueve = false;
                    }
                }
                else
                {
                    MessageBox.Show("Movimiento no permitido");
                    mueve = false;
                }
            }
            else if (origen.tipo_ficha == "alfilB")
            {
                int cont = 1;
                if ((origen.posX != destino.posX) && (origen.posY != destino.posY))
                {
                    if ((origen.posX < destino.posX) && (origen.posY < destino.posY))
                    {
                        while ((tablero[origen.posX + cont, origen.posY + cont].color != AjedrezFichas.Color_fichas.NEGRAS) && (origen.posX + cont != destino.posX))
                        {
                            cont++;
                        }
                        if (origen.posX + cont == destino.posX)
                        {
                            mueve = true;
                        }
                        else if (origen.posX + cont != destino.posX)
                        {
                            MessageBox.Show("Movimiento no permitido");
                            mueve = false;
                        }
                    }
                    else if ((origen.posX > destino.posX) && (origen.posY > destino.posY))
                    {
                        while ((tablero[origen.posX - cont, origen.posY - cont].color != AjedrezFichas.Color_fichas.NEGRAS) && (origen.posX - cont != destino.posX))
                        {
                            cont++;
                        }
                        if (origen.posX - cont == destino.posX)
                        {
                            mueve = true;
                        }
                        else if (origen.posX - cont != destino.posX)
                        {
                            MessageBox.Show("Movimiento no permitido");
                            mueve = false;
                        }
                    }
                    else if ((origen.posX > destino.posX) && (origen.posY < destino.posY))
                    {
                        while ((tablero[origen.posX - cont, origen.posY + cont].color != AjedrezFichas.Color_fichas.NEGRAS) && (origen.posX - cont != destino.posX))
                        {
                            cont++;
                        }
                        if (origen.posX - cont == destino.posX)
                        {
                            mueve = true;
                        }
                        else if (origen.posX - cont != destino.posX)
                        {
                            MessageBox.Show("Movimiento no permitido");
                            mueve = false;
                        }
                    }
                    else if ((origen.posX < destino.posX) && (origen.posY > destino.posY))
                    {
                        while ((tablero[origen.posX + cont, origen.posY - cont].color != AjedrezFichas.Color_fichas.NEGRAS) && (origen.posX + cont != destino.posX))
                        {
                            cont++;
                        }
                        if (origen.posX + cont == destino.posX)
                        {
                            mueve = true;
                        }
                        else if (origen.posX + cont != destino.posX)
                        {
                            MessageBox.Show("Movimiento no permitido");
                            mueve = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Movimiento no permitido");
                        mueve = false;
                    }
                }
                else
                {
                    MessageBox.Show("Movimiento no permitido");
                    mueve = false;
                }
            }
            else if (origen.tipo_ficha == "reinaB")
            {
                int cont_num = 1;
                int cont_let = 1;
                int cont = 1;
                if ((destino.posX != origen.posX) && (destino.posY == origen.posY))
                {
                    if (destino.posX > origen.posX)
                    {
                        while ((tablero[origen.posX + cont_let, origen.posY].color != AjedrezFichas.Color_fichas.NEGRAS) && (origen.posX + cont_let != destino.posX))
                        {
                            cont_let++;
                        }
                        MessageBox.Show(Convert.ToString(cont_let));
                        if (origen.posX + cont_let == destino.posX)
                        {
                            mueve = true;
                        }
                        else if (origen.posX + cont_let != destino.posX)
                        {
                            MessageBox.Show("Movimiento no permitido");
                            mueve = false;
                        }
                    }
                    if (destino.posX < origen.posX)
                    {
                        while ((tablero[origen.posX - cont_let, origen.posY].color != AjedrezFichas.Color_fichas.NEGRAS) && (origen.posX - cont_let != destino.posX))
                        {
                            cont_let++;
                        }
                        MessageBox.Show(Convert.ToString(origen.posX + cont_let));
                        if (origen.posX - cont_let == destino.posX)
                        {
                            mueve = true;
                        }
                        else if (origen.posX - cont_let != destino.posX)
                        {
                            MessageBox.Show("Movimiento no permitido");
                            mueve = false;
                        }
                    }
                }
                else if ((destino.posX == origen.posX) && (destino.posY != origen.posY))
                {
                    if (destino.posY > origen.posY)
                    {
                        while ((tablero[origen.posX, origen.posY + cont_num].color != AjedrezFichas.Color_fichas.NEGRAS) && (origen.posY + cont_num != destino.posY))
                        {
                            cont_num++;
                        }
                        if (origen.posY + cont_num == destino.posY)
                        {
                            mueve = true;
                        }
                        else if (origen.posY + cont_num != destino.posY)
                        {
                            MessageBox.Show("Movimiento no permitido");
                            mueve = false;
                        }
                    }
                    if (destino.posY < origen.posY)
                    {
                        while ((tablero[origen.posX, origen.posY - cont_num].color != AjedrezFichas.Color_fichas.NEGRAS) && (origen.posY - cont_num != destino.posY))
                        {
                            cont_num++;
                        }
                        if (origen.posY - cont_num == destino.posY)
                        {
                            mueve = true;
                        }
                        else if (origen.posY - cont_num != destino.posY)
                        {
                            MessageBox.Show("Movimiento no permitido");
                            mueve = false;
                        }
                    }
                }
                else if ((origen.posX != destino.posX) && (origen.posY != destino.posY))
                {
                    if ((origen.posX < destino.posX) && (origen.posY < destino.posY))
                    {
                        while ((tablero[origen.posX + cont, origen.posY + cont].color != AjedrezFichas.Color_fichas.NEGRAS) && (origen.posX + cont != destino.posX))
                        {
                            cont++;
                        }
                        if (origen.posX + cont == destino.posX)
                        {
                            mueve = true;
                        }
                        else if (origen.posX + cont != destino.posX)
                        {
                            MessageBox.Show("Movimiento no permitido");
                            mueve = false;
                        }
                    }
                    else if ((origen.posX > destino.posX) && (origen.posY > destino.posY))
                    {
                        while ((tablero[origen.posX - cont, origen.posY - cont].color != AjedrezFichas.Color_fichas.NEGRAS) && (origen.posX - cont != destino.posX))
                        {
                            cont++;
                        }
                        if (origen.posX - cont == destino.posX)
                        {
                            mueve = true;
                        }
                        else if (origen.posX - cont != destino.posX)
                        {
                            MessageBox.Show("Movimiento no permitido");
                            mueve = false;
                        }
                    }
                    else if ((origen.posX > destino.posX) && (origen.posY < destino.posY))
                    {
                        while ((tablero[origen.posX - cont, origen.posY + cont].color != AjedrezFichas.Color_fichas.NEGRAS) && (origen.posX - cont != destino.posX))
                        {
                            cont++;
                        }
                        if (origen.posX - cont == destino.posX)
                        {
                            mueve = true;
                        }
                        else if (origen.posX - cont != destino.posX)
                        {
                            MessageBox.Show("Movimiento no permitido");
                            mueve = false;
                        }
                    }
                    else if ((origen.posX < destino.posX) && (origen.posY > destino.posY))
                    {
                        while ((tablero[origen.posX + cont, origen.posY - cont].color != AjedrezFichas.Color_fichas.NEGRAS) && (origen.posX + cont != destino.posX))
                        {
                            cont++;
                        }
                        if (origen.posX + cont == destino.posX)
                        {
                            mueve = true;
                        }
                        else if (origen.posX + cont != destino.posX)
                        {
                            MessageBox.Show("Movimiento no permitido");
                            mueve = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Movimiento no permitido");
                        mueve = false;
                    }
                }
                else
                {
                    MessageBox.Show("Movimiento no permitido");
                    mueve = false;
                }
            }
            else if (origen.tipo_ficha == "reyB")
            {
                if ((destino.posX == origen.posX + 1) && (destino.posY == origen.posY))
                {
                    mueve = true;
                }
                else if ((destino.posX == origen.posX - 1) && (destino.posY == origen.posY))
                {
                    mueve = true;
                }
                else if ((destino.posY == origen.posY + 1) && (destino.posX == origen.posX))
                {
                    mueve = true;
                }
                else if ((destino.posY == origen.posY - 1) && (destino.posX == origen.posX))
                {
                    mueve = true;
                }
                else if ((destino.posX == origen.posX + 1) && (destino.posY == origen.posY + 1))
                {
                    mueve = true;
                }
                else if ((destino.posX == origen.posX - 1) && (destino.posY == origen.posY + 1))
                {
                    mueve = true;
                }
                else if ((destino.posY == origen.posY + 1) && (destino.posX == origen.posX - 1))
                {
                    mueve = true;
                }
                else if ((destino.posY == origen.posY - 1) && (destino.posX == origen.posX - 1))
                {
                    mueve = true;
                }
                else
                {
                    mueve = false;
                    MessageBox.Show("Movimiento no permitido");
                }
            }
            return mueve;
        }

        /*void Elimina_Pieza(Canvas gameCanvas, AjedrezFichas destino){
            if(destino.color == AjedrezFichas.Color_fichas.BLANCAS){
                int x = 0;
                int y = 0;
                while((y < 8) || cementerio[0, 0].cementerioB[x, y].tipo_ficha != destino.tipo_ficha){
                    while ((x < 2) || (cementerio[0, 0].cementerioB[x, y].tipo_ficha != destino.tipo_ficha)){
                        x++;
                    }
                    y++;
                }
                cementerio[0, 0].Hace_Visible(gameCanvas, cementerio[0, 0].cementerioB[x, y]); 
            }
            copia[0, 0] = new AjedrezFichas("null");
            AsignaValores(destino, copia[0, 0]);
            
            GeneraTablero(gameCanvas);
        }*/

        /*void AsignaValores(AjedrezFichas destino, AjedrezFichas origen){
            destino.color = origen.color;
            destino.fichaImage = origen.fichaImage;
            destino.tipo_ficha = origen.tipo_ficha;
            destino.posX = origen.posX;
            destino.posY = origen.posY;
        }*/
    }
}
