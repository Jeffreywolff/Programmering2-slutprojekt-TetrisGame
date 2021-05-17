using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Media;

namespace Tetris_Game
{
    class I_Shape : ITetromino
    {
        private const string _tetrominoName = "I-Shape";
        private List<Rectangle> _gameBlock = new List<Rectangle>();
        List<Rectangle> ITetromino.GameBlock { 
            get {
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

        
        public I_Shape()
        {
            // The I-Block consist of four blue blocks in one column.
            for (int i = 0; i < 4; i++)
            {
                Rectangle rectangle = new Rectangle();
                SolidColorBrush lightBlueBrush = new SolidColorBrush(Color.FromRgb(0, 214, 251));
                rectangle.Fill = lightBlueBrush;
                _gameBlock.Add(rectangle);

            }


        }


    }
}
