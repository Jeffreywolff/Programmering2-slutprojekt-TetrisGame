using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Media;


namespace Tetris_Game.Shapes
{
    class L_Shape : ITetromino
    {

        private const string _tetrominoName = "L-Shape";
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

        public L_Shape()
        {
            // The L-Block consist of four orange blocks with the shape of a L.
            for (int i = 0; i < 5; i++)
            {
                Rectangle rectangle = new Rectangle();
                SolidColorBrush orangeBrush = new SolidColorBrush(Color.FromRgb(255, 108, 19));
                rectangle.Fill = orangeBrush;
                _gameBlock.Add(rectangle);
            }
        }



    }
}
