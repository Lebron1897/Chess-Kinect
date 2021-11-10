using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows;

namespace Ajedrez {
    class AjedrezFichas {
        //String to recognise peice type and used for fetching the image from directory.
        public string tipo_ficha;
        //Image object declaration.
        public Image fichaImage = new Image();
        public enum Color_fichas : Int32
        {
            BLANCAS,
            NEGRAS,
            NULO
        }
        public Color_fichas color = new Color_fichas();
        
        public int posX;
        public int posY;

        public enum VisibilidadFicha : Int32
        {
            VISIBLE,
            NO_VISIBLE
        }
        public VisibilidadFicha vis_fich = new VisibilidadFicha(); 

        public AjedrezFichas(string tipo) {
            //initialise type.
            tipo_ficha = tipo;

            //Explicitly state Width and Height to fix DPI mismatching issues.
            fichaImage.Width = 30;
            fichaImage.Height = 30;

            vis_fich = VisibilidadFicha.VISIBLE;

            //update the image source.
            fichaImage.Source = new CroppedBitmap(new BitmapImage(new Uri("../../" + tipo_ficha + ".png", UriKind.Relative)), new Int32Rect(0, 0, 80, 80));
        }
    }
}
