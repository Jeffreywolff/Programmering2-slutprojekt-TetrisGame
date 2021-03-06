using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Media;


namespace Tetris_Game.Shapes
{
    class L_Shape : ITetromino
    {

        private List<Rectangle> _gameBlock = new List<Rectangle>();
        private const string _tetrominoName = "L-Shape";
        private string _imageAdress = "https://static.wikia.nocookie.net/tetrisconcept/images/f/fe/L_Tetromino-0.png/revision/latest/scale-to-width-down/207?cb=20201205151442";

        private int[,] _shapePosition = new int[4, 4] {
            {0, 0, 0, 0} ,   /*  initializers for row indexed by 0 */
            {0, 1, 1, 1} ,
            {0, 1, 0, 0} ,
            {0, 0, 0, 0} ,   /*  initializers for row indexed by 1 */
        };

        List<Rectangle> ITetromino.GameBlock
        {
            get
            {
                return _gameBlock;
            }
        }

        string ITetromino.TetrominoName
        {
            get
            {
                return _tetrominoName;
            }
        }

        int[,] ITetromino.shapePosition
        {
            get
            {
                return _shapePosition;
            }
        }
        string ITetromino.imageAdress
        {
            get
            {
                return _imageAdress;
            }
        }

        public L_Shape()
        {
            // The L-Block consist of four orange blocks with the shape of a L.
            for (int i = 0; i < 4; i++)
            {
                Rectangle rectangle = new Rectangle();
                SolidColorBrush orangeBrush = new SolidColorBrush(Color.FromRgb(255, 108, 19));
                rectangle.Fill = orangeBrush;
                rectangle.StrokeThickness = 1;
                rectangle.Stroke = new SolidColorBrush(Color.FromRgb(84, 84, 84));
                _gameBlock.Add(rectangle);
            }
        }



    }
}
