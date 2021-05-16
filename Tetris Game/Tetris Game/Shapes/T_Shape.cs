using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Media;

namespace Tetris_Game
{
    class T_Shape : ITetromino
    {
        private const string _tetrominoName = "T-Shape";
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

        public T_Shape()
        {
            // The T-Block consist of four purple blocks with the shape of a T.
            for (int i = 0; i < 5; i++)
            {
                Rectangle rectangle = new Rectangle();
                SolidColorBrush purpleBrush = new SolidColorBrush(Color.FromRgb(173, 0, 250));
                rectangle.Fill = purpleBrush;
                _gameBlock.Add(rectangle);
            }
        }

        

    }
}
