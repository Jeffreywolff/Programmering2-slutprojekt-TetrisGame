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


        public J_Shape()
        {
            // The J-Block consist of four Darkblue blocks with the shape of a J.
            for (int i = 0; i < 5; i++)
            {
                Rectangle rectangle = new Rectangle();
                SolidColorBrush darkBlueBrush = new SolidColorBrush(Color.FromRgb(45, 0, 250));
                rectangle.Fill = darkBlueBrush;
                _gameBlock.Add(rectangle);
            }
        }

        
    }
}
