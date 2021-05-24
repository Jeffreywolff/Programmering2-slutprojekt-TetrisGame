using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Media;


namespace Tetris_Game.Shapes
{
    class O_Shape : ITetromino
    {

        private List<Rectangle> _gameBlock = new List<Rectangle>();
        private const string _tetrominoName = "O-Shape";
        private string _imageAdress = "https://static.wikia.nocookie.net/tetrisconcept/images/4/47/O_Tetromino0.png/revision/latest/scale-to-width-down/204?cb=20201205152236";

        private int[,] _shapePosition = new int[4, 4] {
            {0, 0, 0, 0} ,   /*  initializers for row indexed by 0 */
            {0, 1, 1, 0} ,
            {0, 1, 1, 0} ,
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

        public O_Shape()
        {
            // The O-Block consist of four yellow blocks with the shape of an O.
            for (int i = 0; i < 4; i++)
            {
                Rectangle rectangle = new Rectangle();
                SolidColorBrush yellowBrush = new SolidColorBrush(Color.FromRgb(255, 206, 18));
                rectangle.Fill = yellowBrush;
                rectangle.StrokeThickness = 1;
                rectangle.Stroke = new SolidColorBrush(Color.FromRgb(84, 84, 84));
                _gameBlock.Add(rectangle);
            }
        }

    }
}
