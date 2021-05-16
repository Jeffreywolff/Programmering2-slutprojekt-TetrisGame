using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Media;

namespace Tetris_Game.Shapes
{
    class Z_Shape : ITetromino
    {
        private const string _tetrominoName = "Z-Shape";
        private List<Rectangle> _gameBlock;
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

        public Z_Shape()
        {
            // The Z-Block consist of four red blocks with the shape of an Z.
            for (int i = 0; i < 5; i++)
            {
                Rectangle rectangle = new Rectangle();
                SolidColorBrush redBrush = new SolidColorBrush(Color.FromRgb(255, 25, 69));
                rectangle.Fill = redBrush;
                _gameBlock.Add(rectangle);
            }
        }

    }
}
