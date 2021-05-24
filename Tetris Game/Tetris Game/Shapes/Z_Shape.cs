using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Media;

namespace Tetris_Game.Shapes
{
    class Z_Shape : ITetromino
    {
        private List<Rectangle> _gameBlock = new List<Rectangle>();
        private const string _tetrominoName = "Z-Shape";
        private string _imageAdress = "https://static.wikia.nocookie.net/tetrisconcept/images/9/9c/Z_Tetromino0.png/revision/latest/scale-to-width-down/310?cb=20201205152051";

        private int[,] _shapePosition = new int[4, 4] {
            {0, 0, 0, 0} ,   /*  initializers for row indexed by 0 */
            {1, 1, 0, 0} ,
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

        public Z_Shape()
        {
            // The Z-Block consist of four red blocks with the shape of an Z.
            for (int i = 0; i < 4; i++)
            {
                Rectangle rectangle = new Rectangle();
                SolidColorBrush redBrush = new SolidColorBrush(Color.FromRgb(255, 25, 69));
                rectangle.Fill = redBrush;
                rectangle.StrokeThickness = 1;
                rectangle.Stroke = new SolidColorBrush(Color.FromRgb(84, 84, 84));
                _gameBlock.Add(rectangle);
            }
        }

    }
}
