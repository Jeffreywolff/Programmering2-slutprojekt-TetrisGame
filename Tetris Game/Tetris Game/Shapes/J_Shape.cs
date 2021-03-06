using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Media;

namespace Tetris_Game.Shapes
{
    class J_Shape : ITetromino
    {
        private List<Rectangle> _gameBlock = new List<Rectangle>();
        private const string _tetrominoName = "J-Shape";
        private string _imageAdress = "https://static.wikia.nocookie.net/tetrisconcept/images/a/a4/J_Tetromino-0.png/revision/latest?cb=20201205151729";

        private int[,] _shapePosition = new int[4, 4] {
            {0, 0, 0, 0} ,   /*  initializers for row indexed by 0 */
            {1, 1, 1, 0} ,
            {0, 0, 1, 0},
            {0, 0, 0, 0},/*  initializers for row indexed by 1 */
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

        public J_Shape()
        {
            // The J-Block consist of four Darkblue blocks with the shape of a J.
            for (int i = 0; i < 4; i++)
            {
                Rectangle rectangle = new Rectangle();
                SolidColorBrush darkBlueBrush = new SolidColorBrush(Color.FromRgb(45, 0, 250));
                rectangle.Fill = darkBlueBrush;
                rectangle.StrokeThickness = 1;
                rectangle.Stroke = new SolidColorBrush(Color.FromRgb(84, 84, 84));
                _gameBlock.Add(rectangle);
            }
        }

        
    }
}
