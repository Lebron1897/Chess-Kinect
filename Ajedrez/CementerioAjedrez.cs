using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace Ajedrez
{
    class CementerioAjedrez
    {
        public AjedrezFichas[,] cementerio, cementerio_copia;

        public CementerioAjedrez(Canvas Canvas1, int turno)
        {
            if(turno == 0){
                //initialise, populate and draw all peices
                cementerio = new AjedrezFichas[4, 8];
                cementerio_copia = new AjedrezFichas[4, 8];

                ColocaPiezasCementerio();
                Copia_Cementerio();
                GeneraCementerio(Canvas1);
            }
        }

        void ColocaPiezasCementerio()
        {
            cementerio[0, 0] = new AjedrezFichas("torreN");
            cementerio[0, 1] = new AjedrezFichas("caballoN");
            cementerio[0, 2] = new AjedrezFichas("alfilN");
            cementerio[0, 3] = new AjedrezFichas("reinaN");
            cementerio[0, 4] = new AjedrezFichas("reyN");
            cementerio[0, 5] = new AjedrezFichas("alfilN");
            cementerio[0, 6] = new AjedrezFichas("caballoN");
            cementerio[0, 7] = new AjedrezFichas("torreN");
            cementerio[1, 0] = new AjedrezFichas("peonN");
            cementerio[1, 1] = new AjedrezFichas("peonN");
            cementerio[1, 2] = new AjedrezFichas("peonN");
            cementerio[1, 3] = new AjedrezFichas("peonN");
            cementerio[1, 4] = new AjedrezFichas("peonN");
            cementerio[1, 5] = new AjedrezFichas("peonN");
            cementerio[1, 6] = new AjedrezFichas("peonN");
            cementerio[1, 7] = new AjedrezFichas("peonN");

            cementerio[3, 0] = new AjedrezFichas("torreB");
            cementerio[3, 1] = new AjedrezFichas("caballoB");
            cementerio[3, 2] = new AjedrezFichas("alfilB");
            cementerio[3, 3] = new AjedrezFichas("reinaB");
            cementerio[3, 4] = new AjedrezFichas("reyB");
            cementerio[3, 5] = new AjedrezFichas("alfilB");
            cementerio[3, 6] = new AjedrezFichas("caballoB");
            cementerio[3, 7] = new AjedrezFichas("torreB");
            cementerio[2, 0] = new AjedrezFichas("peonB");
            cementerio[2, 1] = new AjedrezFichas("peonB");
            cementerio[2, 2] = new AjedrezFichas("peonB");
            cementerio[2, 3] = new AjedrezFichas("peonB");
            cementerio[2, 4] = new AjedrezFichas("peonB");
            cementerio[2, 5] = new AjedrezFichas("peonB");
            cementerio[2, 6] = new AjedrezFichas("peonB");
            cementerio[2, 7] = new AjedrezFichas("peonB");

            for (int y = 7; y >= 0; y--)
            {
                for (int x = 3; x >= 0; x--)
                {
                    cementerio_copia[x, y] = new AjedrezFichas("null");
                }
            }
        }

        void GeneraCementerio(Canvas Canvas1)
        {
            //clear all peices
            Canvas1.Children.Clear();
            //redraw all peices
            for (int y = 7; y >= 0; y--)
            {
                for (int x = 1; x >= 0; x--)
                {
                    Image cementerio1Image = cementerio[x, 7 - y].fichaImage;
                    Canvas.SetLeft(cementerio1Image, x * 70 + 125);
                    Canvas.SetRight(cementerio1Image, x * 70 + 15);
                    Canvas.SetBottom(cementerio1Image, y * 30 + 30);
                    Canvas.SetTop(cementerio1Image, y * 38 - 60);
                    Canvas1.Children.Add(cementerio1Image);
                }
            }
            for (int y = 7; y >= 0; y--)
            {
                for (int x = 3; x >= 2; x--)
                {
                    Image cementerio2Image = cementerio[x, 7 - y].fichaImage;
                    Canvas.SetLeft(cementerio2Image, x * 70 + 820);
                    Canvas.SetRight(cementerio2Image, x * 70 + 15);
                    Canvas.SetBottom(cementerio2Image, y * 30 + 30);
                    Canvas.SetTop(cementerio2Image, y * 38 - 60);
                    Canvas1.Children.Add(cementerio2Image);
                }
            }
        }

        public void GeneraPiezaCem(AjedrezFichas ficha, Canvas Canvas1)
        {
            Canvas1.Children.Clear();

            Image cementerio2Image = cementerio[ficha.posX, ficha.posY].fichaImage;
            Canvas.SetLeft(cementerio2Image, ficha.posX * 70 + 820);
            Canvas.SetRight(cementerio2Image, ficha.posX * 70 + 15);
            Canvas.SetBottom(cementerio2Image, ficha.posY * 30 + 30);
            Canvas.SetTop(cementerio2Image, ficha.posY * 38 - 60);
            Canvas1.Children.Add(cementerio2Image);
        }

        public void Desaparece_Todo(Canvas Canvas1){
            for(int y = 0; y < 8; y++){
                for(int x = 0; x < 4; x++) {
                    cementerio[x, y] = new AjedrezFichas("null");
                    //cementerio[x, y].vis_fich = AjedrezFichas.VisibilidadFicha.NO_VISIBLE;
                }
            }
            GeneraCementerio(Canvas1);
        }

        void Copia_Cementerio()
        {
            for (int y = 0; y < 8; y++){
                for (int x = 0; x < 4; x++){
                    cementerio_copia[x, y] = cementerio[x, y];
                }
            }
        }

       /* public void Hace_Visible(Canvas Canvas1)
        {


            MessageBox.Show("ESTOY LLEGANDO HASTA AQUI");
            for (int y = 0; y < 7; y++)
            {
                for (int x = 0; x < 4; x++)
                {
                    cementerio[x, y] = new AjedrezFichas("peonN");
                    //cementerio[x, y].vis_fich = AjedrezFichas.VisibilidadFicha.NO_VISIBLE;
                }
            }
            GeneraCementerio(Canvas1);
        }
        public void Hace_Visible()
        {

            cementerio[1, 1] = cementerio_copia[1, 1];
        

            if (dest.color == AjedrezFichas.Color_fichas.NEGRAS)
            {

            }else if (dest.color == AjedrezFichas.Color_fichas.BLANCAS)
            {
                cementerio[posx+2, posy] = dest;
            }

            if (dest.color == AjedrezFichas.Color_fichas.NEGRAS) {
                switch (dest.tipo_ficha) {
                    case "peonN":
                        int i = 0;
                        while (i < 8 || (cementerio[2, i].tipo_ficha != "null"))
                        {
                            i++;
                        }
                        AsignaValores(cementerio[1, i], cementerio_copia[1, i]);
                        break;

                    case "torreN":
                        if (cementerio[0, 0].vis_fich == AjedrezFichas.VisibilidadFicha.VISIBLE) {
                            AsignaValores(cementerio[0, 7], cementerio_copia[0, 7]);
                        }
                        else
                        {
                            AsignaValores(cementerio[0, 0], cementerio_copia[0, 0]);
                        }
                        break;

                    case "caballoN":
                        if (cementerio[0, 1].vis_fich == AjedrezFichas.VisibilidadFicha.VISIBLE)
                        {
                            AsignaValores(cementerio[0, 6], cementerio_copia[0, 6]);
                        }
                        else
                        {
                            AsignaValores(cementerio[0, 1], cementerio_copia[0, 1]);
                        }
                        break;

                    case "alfilN":
                        if (cementerio[0, 2].vis_fich == AjedrezFichas.VisibilidadFicha.VISIBLE)
                        {
                            AsignaValores(cementerio[0, 5], cementerio_copia[0, 5]);
                        }
                        else
                        {
                            AsignaValores(cementerio[0, 2], cementerio_copia[0, 2]);
                        }
                        break;

                    case "reinaN":
                        AsignaValores(cementerio[0, 3], cementerio_copia[0, 3]);
                        break;

                    case "reyN":
                        AsignaValores(cementerio[0, 4], cementerio_copia[0, 4]);
                        break;

                    default:
                        break;
                }
            
            }else if(dest.color == AjedrezFichas.Color_fichas.BLANCAS){
                if (dest.tipo_ficha == "peonB")
                {
                    cementerio[3, 3] = cementerio_copia[3,3];
                }
            switch (dest.tipo_ficha)
            {
                case "peonB":
                    int i = 0;
                    while (i < 8 || (cementerio[2, i].tipo_ficha != "null"))
                    {
                        i++;
                    }
                    AsignaValores(cementerio[2, i], cementerio_copia[2, i]);
                    break;

                case "torreB":
                    if (cementerio[3, 0].tipo_ficha != "null")
                    {
                        AsignaValores(cementerio[3, 7], cementerio_copia[3, 7]);
                    }
                    else
                    {
                        AsignaValores(cementerio[3, 0], cementerio_copia[3, 0]);
                    }
                    break;

                case "caballoB":
                    if (cementerio[3, 1].vis_fich == AjedrezFichas.VisibilidadFicha.VISIBLE)
                    {
                        AsignaValores(cementerio[3, 6], cementerio_copia[3, 6]);
                    }
                    else
                    {
                        AsignaValores(cementerio[3, 1], cementerio_copia[3, 1]);
                    }
                    break;

                case "alfilB":
                    if (cementerio[3, 2].vis_fich == AjedrezFichas.VisibilidadFicha.VISIBLE)
                    {
                        AsignaValores(cementerio[3, 5], cementerio_copia[3, 5]);
                    }
                    else
                    {
                        AsignaValores(cementerio[3, 2], cementerio_copia[3, 2]);
                    }
                    break;

                case "reinaB":
                    cementerio[3, 3] = new AjedrezFichas("reinaB");
                    break;

                case "reyN":
                    AsignaValores(cementerio[0, 4], cementerio_copia[0, 4]);
                    break;

                default:
                    break;
            }
        }*/
       
        
    }
}
