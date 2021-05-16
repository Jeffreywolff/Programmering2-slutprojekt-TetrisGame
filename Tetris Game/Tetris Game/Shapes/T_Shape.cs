using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Shapes;
using System.Windows.Media;

namespace Tetris_Game
{
    class T_Shape : ShapeCtor, ITetromino
    {
        public List<Shape> GameBlock { get; private set; }

        public string TetrominoName
        {
            get => TetrominoName;
            private set
            {
                TetrominoName = "T-Shape";
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
            }
        }

        

    }
}
