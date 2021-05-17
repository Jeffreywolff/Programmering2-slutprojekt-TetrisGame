using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Media;


namespace Tetris_Game.Shapes
{
    class S_Shape : ITetromino
    {

        private List<Rectangle> _gameBlock = new List<Rectangle>();
        private const string _tetrominoName = "S-Shape";

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

        public S_Shape()
        {
            // The S-Block consist of four green blocks with the shape of an S.
            for (int i = 0; i < 5; i++)
            {
                Rectangle rectangle = new Rectangle();
                SolidColorBrush greenBrush = new SolidColorBrush(Color.FromRgb(102, 238, 17));
                rectangle.Fill = greenBrush;
                _gameBlock.Add(rectangle);
            }
        }
    }
}
