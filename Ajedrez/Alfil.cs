using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Drawing;

namespace Ajedrez
{
    /*public abstract class Piece_Base : Sprite
    {
        #region Constructor
        public Piece_Base(Image image, Piece_Color color) : base(image, new Point())
        {
            this.Color = color;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Color de la pieza
        /// </summary>
        public Piece_Color Color { get; set; }
        /// <summary>
        /// Coordenada de la pieza en el tablero
        /// </summary>
        public Point Location { get; set; }
        /// <summary>
        /// Determina si la pieza esta seleccionada
        /// </summary>
        public bool Selected { get; set; }
        /// <summary>
        /// Movimientos que puede realizar la pieza en el tablero
        /// </summary>
        public Piece_Move[] Moves { get; set; }
        /// <summary>
        /// Movimientos habilitados
        /// </summary>
        public Point[] EnabledMoves { get; set; }
        /// <summary>
        /// Imagen a dibujar si la pieza esta seleccionada
        /// </summary>
        public Image SelectedImage { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Dibuja todos los sprites en pantalla
        /// </summary>
        /// <param name="drawHandler">controlador de dibujado</param>
        public override void Draw(DrawHandler drawHandler)
        {
            if (this.Selected)
                drawHandler.Draw(this.SelectedImage, this.Position);

            base.Draw(drawHandler);
        }
        #endregion
    }

    public class Piece_Move
    {
        public Piece_Move(int x, int y, bool mueve = true)
        {
            this.Direction = new Point(x, y);
        
        }
        /// <summary>
        /// Direccion en la cual se realiza el movimiento
        /// </summary>
        public Point Direction { get; set; }
    }*/
}
